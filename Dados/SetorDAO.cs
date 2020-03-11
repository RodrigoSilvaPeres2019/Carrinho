using System.Collections.Generic;
using System.Linq;
using Carrinho.Dados;
using Carrinho.Models;

namespace Carrinho.DAO
{
    public class SetorDAO
    {
        private readonly CarrinhoContext _context;
        public SetorDAO(CarrinhoContext context)
        {
            _context = context;
        }
        
        public List<Setor> Setores() => _context.Setor.ToList();

        public void Add(Setor setor){
            _context.Add(setor);
            _context.SaveChanges();
        }


      
    }
}