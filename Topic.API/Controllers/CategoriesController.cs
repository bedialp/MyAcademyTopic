using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.DTOs.CategoryDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController(ICategoryService categoryService, IMapper mapper) : ControllerBase
	{
		private readonly ICategoryService _categoryService = categoryService;
		private readonly IMapper _mapper = mapper;

		[HttpGet]
		public IActionResult GetAllCategories()
		{
			var values = _categoryService.TGetList();
			var categories = _mapper.Map<List<ResultCategoryDto>>(values);
			return Ok(categories);
		}

		[HttpGet("{id}")]
		public IActionResult GetCategoryById(int id)
		{
			var value = _categoryService.TGetById(id);
			var category = _mapper.Map<ResultCategoryDto>(value);
			return Ok(category);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id)
		{
			_categoryService.TDelete(id);
			return Ok("Kategori basariyla silindi.");
		}

		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var category = _mapper.Map<Category>(createCategoryDto);
			_categoryService.TCreate(category);
			return Ok("Kategori basariyla olusturuldu.");
		}

		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var category = _mapper.Map<Category>(updateCategoryDto);
			_categoryService.TUpdate(category);
			return Ok("Kategori basariyla guncellendi.");
		}
	}
}
