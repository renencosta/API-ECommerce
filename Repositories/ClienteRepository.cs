using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        //Injetar o Context (banco de dados no código)
        private readonly EcommerceContext _context;

        //ctor - Método construtor
        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Cliente cliente)
        {
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            if (clienteEncontrado == null)
            {
                throw new Exception();
            }

            clienteEncontrado.NomeCompleto = cliente.NomeCompleto;
            clienteEncontrado.Email = cliente.Email;
            clienteEncontrado.Telefone = cliente.Telefone;
            clienteEncontrado.Endereco = cliente.Endereco;
            clienteEncontrado.DataCadastro = cliente.DataCadastro;
            clienteEncontrado.Pedidos = cliente.Pedidos;

            _context.SaveChanges();
        }

        public Cliente BuscarPorEmailSenha(string email, string senha)
        {
            return _context.Clientes.FirstOrDefault(cliente => cliente.Email == email);
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(cliente => cliente.IdCliente == id);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            //salvar a alteração
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            if (clienteEncontrado == null)
            {
                throw new Exception();
            }

            _context.Clientes.Remove(clienteEncontrado);
            _context.SaveChanges();
        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}
