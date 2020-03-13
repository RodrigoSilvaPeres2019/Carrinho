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

        public async void EfetuarCompra(Produto produto, int setorId){

        }

        
    }
}