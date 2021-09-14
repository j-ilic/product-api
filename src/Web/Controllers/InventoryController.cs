using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Application.Inventories.Commands;
using Products.Application.Inventories.Queries;
using Products.Application.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Web.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IMediator _mediator;

        public InventoryController(ILogger<InventoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new inventory with date, location and list of SGTIN-96 encoded tags
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/inventory
        ///     {
        ///       "inventoryId": "AFDS7373837KJD",
        ///       "inventoryLocation": "Zagreb",
        ///       "inventoryDate": "2021-09-14T22:00:08.759Z",
        ///       "tags": [
        ///         "307ABE3665404EC00F863485",
        ///         "301BC0A090A7264020DEEB5C"
        ///       ]
        ///     }
        ///
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>A newly created inventory</returns>
        /// <response code="201">Returns the newly created inventory</response>
        /// <response code="400">If the command is not valid or inventory with same Id already exists</response>  
        /// <response code="500">If unexpected error occurs</response> 
        [HttpPost]
        [ProducesResponseType(typeof(long), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateInventoryCommand command)
        {
            var res = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { Id = res }, res);
        }

        /// <summary>
        /// Returns a specified inventory
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/inventory/AFDS7373837KJD
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>A specified inventory</returns>
        /// <response code="200">Returns the specified inventory</response>
        /// <response code="404">If the specified inventory is not found</response>  
        /// <response code="500">If unexpected error occurs</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(InventoryQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _mediator.Send(new InventoryQuery(id)));
        }

        /// <summary>
        /// Returns the count of inventoried items grouped by a specific company
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/inventory/items-count/company?companyPrefix=983682&amp;skip=0&amp;take=25
        ///
        /// </remarks>
        /// <param name="companyPrefix"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns>The count of inventoried items grouped by a specific company</returns>
        /// <response code="200">Returns the count of inventoried items grouped by a specific company</response>
        /// <response code="500">If unexpected error occurs</response> 
        [HttpGet("items-count/company")]
        [ProducesResponseType(typeof(InventoriedItemsCountPerCompanyQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetInventoriedItemsCountPerCompany(string companyPrefix, int skip = 0, int take = 25)
        {
            var specification = new InventoriedItemsSpecification(companyPrefix);

            return Ok(await _mediator.Send(new InventoriedItemsCountPerCompanyQuery(specification, skip, take)));
        }

        /// <summary>
        /// Returns the count of inventoried items grouped by a specific product per day
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/inventory/items-count/product-per-day/719065/9765179?skip=0&amp;take=25
        ///
        /// </remarks>
        /// <param name="companyPrefix"></param>
        /// <param name="itemReference"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns>The count of inventoried items grouped by a specific product per day</returns>
        /// <response code="200">Returns the count of inventoried items grouped by a specific product per day</response>
        /// <response code="404">If inventoried items for specified product are not found</response>  
        /// <response code="500">If unexpected error occurs</response> 
        [HttpGet("items-count/product-per-day/{companyPrefix}/{itemReference}")]
        [ProducesResponseType(typeof(InventoriedItemsCountPerProductPerDayQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetInventoriedItemsCountForProductPerDay(string companyPrefix, string itemReference, int skip = 0, int take = 25)
        {
            return Ok(await _mediator.Send(new InventoriedItemsCountPerProductPerDayQuery(companyPrefix, itemReference, skip, take)));
        }

        /// <summary>
        /// Returns the count of inventoried items grouped by a specific product for a specific inventory
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     /api/inventory/items-count/inventory/product?companyPrefix=719065&amp;itemReference=9765179&amp;inventoryId=A32483JH&amp;skip=0&amp;take=25
        ///
        /// </remarks>
        /// <param name="companyPrefix"></param>
        /// <param name="itemReference"></param>
        /// <param name="inventoryId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns>The count of inventoried items grouped by a specific product for a specific inventory</returns>
        /// <response code="200">Returns the count of inventoried items grouped by a specific product for a specific inventory</response>
        /// <response code="500">If unexpected error occurs</response> 
        [HttpGet("items-count/inventory/product/")]
        [ProducesResponseType(typeof(InventoriedItemsCountPerProductPerInventoryQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetInventoriedItemsCountForProductForInventory(string companyPrefix, string itemReference, string inventoryId, int skip = 0, int take = 25)
        {
            var specification = new InventoriedItemsSpecification(companyPrefix, itemReference, inventoryId);

            return Ok(await _mediator.Send(new InventoriedItemsCountPerProductPerInventoryQuery(specification, skip, take)));
        }
    }
}
