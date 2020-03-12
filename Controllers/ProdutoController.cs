using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Carrinho.Dados;
using Carrinho.Models;
using Carrinho.DAO;

namespace Carrinho.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly CarrinhoContext _context;

        private readonly ProdutoDAO _produtoDAO;
        private readonly SetorDAO _setorDAO;
        public ProdutoController()
        {
            _context = new CarrinhoContext();
            _produtoDAO = new ProdutoDAO();
            _setorDAO = new SetorDAO();
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            return View(await _produtoDAO.Produtos());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoDAO.getProdutoById(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public async Task<IActionResult> CreateAsync()
        {   
            ViewBag.SetorId = new SelectList(await _setorDAO.Setores(), "Id", "Nome");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int SetorId,[Bind("Id,Nome,Preco,Descricao")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto = await _produtoDAO.Add(produto, SetorId);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoDAO.getProdutoById(id);

            ViewBag.SetorId = new SelectList(await _setorDAO.Setores(), "Id", "Nome", produto.Setor.Id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int SetorId,[Bind("Id,Nome,Preco,Descricao")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    produto = await _produtoDAO.Update(produto, SetorId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_produtoDAO.ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoDAO.getProdutoById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _produtoDAO.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
