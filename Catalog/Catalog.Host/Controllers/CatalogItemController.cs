using System.Net;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("catalog.catalogitem")]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogItemController : ControllerBase
    {
        private readonly ILogger<CatalogItemController> _logger;
        private readonly ICatalogItemService _catalogItemService;

        public CatalogItemController(
            ILogger<CatalogItemController> logger,
            ICatalogItemService catalogItemService)
        {
            _logger = logger;
            _catalogItemService = catalogItemService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddOrUpdateDataResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _catalogItemService.Add(request);
            return Ok(new AddOrUpdateDataResponse<int?>() { Id = result });
        }

        [HttpPost]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Remove(int id)
        {
            if (id < 0)
            {
                _logger.LogInformation("Id have to be > 0");
                return BadRequest();
            }

            var result = await _catalogItemService.Remove(id);
            if (result == null)
            {
                _logger.LogInformation($"Item with id {id} not found.");
                return NotFound(new { Message = $"Item with id {id} not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("{id}")]
        [ProducesResponseType(typeof(AddOrUpdateDataResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int id, CreateProductRequest request)
        {
            if (id < 0)
            {
                _logger.LogInformation("Id have to be > 0");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _catalogItemService.Update(id, request);
            if (result == null)
            {
                _logger.LogInformation($"Item with id {id} not found.");
                return NotFound(new { Message = $"Item with id {id} not found." });
            }

            return Ok(new AddOrUpdateDataResponse<int?>() { Id = result });
        }
    }
}
