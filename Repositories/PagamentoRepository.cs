using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        //Injetar o Context (banco de dados no código)
        private readonly EcommerceContext _context;

        //ctor - Método construtor
        public PagamentoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Pagamento pagamento)
        {
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            pagamentoEncontrado.FormaPagamento = pagamento.FormaPagamento;
            pagamentoEncontrado.Status = pagamento.Status;
            pagamentoEncontrado.Data = pagamento.Data;

            _context.SaveChanges();

        }

        public Pagamento BuscarPorId(int id)
        {
            return _context.Pagamentos.FirstOrDefault(pagamento => pagamento.IdPagamento == id);
        }

        public void Cadastrar(CadastrarPagamentoDto pagamento)
        {
            Pagamento pagamentoCadastrado = new Pagamento
            {
                FormaPagamento = pagamento.FormaPagamento,
                Status = pagamento.Status,
                Data = pagamento.Data,
                IdPedido = pagamento.IdPedido
            };

            _context.Pagamentos.Add(pagamentoCadastrado);
            //salvar a alteração
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pagamentos.Remove(pagamentoEncontrado);
            _context.SaveChanges();
        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.Include(p => p.Pedido).ToList();
        }
    }
}
