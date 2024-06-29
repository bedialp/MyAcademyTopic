using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.BlogDtos;

namespace Topic.WebUI.Controllers
{
	public class BlogController : Controller
	{
		private readonly HttpClient _client;

		public BlogController(HttpClient client)
		{
			client.BaseAddress = new Uri("https://localhost:7007/api/blogs/");
			_client = client;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetBlogsByCategory(int id)
		{
			var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>($"GetBlogsByCategoryId/{id}");
			return View(values);
		}

		public async Task<IActionResult> GetBlogDetails(int id)
		{
			var value = await _client.GetFromJsonAsync<ResultBlogDto>(id.ToString());
			return View(value);
		}
	}
}