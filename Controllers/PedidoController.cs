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
    public class PedidoController : ControllerBase
    {
        
        private IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_pedidoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarPedido(CadastrarPedidoDto pedido)
        {
            _pedidoRepository.Cadastrar(pedido);
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Pedido pedido = _pedidoRepository.BuscarPorId(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _pedidoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Pedido não encontrado.");
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Pedido pedido)
        {
            try
            {
                _pedidoRepository.Atualizar(id, pedido);
                return Ok(pedido);
            }
            catch (Exception e)
            {
                return NotFound("Pedido não encontrado.");
            }
        }
    }
}
