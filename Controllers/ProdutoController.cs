using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private IProdutoRepository _produtoRepository;

        //Injeção de Dependência
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // Listar - é um método GET 
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarProduto(Produto produto)
        {
            //1 - colocar o produto no banco de dados
            _produtoRepository.Cadastrar(produto);

            //2 - retorna resultado
            // codigo 201 -created
            return Created();
        }

        //Buscar produto por ID
        // /api/produtos/1
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Produto produto = _produtoRepository.BuscarPorID(id);

            if (produto == null)
            {
                //404 - NotFound
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Produto produto)
        {
            try
            {
                _produtoRepository.Atualizar(id, produto);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return NotFound("Produto não encontrado.");
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _produtoRepository.Deletar(id);
                return NoContent();
            }
            //caso de erro
            catch (Exception ex)
            {
                return NotFound("Produto não encontrado.");
            }
        }
        

    }
}
