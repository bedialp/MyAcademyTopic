using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class BlogController : Controller
	{
		private readonly HttpClient _client;

		public BlogController(HttpClient client)
		{
			client.BaseAddress = new Uri("https://localhost:7007/api/blogs");
			_client = client;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs"); // Get all blogs from API and show them in the view page. 

			return View(values);
		}

		public async Task<IActionResult> DeleteBlog(int id)
		{
			await _client.DeleteAsync($"blogs/{id}"); // Delete the blog with the given id. 

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> CreateBlog()
		{
			var categoryList = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories"); // Get all categories from API and show them in the view page.
			List<SelectListItem> categories = (from x in categoryList
											   select new SelectListItem
											   {
												   Text = x.CategoryName,
												   Value = x.CategoryId.ToString()
											   }).ToList();
			ViewBag.Categories = categories;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
		{
			await _client.PostAsJsonAsync("blogs", createBlogDto); // Create a new blog with the given data. 

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateBlog(int id)
		{
			var categoryList = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories"); // Get all categories from API and show them in the view page.
			List<SelectListItem> categories = (from x in categoryList
											   select new SelectListItem
											   {
												   Text = x.CategoryName,
												   Value = x.CategoryId.ToString()
											   }).ToList();
			ViewBag.Categories = categories;

			var blog = await _client.GetFromJsonAsync<UpdateBlogDto>($"blogs/{id}"); // Get the blog with the given id. 

			return View(blog);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
		{
			await _client.PutAsJsonAsync("blogs", updateBlogDto); // Update the blog with the given data. 

			return RedirectToAction("Index");
		}
	}
}
