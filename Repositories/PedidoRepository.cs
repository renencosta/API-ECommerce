using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

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

        public void Cadastrar(CadastrarPedidoDto pedidoDto)
        {
            //criar variavel pedido para guardar as informacoes do pedido
            var pedido = new Pedido
            {
                DataPedido = pedidoDto.DataPedido,
                Status = pedidoDto.Status,
                IdCliente = pedidoDto.IdCliente,
                ValorTotal = pedidoDto.ValorTotal
            };

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            //Cadastrar os itensPedido
            //Para cada PRODUTO, se cria um ItemPedido

            for (int i = 0; i < pedidoDto.Produtos.Count; i++)
            {
                //encontrando o produto
                var produto = _context.Produtos.Find(pedidoDto.Produtos[i]);

                //TODO: Lançar erro de produto não existe

                //crio uma variavel itemPedido
                var itemPedido = new ItemPedido
                {
                    IdPedido = pedido.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 0
                };

                //Adicionando ao banco de dados e salvando
                _context.ItemPedidos.Add(itemPedido);
                _context.SaveChanges();
            }
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
