using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IClienteRepository
    {   
        //Ler
        List<Cliente> ListarTodos();
        Cliente BuscarPorId(int id);
        Cliente BuscarPorEmailSenha (string email, string senha);
        
        //Criar
        void Cadastrar(Cliente cliente);

        //Atualizar
        void Atualizar(int id, Cliente cliente);

        //Deletar
        void Deletar (int id);
    }
}
