using System.Collections.Generic;
using System.Threading.Tasks;
using Carrinho.Dados;
using Carrinho.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Carrinho.DAO;

namespace Carrinho.Controllers
{
    public class CarrinhoController : Controller
    {

        private readonly CarrinhoDAO _carrinhoDAO;
        private readonly SetorDAO _setorDAO;

        private readonly ProdutoDAO _produtoDAO;

        public CarrinhoController()
        {
            _carrinhoDAO = new CarrinhoDAO();
            _setorDAO = new SetorDAO();
            _produtoDAO = new ProdutoDAO();

        }
        public IActionResult Index()
        {
            return RedirectToAction("Add");

        }

        public async Task<IActionResult> Add()
        {

            ViewBag.SetorId = new SelectList(_setorDAO.SetoresEnumerable(), "Id", "Nome");
            ViewBag.IdCarrinho = _carrinhoDAO.NovoCarrinho("Em Andamento").Id;
            return View(await _produtoDAO.Produtos());
        }

        [HttpPost]
        public async Task<IActionResult> AddCarrinho(int? id, int idCarrinho, int qtd)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carrinho = await _carrinhoDAO.getCarrinhoById(idCarrinho);
            var produto = await _produtoDAO.getProdutoById(id);
            carrinho.ListaProdutos.Add(new CarrinhoProdutos() { Produto = produto, QtdProduto = qtd });
            _carrinhoDAO.Update(carrinho);

            if (produto == null)
            {
                return NotFound();
            }
            return Json(produto);
        }

        public async Task<IActionResult> FinalizarCompra(int id)
        {

            var carrinho = await _carrinhoDAO.getCarrinhoById(id);
            carrinho.EstadoCompra = "Confirmacao";
            _carrinhoDAO.Update(carrinho);
            ViewBag.IdCarrinho = id;

            return View(carrinho.ListaProdutos);
        }

        public async Task<IActionResult> Confirmar(int id){
            var carrinho = await _carrinhoDAO.getCarrinhoById(id);
            carrinho.EstadoCompra = "Finalizada";
            _carrinhoDAO.Update(carrinho);
            return View();
        }
        public async Task<IActionResult> RemoverCarrinho(int? id, int idCarrinho , int qtd){

            var carrinho = await _carrinhoDAO.getCarrinhoById(idCarrinho);
            var produto = carrinho.ListaProdutos.Find(p => p.Produto.Id == id);
            System.Console.WriteLine(carrinho.Id);
            System.Console.WriteLine(produto.Produto.Id);
            carrinho.ListaProdutos.Remove(produto);
            _carrinhoDAO.Update(carrinho);
            return Json(produto.Produto);

        }
        public async void EnterromperCompra(int idCarrinho)
        {
            var carrinho = await _carrinhoDAO.getCarrinhoById(idCarrinho);
            carrinho.EstadoCompra = "Enterrompida";
            _carrinhoDAO.Update(carrinho);
        }



    }
}