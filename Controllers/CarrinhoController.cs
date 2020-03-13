using System.Threading.Tasks;
using Carrinho.Dados;
using Carrinho.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.Controllers
{
    public class CarrinhoController : Controller
    {
         private readonly CarrinhoContext _context;

        public CarrinhoController(){
            _context = new CarrinhoContext();
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.SetorId = new SelectList(_context.Setor, "Id", "Nome");
            var produtos = await _context.Produto.Include(p => p.Setor).ToListAsync();
            return View(produtos);
        }
        public async Task<IActionResult> Add(int? id, int? idCarrinho)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carrinho = await _context.Carrinho.FindAsync(idCarrinho);
            var produto = await _context.Produto.FindAsync(id);
            carrinho.ListaProdutos.Add(new CarrinhoProdutos(){Produto = produto});
            _context.Carrinho.Update(carrinho);
            await _context.SaveChangesAsync();
            if (produto == null)
            {
                return NotFound();
            }
            ViewBag.SetorId = new SelectList(_context.Setor, "Id", "Nome");
            var produtos = await _context.Produto.Include(p => p.Setor).ToListAsync();
            return View(produtos);
        }
    }
}