using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _services;

        public CategoriesController(IServiceManager services)
        {
            _services = services;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync([FromQuery] BookParameters bookParameters)
        {
            return Ok(await _services
                .CategoryService
                .GetAllCategoriesAsync(false));
        }



        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryAsync([FromRoute(Name = "id")] int id)
        {
            return Ok(await _services
                .CategoryService
                .GetOneCategoryByIdAsync(id, false));

        }
    }
}
