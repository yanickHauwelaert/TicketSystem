using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TicketSystem.API.DTOs.Category;
using TicketSystem.Core.Entities;
using TicketSystem.Core.Services.Interfaces;

namespace TicketSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        protected readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetALlCategories();
            var categoryDto = categories.Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name
            });

            return Ok(categoryDto);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
                return NotFound($"Category with id: {id} was not found");

            var categoryDto = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(categoryDto);
        }

        [HttpPost]
        [Authorize(Policy = "CanEdit")]
        public async Task<IActionResult> Add(CategoryResponseDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var category = new Category
            {
                Name = categoryDto.Name
            };

            await _categoryService.AddCategory(category);
            return Ok(category);

        }

        [HttpPut]
        [Authorize(Policy = "CanUpdate")]
        public async Task<IActionResult> Update(CategoryResponseDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var category = await _categoryService.GetCategoryById(categoryDto.Id);
            if (category == null)
                return BadRequest("Category you try do update does not exist");

            category.Name = categoryDto.Name;

            await _categoryService.UpdateCategory(category);
            return Ok(category);
        }

        [HttpDelete("id")]
        [Authorize(Policy = "CanDelete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
                return BadRequest("The category you try do delete does not exist");

            await _categoryService.DeleteCategory(category);
            return Ok(category);
        }
    }
}
