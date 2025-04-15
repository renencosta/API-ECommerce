using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //No repositorio, ficam os métodos que acessam o banco de dados

        //Injetar o Context (banco de dados no código)
        private readonly EcommerceContext _context;

        //ctor - Método construtor
        public ProdutoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto BuscarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
           _context.Produtos.Add(produto);
            //salvar a alteração
           _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
