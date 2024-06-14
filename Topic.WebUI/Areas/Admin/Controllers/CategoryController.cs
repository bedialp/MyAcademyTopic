using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class CategoryController : Controller
	{
		private readonly HttpClient _client;

		public CategoryController(HttpClient client) // HttpClient is used to send HTTP requests and receive HTTP responses from a URL.
		{
			_client = client;
		}

		public async Task<IActionResult> Index()
		{
			var jsonData = await _client.GetAsync("https://localhost:44300/api/category"); // API URL for Category Controller in Topic.WebAPI project is used here. 
			//if (responseMessage.IsSuccessStatusCode) // If the response message is successful, the JSON data is read from the response message.
			//{
			//	var jsonData = await responseMessage.Content.ReadAsStringAsync(); // JSON data is read from the response message.
			//	var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); // JSON data is deserialized into a list of ResultCategoryDto objects.
			//	return View(values);
			//}
			return View();
		}

		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var category = JsonConvert.SerializeObject(createCategoryDto); // CreateCategoryDto object is serialized into JSON data.
			var stringContent = new StringContent(category, Encoding.UTF8, "application/json"); // JSON data is converted into a string content.
			var responseMessage = await _client.PostAsync("https://localhost:44300/api/category", stringContent); // API URL for Category Controller in Topic.WebAPI project is used here.
			if (responseMessage.IsSuccessStatusCode) // If the response message is successful, the user is redirected to the Index action method.
			{
				return RedirectToAction("Index");
			}
			return View(createCategoryDto);
		}


		public async Task<IActionResult> DeleteCategory(int id)
		{
			var responseMessage = await _client.DeleteAsync("https://localhost:44300/api/category/" + id); // API URL for Category Controller in Topic.WebAPI project is used here.
			if (responseMessage.IsSuccessStatusCode) // If the response message is successful, the user is redirected to the Index action method.
			{
				return RedirectToAction("Index");
			}
			return View("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var responseMessage = await _client.GetAsync("https://localhost:44300/api/category/" + id); 
			if (responseMessage.IsSuccessStatusCode) 
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync(); 
				var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData); // JSON data is deserialized into a ResultCategoryDto object.
				return View(values);
			}
			return View("Index");
		}
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var category = JsonConvert.SerializeObject(updateCategoryDto); 
			var stringContent = new StringContent(category, Encoding.UTF8, "application/json"); 
			var responseMessage = await _client.PutAsync("https://localhost:44300/api/category", stringContent); 
			if (responseMessage.IsSuccessStatusCode) 
			{
				return RedirectToAction("Index");
			}
			return View(updateCategoryDto);
		}
	}
}
