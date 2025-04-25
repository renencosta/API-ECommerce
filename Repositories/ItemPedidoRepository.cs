using API_ECommerce.Context;
using API_ECommerce.DTO;
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
            ItemPedido itemEncontrado = _context.ItemPedidos.Find(id);

            if (itemEncontrado == null )
            {
                throw new Exception();
            }

            itemEncontrado.Quantidade = itemPedido.Quantidade;
            itemEncontrado.IdPedido = itemPedido.IdPedido;
            itemEncontrado.IdProduto = itemPedido.IdProduto;

            _context.SaveChanges();
        }

        public ItemPedido BuscarPorId(int id)
        {
            return _context.ItemPedidos.FirstOrDefault(i => i.IdItemPedido == id);
        }

        public void Cadastrar(CadastrarItemPedidoDto itemPedido)
        {
            ItemPedido item = new ItemPedido
            {
                IdPedido = itemPedido.IdPedido,
                IdProduto = itemPedido.IdProduto,
                Quantidade = itemPedido.Quantidade,
            };
        }
        
        public void Deletar(int id)
        {
            ItemPedido itemEncontrado = _context.ItemPedidos.Find(id);

            if(itemEncontrado == null)
            {
                throw new Exception();
            }

            _context.ItemPedidos.Remove(itemEncontrado);
            _context.SaveChanges();
        }

        public List<ItemPedido> ListarTodos()
        {
            return _context.ItemPedidos.ToList();
        }
    }
}
