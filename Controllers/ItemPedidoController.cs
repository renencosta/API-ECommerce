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
    public class ItemPedidoController : ControllerBase
    {
        
        private IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoController(IItemPedidoRepository itemPedidoRepository)
        {            
            _itemPedidoRepository = itemPedidoRepository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_itemPedidoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarItemPedidoDto item)
        {
            _itemPedidoRepository.Cadastrar(item);
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            ItemPedido item = _itemPedidoRepository.BuscarPorId(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _itemPedidoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Item não encontrado.");
            }
        }

        [HttpPut("{id}")]

        public IActionResult Editar(int id, ItemPedido item)
        {
            try
            {
                _itemPedidoRepository.Atualizar(id, item);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound("Item não encontrado.");
            }
        }

     
    }
}
