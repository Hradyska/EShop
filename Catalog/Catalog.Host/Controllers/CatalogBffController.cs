using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Infrastructure.Identity;
using Catalog.Host.Configurations;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Models.Enums;
using Microsoft.Extensions.Options;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogBffController : ControllerBase
    {
        private readonly ILogger<CatalogBffController> _logger;
        private readonly ICatalogService _catalogService;
        private readonly IOptions<CatalogConfig> _config;
        public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        IOptions<CatalogConfig> config)
        {
            _logger = logger;
            _catalogService = catalogService;
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
        {
            var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters);
            if (result == null)
            {
                _logger.LogInformation($"List of Items not found.");
                return NotFound(new { Message = $"List of Items not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemsById(GetItemsRequest request)
        {
            var result = await _catalogService.GetCatalogItemsByIdAsync(request.Id);
            if (!result.Data.Any<CatalogItemDto>())
            {
                _logger.LogInformation($"Item with id {request.Id} not found.");
                return NotFound(new { Message = $"Item with id {request.Id} not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemsByBrand(GetItemsRequest request)
        {
            var result = await _catalogService.GetCatalogItemsByBrandAsync(request.Id);
            if (!result.Data.Any<CatalogItemDto>())
            {
                _logger.LogInformation($"Item with Brand.Id {request.Id} not found.");
                return NotFound(new { Message = $"Item with Brand.Id {request.Id} not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemsByType(GetItemsRequest request)
        {
            var result = await _catalogService.GetCatalogItemsByTypeAsync(request.Id);
            if (!result.Data.Any<CatalogItemDto>())
            {
                _logger.LogInformation($"Item with Type.Id {request.Id} not found.");
                return NotFound(new { Message = $"Item with Type.Id {request.Id} not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetResponse<CatalogBrandDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Brands()
        {
            var result = await _catalogService.GetCatalogBrandsAsync();
            if (!result.Data.Any<CatalogBrandDto>())
            {
                _logger.LogInformation($"List of Brands not found.");
                return NotFound(new { Message = $"List of Brands not found." });
            }

            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetResponse<CatalogTypeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Types()
        {
            var result = await _catalogService.GetCatalogTypesAsync();
            if (!result.Data.Any<CatalogTypeDto>())
            {
                _logger.LogInformation($"List of Types not found.");
                return NotFound(new { Message = $"List of Types not found." });
            }

            return Ok(result);
        }
    }
}
