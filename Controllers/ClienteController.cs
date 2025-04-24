using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarCliente(CadastrarClienteDto cliente)
        {
            _clienteRepository.Cadastrar(cliente);
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarporId(int id)
        {
            Cliente cliente = _clienteRepository.BuscarPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Cliente cliente)
        {
            try
            {
                _clienteRepository.Atualizar(id, cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound("Cliente não encontrado.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _clienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Cliente não encontrado.");
            }
        }

        [HttpGet("{email}/{senha}")]
        public IActionResult Login(string email, string senha)
        {
            var cliente = _clienteRepository.BuscarPorEmailSenha(email, senha);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpGet("/buscar/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(_clienteRepository.BuscarClientePorNome(nome));
        }
    }

}
