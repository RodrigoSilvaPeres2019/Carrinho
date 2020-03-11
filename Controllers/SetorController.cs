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
    public class SetorController : Controller
    {
        private readonly CarrinhoContext _context;

        private readonly SetorDAO _setorDAO;

        public SetorController()
        {
            _context = new CarrinhoContext();
            _setorDAO = new SetorDAO();
        }

        // GET: Setor
        public async  Task<IActionResult> Index()
        {
            return View( await _setorDAO.Setores());
        }

        // GET: Setor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await _setorDAO.getSetorById(id);

            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }

        // GET: Setor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                _setorDAO.Add(setor);
                return RedirectToAction(nameof(Index));
            }
            return View(setor);
        }

        // GET: Setor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await _setorDAO.getSetorById(id);
            if (setor == null)
            {
                return NotFound();
            }
            return View(setor);
        }

        // POST: Setor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome")] Setor setor)
        {
            if (id != setor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                 _setorDAO.Update(setor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_setorDAO.SetorExists(setor.Id))
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
            return View(setor);
        }

        // GET: Setor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await _setorDAO.getSetorById(id);;
            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }

        // POST: Setor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _setorDAO.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
