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
	public class CategoriesController(ICategoryService categoryService, IMapper mapper) : ControllerBase // Kategori işlemleri için kullanılacak controller sınıfı.
	{
		private readonly ICategoryService _categoryService = categoryService; // Dependency Injection
		private readonly IMapper _mapper = mapper; // Dependency Injection

		[HttpGet]
		public IActionResult GetAllCategories()
		{
			var values = _categoryService.TGetList(); // Tüm kategoriler getiriliyor.
			var categories = _mapper.Map<List<ResultCategoryDto>>(values); // AutoMapper kullanarak dönüşüm yapılıyor.
			return Ok(categories);
		}

		[HttpGet("{id}")]
		public IActionResult GetCategoryById(int id) // Id'ye göre kategori getirme işlemi için HttpGet metodu kullanılıyor.
		{
			var value = _categoryService.TGetById(id); // Id'ye göre kategori getiriliyor.
			var category = _mapper.Map<ResultCategoryDto>(value); // AutoMapper kullanarak dönüşüm yapılıyor.
			return Ok(category);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id) // Silme işlemi için HttpDelete metodu kullanılıyor.
		{
			_categoryService.TDelete(id);
			return Ok("Kategori basariyla silindi.");
		}

		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto) // Oluşturma işlemi için HttpPost metodu kullanılıyor.
		{
			var category = _mapper.Map<Category>(createCategoryDto); // Dto'dan entity'e dönüşüm yapılıyor.
			_categoryService.TCreate(category);
			return Ok("Kategori basariyla olusturuldu.");
		}

		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto) // Güncelleme işlemi için HttpPut metodu kullanılıyor.
		{
			var category = _mapper.Map<Category>(updateCategoryDto); // Dto'dan entity'e dönüşüm yapılıyor.
			_categoryService.TUpdate(category);
			return Ok("Kategori basariyla guncellendi.");
		}

		[HttpGet("GetActiveCategories")]
		public IActionResult GetActiveCategories()
		{
			var values = _categoryService.TGetActiveCategories(); // Aktif kategoriler getiriliyor.
			/* TGetActiveCategories() <~~ Yeni Olusturdugumuz Metot ile Sade kod kullaniliyor. ~~~> TGetFilteredList(x => x.Status == true); */
			var categories = _mapper.Map<List<ResultCategoryDto>>(values); // AutoMapper kullanarak dönüşüm yapılıyor.
			return Ok(categories);
		}
	}
}
