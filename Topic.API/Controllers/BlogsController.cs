﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.DTOs.BlogDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogsController(IBlogService blogService, IMapper mapper) : ControllerBase
	{
		private readonly IBlogService _blogService = blogService;
		private readonly IMapper _mapper = mapper;

		[HttpGet]
		public IActionResult GetAllBlogs()
		{
			var values = _blogService.TGetBlogsWithCategories();
			var blogs = _mapper.Map<List<ResultBlogDto>>(values);
			return Ok(blogs);
		}

		[HttpGet("{id}")]
		public IActionResult GetBlogById(int id)
		{
			var value = _blogService.TGetById(id);
			var blog = _mapper.Map<ResultBlogDto>(value);
			return Ok(blog);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBlog(int id)
		{
			_blogService.TDelete(id);
			return Ok("Blog basariyla silindi.");
		}

		[HttpPost]
		public IActionResult CreateBlog(CreateBlogDto createBlogDto)
		{
			var blog = _mapper.Map<Blog>(createBlogDto);
			_blogService.TCreate(blog);
			return Ok("Blog basariyla olusturuldu.");
		}

		[HttpPut]
		public IActionResult UpdateBlog(UpdateBlogDto updateBlogDto)
		{
			var blog = _mapper.Map<Blog>(updateBlogDto);
			_blogService.TUpdate(blog);
			return Ok("Blog basariyla guncellendi.");
		}
	}
}