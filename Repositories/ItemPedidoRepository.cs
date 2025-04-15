using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {

        //Injetar o Context (banco de dados no código)
        private readonly EcommerceContext _context;

        //ctor - Método construtor
        public ItemPedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, ItemPedido itemPedido)
        {
            throw new NotImplementedException();
        }

        public ItemPedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ItemPedido itemPedido)
        {
            _context.ItemPedidos.Add(itemPedido);
            //salvar a alteração
            _context.SaveChanges();
        }
        
        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ItemPedido> ListarTodos()
        {
            return _context.ItemPedidos.ToList();
        }
    }
}
