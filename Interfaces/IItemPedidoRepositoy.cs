using API_ECommerce.DTO;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IItemPedidoRepository
    {
        //Ler
        List<ItemPedido> ListarTodos();
        ItemPedido BuscarPorId(int id);

        //Criar
        void Cadastrar(CadastrarItemPedidoDto itemPedido);

        //Atualizar
        void Atualizar(int id, ItemPedido itemPedido);

        //Deletar
        void Deletar(int id);
    }
}
