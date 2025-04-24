using API_ECommerce.DTO;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IProdutoRepository
    {
        //criando métodos baseado na teoria CRUD (Criar/cadastrar, Ler, Atualizar e Deletar)

        //Ler
        List<Produto> ListarTodos();

        //Recebe um identificador e retorna o produto correspondente
        Produto BuscarPorID(int id);

        //Criar/Cadastrar
        void Cadastrar(CadastrarProdutoDto produto);

        //Atualizar
        //Recebe um identificador para encontrar o produto e recebe o novo produto que ira substituir o antigo
        void Atualizar(int id, Produto produto);  
        
        //Deletar
        //Recebe o identificador do produto que será deletado
        void Deletar(int id);

    }
}
