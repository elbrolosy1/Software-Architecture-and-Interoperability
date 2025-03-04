using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using task1.Data;
using task1.Models;

namespace task1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public CategoryController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[SwaggerOperation(Summary = "Get All Categories", Description = "Retrieves a list of all categories.")]
		public ActionResult GetAll()
		{
			return Ok(_context.Categories.ToList());
		}

		[HttpPost]
		[SwaggerOperation(Summary = "Create a new category", Description = "Adds a new category to the database.")]
		public IActionResult Create([FromBody] Categories category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetById),
				new { id = category.Id },
				new { message = "Successfully created" });
		}

		[HttpGet("{id}")]
		[SwaggerOperation(Summary = "Get Category by ID", Description = "Retrieves a single category by its ID.")]
		public IActionResult GetById(int id)
		{
			var category = _context.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}
			return Ok(category);
		}

		[HttpDelete("{id}")]
		[SwaggerOperation(Summary = "Delete a category", Description = "Deletes a category based on the given ID.")]
		public IActionResult Delete(int id)
		{
			var category = _context.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}
			_context.Categories.Remove(category);
			_context.SaveChanges();
			return Ok(new { message = "Successfully deleted" });
		}

		[HttpPut("{id}")]
		[SwaggerOperation(Summary = "Update a category", Description = "Updates an existing category's details.")]
		public IActionResult Update(int id, [FromBody] Categories category)
		{
			var existingCategory = _context.Categories.Find(id);
			if (existingCategory == null)
			{
				return NotFound();
			}
			existingCategory.Name = category.Name;
			_context.Categories.Update(existingCategory);
			_context.SaveChanges();
			return Ok(new { message = "Successfully updated" });
		}
	}
}
