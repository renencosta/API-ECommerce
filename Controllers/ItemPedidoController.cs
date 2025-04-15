using API_ECommerce.Context;
using API_ECommerce.Interfaces;
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
        
    }
}
