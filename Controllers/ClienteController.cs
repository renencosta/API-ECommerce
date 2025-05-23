﻿using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using API_ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;


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
        [Authorize]
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

        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            var cliente = _clienteRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (cliente == null)
            {
                return Unauthorized("Email ou senha invávildos.");
            }
            var tokenService = new TokenService();

            var token = tokenService.GenerateToken(cliente.Email);

            return Ok(token);
        }

        [HttpGet("/buscar/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(_clienteRepository.BuscarClientePorNome(nome));
        }

    }

}
