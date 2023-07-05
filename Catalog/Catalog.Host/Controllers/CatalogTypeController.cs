using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("catalog.catalogtype")]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogTypeController : ControllerBase
    {
        private readonly ILogger<CatalogTypeController> _logger;
        private readonly ICatalogTypeService _catalogTypeService;

        public CatalogTypeController(ILogger<CatalogTypeController> logger, ICatalogTypeService catalogTypeService)
        {
            _logger = logger;
            _catalogTypeService = catalogTypeService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddOrUpdateDataResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(SetDataRequest type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _catalogTypeService.Add(type.Name);
            return Ok(new AddOrUpdateDataResponse<int?>() { Id = result });
        }

        [HttpPost]
        [Route("{id}")]
        [ProducesResponseType(typeof(int?), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Remove(int id)
        {
            if (id < 0)
            {
                _logger.LogInformation("Id have to be > 0");
                return BadRequest();
            }

            var result = await _catalogTypeService.Remove(id);
            if (result == null)
            {
                _logger.LogInformation($"Type with id {id} not found.");
                return NotFound(new { Message = $"Type with id {id} not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("{id}")]
        [ProducesResponseType(typeof(AddOrUpdateDataResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(CatalogTypeDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _catalogTypeService.Update(request);

            if (result == null)
            {
                _logger.LogInformation($"Type with id {request.Id} not found.");
                return NotFound(new { Message = $"Type with id {request.Id} not found." });
            }

            return Ok(new AddOrUpdateDataResponse<int?>() { Id = result });
        }
    }
}
