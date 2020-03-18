using System.Threading.Tasks;
using Carrinho.Dados;
using Carrinho.Models;

namespace Carrinho.DAO
{
    public class CarrinhoDAO
    {
        private CarrinhoContext _context;
        public CarrinhoDAO()
        {
            _context = new CarrinhoContext();
        }

        public async Task<CarrinhoCompras> getCarrinhoById(int? id) => await _context.Carrinho.FindAsync(id);
        public CarrinhoCompras NovoCarrinho(string estado) {
             var carrinho = _context.Add(new CarrinhoCompras(){EstadoCompra = estado});
             _context.SaveChanges();
            return carrinho.Entity;
        }
        public async void Update(CarrinhoCompras carrinho)
        {
            _context.Update(carrinho);
            await _context.SaveChangesAsync();
        }

        
    }
}