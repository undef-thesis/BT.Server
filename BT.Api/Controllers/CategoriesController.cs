using System.Threading.Tasks;
using BT.Application.Features.CategoryFeatures.Commands.AddCategory;
using BT.Application.Features.CategoryFeatures.Queries.GetCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BT.Api.Controllers
{
    [ApiVersion("1.0")]
    public class CategoriesController : ApiBaseController
    {
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>CategoriesDto</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await Execute(new GetCategoriesQuery());

            return Ok(categories);
        }

        //TODO Endpoint just for admin
        /// <summary>
        /// Create new category
        /// </summary>
        /// <param name="command">AddCategoryCommand</param> 
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AddCategoryCommand command)
        {
            await Execute(command);

            return Ok();
        }
    }
}