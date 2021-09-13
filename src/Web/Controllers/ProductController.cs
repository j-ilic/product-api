﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Application.Products.Commands;
using Products.Application.Products.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new product definition
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/product
        ///     {
        ///        "companyPrefix": "086906",
        ///        "companyName": "Blanda-Hagenes",
        ///        "itemReference": "1437603",
        ///        "productName": "Pasta - Penne, Rigate, Dry"
        ///     }
        ///
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>A newly created product definition</returns>
        /// <response code="201">Returns the newly created product definition</response>
        /// <response code="400">If the command is not valid</response>  
        /// <response code="500">If unexpected error occurs</response> 
        [HttpPost]
        [ProducesResponseType(typeof(long), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var res = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { Id = res }, res);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _mediator.Send(new ProductQuery(id)));
        }
    }
}
