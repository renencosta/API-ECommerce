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
            //Encontro o produto que desejo
            Produto produtoEncontrado = _context.Produtos.Find(id);

            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            produtoEncontrado.Nome = produto.Nome;  
            produtoEncontrado.Descricao = produto.Descricao;
            produtoEncontrado.Preco = produto.Preco;
            produtoEncontrado.CategoriaProduto = produto.CategoriaProduto;
            produtoEncontrado.Imagem = produto.Imagem;
            produtoEncontrado.EstoqueDisponivel = produto.EstoqueDisponivel;

            _context.SaveChanges();
             
        }

        public Produto BuscarPorID(int id)
        {
            //FirstOrDefault: traz o primeiro item que encontrar ou null, caso não ache nada//_context.Produtos - Acesse a tabela produto do contexto
            //FirstOrDefault - Pegue o primeiro que encontrar
            //(p=> p.IdProduto == id) - Para cada produto P, me retorne aquele que tem o IdProduto igual ao id
            return _context.Produtos.FirstOrDefault(p => p.IdProduto == id);
            
        }

        public void Cadastrar(Produto produto)
        {
           _context.Produtos.Add(produto);
            //salvar a alteração
           _context.SaveChanges();
        }
        
        public void Deletar(int id)
        {
            // 1 - encontrar o que sera excluido
            Produto produtoEncontrado = _context.Produtos.Find(id);

            //caso não encontre o id informado, gera erro
            if(produtoEncontrado == null)
            {
                throw new Exception();
            }

            //caso id encontrado, remove da tabela e salva a alteração
            _context.Produtos.Remove(produtoEncontrado);
            _context.SaveChanges();
           
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
