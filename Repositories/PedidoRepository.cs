using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        //Injetar o Context (banco de dados no código)
        private readonly EcommerceContext _context;

        //ctor - Método construtor
        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            //salvar a alteração
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos.ToList();
        }
    }
}
