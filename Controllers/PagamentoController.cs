﻿using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IPagamentoRepository _pagamentoRepository;

        public PagamentoController(EcommerceContext context)
        {
            _context = context;
            _pagamentoRepository = new pagamentoRepository(_context);
        }
    }
}
