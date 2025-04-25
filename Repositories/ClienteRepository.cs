using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;

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
            clienteEncontrado.Senha = cliente.Senha;


            _context.SaveChanges();
        }

        public List<Cliente> BuscarClientePorNome(string nome)
        {
            var listaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();
            return listaClientes;
        }

        /// <summary>
        /// Acessa o Banco de dados e encontra o Cliente com email e senha fornecidos
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Um cliente ou nulo</returns>

        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            return _context.Clientes.FirstOrDefault(cliente => cliente.Email == email && cliente.Senha == senha);
        }

        public Cliente? BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(cliente => cliente.IdCliente == id);
        }

        public void Cadastrar(CadastrarClienteDto cliente)
        {
            Cliente clienteCadastrado = new Cliente
            {
                NomeCompleto = cliente.NomeCompleto,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco,
                Senha = cliente.Senha,
                DataCadastro = cliente.DataCadastro

            };          


            _context.Clientes.Add(clienteCadastrado);
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

        public List<ListarClienteViewodel> ListarTodos()
        {


            return _context.Clientes.OrderBy(c => c.NomeCompleto).Select(c => new ListarClienteViewodel
            {
                IdCliente = c.IdCliente,
                NomeCompleto = c.NomeCompleto,
                Email = c.Email,
                Endereco= c.Endereco,
                Telefone= c.Telefone
            }).ToList();
        }
    }
}
