using API_ECommerce.DTO;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IPedidoRepository
    {
        //Ler
        List<Pedido> ListarTodos();
        Pedido BuscarPorId(int id);

        //Criar
        void Cadastrar(CadastrarPedidoDto pedido);

        //Atualizar
        void Atualizar(int id, Pedido pedido);

        //Deletar
        void Deletar(int id);
    }
}
