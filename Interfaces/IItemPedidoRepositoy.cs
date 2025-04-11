using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IItemPedidoRepository
    {
        //Ler
        List<ItemPedido> ListarTodos();
        ItemPedido BuscarPorId(int id);

        //Criar
        void Cadastrar(ItemPedido itemPedido);

        //Atualizar
        void Atualizar(int id, ItemPedido itemPedido);

        //Deletar
        void Deletar(int id);
    }
}
