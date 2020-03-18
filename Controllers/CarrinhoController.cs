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
        private readonly CarrinhoContext _context;
        private readonly CarrinhoDAO _carrinhoDAO;
        private readonly SetorDAO _setorDAO;

        private readonly ProdutoDAO _produtoDAO;

        public CarrinhoController()
        {
            _context = new CarrinhoContext();
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
        public async Task<IActionResult> AddCarrinho(int? id, int idCarrinho, int qtd)
        {
            if (id == null )
            {
                return NotFound();
            }
            var carrinho = await _carrinhoDAO.getCarrinhoById(idCarrinho);
            var produto = await _produtoDAO.getProdutoById(id);
            carrinho.ListaProdutos.Add(new CarrinhoProdutos() { Produto = produto , QtdProduto = qtd});
            _carrinhoDAO.Update(carrinho);
           
            if (produto == null)
            {
                return NotFound();
            }
            return Json(produto);
        }

        public async Task<IActionResult> FinalizarCompra(int id){
            System.Console.WriteLine(id);
            var carrinho = await _carrinhoDAO.getCarrinhoById(id);
            carrinho.EstadoCompra = "Finalizada";
            _carrinhoDAO.Update(carrinho);
            return View();
        }
        public async void EnterromperCompra(int idCarrinho){
            var carrinho = await _carrinhoDAO.getCarrinhoById(idCarrinho);
            carrinho.EstadoCompra = "Enterrompida";
            _carrinhoDAO.Update(carrinho);
        }



    }
}