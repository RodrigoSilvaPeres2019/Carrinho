using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrinho.Dados;
using Carrinho.Models;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.DAO
{
    public class SetorDAO
    {
        private CarrinhoContext _context;
        public SetorDAO()
        {
            _context = new CarrinhoContext();
        }

        public async Task<List<Setor>> Setores() => await _context.Setor.ToListAsync();

        public async Task<Setor> getSetorById(int? id) => await _context.Setor.FirstOrDefaultAsync(s => s.Id == id);

        public async void Update(Setor setor)
        {
            _context.Update(setor);
            await _context.SaveChangesAsync();
        }

        public async void Add(Setor setor)
        {
            _context.Add(setor);
            await _context.SaveChangesAsync();
        }

        public async void Remove(int id)
        {
            var setor = await _context.Setor.FindAsync(id);
            _context.Setor.Remove(setor);
            await _context.SaveChangesAsync();
        }

        public bool SetorExists(int id)
        {
            return _context.Setor.Any(s => s.Id == id);
        }




    }
}