﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccessLayer.Abstract;
using Topic.DataAccessLayer.Context;
using Topic.DataAccessLayer.Repositories;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccessLayer.Concrete
{
	public class EFBlogDal(TopicContext context) : GenericRepository<Blog>(context), IBlogDal
	{
		public List<Blog> GetBlogsByCategoryId(int id)
		{
			return [.. _context.Blogs.Where(x => x.CategoryId == id)];
		}

		public List<Blog> GetBlogsWithCategories()
		{
			return [.. _context.Blogs.Include(x => x.Category)];
		}

		public Blog GetBlogWithCategoryById(int id)
		{
			return _context.Blogs.Include(x => x.Category).FirstOrDefault(x => x.BlogId == id);
		}
	}
}
