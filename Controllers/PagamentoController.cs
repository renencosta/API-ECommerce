using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_ECommerce.Repositories;
using API_ECommerce.Models;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        
        private IPagamentoRepository _pagamentoRepository;

        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_pagamentoRepository.ListarTodos());  
        }

        [HttpPost]
        public IActionResult CadastrarPagamento(Pagamento pagamento)
        {
            _pagamentoRepository.Cadastrar(pagamento);
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Pagamento pagamento = _pagamentoRepository.BuscarPorId(id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return Ok(pagamento);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _pagamentoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Pagamento não encontrado.");
            }
        }

    }
}
