using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrinho.Dados;
using Carrinho.Models;
using Microsoft.EntityFrameworkCore;

namespace Carrinho.DAO
{
    public class ProdutoDAO
    {
        private CarrinhoContext _context;
        public ProdutoDAO()
        {
            _context = new CarrinhoContext();
        }

        public async Task<List<Produto>> Produtos() => await _context.Produto.Include(p => p.Setor).ToListAsync();

        public async Task<Produto> getProdutoById(int? id) => await _context.Produto.Include(p => p.Setor).FirstOrDefaultAsync(s => s.Id == id);

        public async Task<Produto> Update(Produto produto, int setorId)
        {
            produto.Setor = await _context.Setor.FindAsync(setorId);
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return produto;

        }

        public async Task<Produto> Add(Produto produto, int setorId)
        {
            produto.Setor = await _context.Setor.FindAsync(setorId);
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return produto;

        }

        public async void Remove(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public bool ProdutoExists(int id)
        {
            return _context.Produto.Any(s => s.Id == id);
        }
    }
}