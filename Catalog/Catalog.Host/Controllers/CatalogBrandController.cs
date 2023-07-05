using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Models.Dtos;
using Infrastructure;
using Infrastructure.Identity;
using Pipelines.Sockets.Unofficial.Buffers;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("catalog.catalogbrand")]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogBrandController : ControllerBase
    {
        private readonly ILogger<CatalogBrandController> _logger;
        private readonly ICatalogBrandService _catalogBrandService;

        public CatalogBrandController(ILogger<CatalogBrandController> logger, ICatalogBrandService catalogBrandService)
        {
            _logger = logger;
            _catalogBrandService = catalogBrandService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddOrUpdateDataResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(SetDataRequest brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _catalogBrandService.Add(brand.Name);
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

            var result = await _catalogBrandService.Remove(id);
            if (result == null)
            {
                _logger.LogInformation($"Brand with id {id} not found.");
                return NotFound(new { Message = $"Brand with id {id} not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("{id}")]
        [ProducesResponseType(typeof(AddOrUpdateDataResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(CatalogBrandDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _catalogBrandService.Update(request);
            if (result == null)
            {
                _logger.LogInformation($"Brand with id {request.Id} not found.");
                return NotFound(new { Message = $"Brand with id {request.Id} not found." });
            }

            return Ok(new AddOrUpdateDataResponse<int?>() { Id = result });
        }
    }
}
