﻿using API_ECommerce.Context;
using API_ECommerce.Interfaces;
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
    }
}
