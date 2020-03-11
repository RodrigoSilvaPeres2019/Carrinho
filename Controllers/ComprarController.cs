using System.Threading.Tasks;
using Carrinho.Dados;
using Carrinho.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.Controllers
{
    public class ComprarController : Controller
    {
         private readonly CarrinhoContext _context;

        public ComprarController(CarrinhoContext context){
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.SetorId = new SelectList(_context.Setor, "Id", "Nome");
            var produtos = await _context.Produto.Include(p => p.Setor).ToListAsync();
            return View(produtos);
        }
        public async Task<IActionResult> Comprar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carrinho = new CarrinhoCompras();
            var produto = await _context.Produto.FindAsync(id);
            carrinho.ListaProdutos.Add(new CarrinhoProdutos(){Produto = produto});
            _context.Compras.Add(carrinho);
            await _context.SaveChangesAsync();
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
    }
}