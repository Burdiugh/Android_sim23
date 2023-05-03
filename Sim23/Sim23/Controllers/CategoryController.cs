using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sim23.Data.Entities;
using Sim23.Data;
using Sim23.Helpers;
using Sim23.Models;
using Microsoft.EntityFrameworkCore;

namespace Sim23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppEFContext _appEFContext;

        public CategoriesController(IMapper mapper, AppEFContext appEFContext)
        {
            _mapper = mapper;
            _appEFContext = appEFContext;
        }
        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var model = await _appEFContext.Categories
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Priority)
                .Select(x => _mapper.Map<CategoryVM>(x))
                .ToListAsync();
            return Ok(model);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateVM model) 
        {
            try
            {
                var category = _mapper.Map<CategoryEntity>(model);
                category.Image = ImageWorker.SaveImage(model.ImageBase64);
                await _appEFContext.Categories.AddAsync(category);
                await _appEFContext.SaveChangesAsync();
                return Ok(_mapper.Map<CategoryVM>(category));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put([FromBody] CategoryUpdateItemVM model)
        {
            var cat = await _appEFContext.Categories.FindAsync(model.Id);
            if (cat == null)
                return NotFound();
            else
            {
                cat.Name = model.Name;
                cat.Description = model.Description;
                cat.Priority = model.Priority;
                ImageWorker.RemoveImage(cat.Image);
                cat.Image = ImageWorker.SaveImage(model.ImageBase64);
                _appEFContext.Update(cat);
                _appEFContext.SaveChanges();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _appEFContext.Categories.FindAsync(id);
            if (category is null)
                return NotFound();
            else
            {
                category.IsDeleted = true;
                _appEFContext.SaveChanges();
                return Ok();
            }
        }
    }
}
