﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinessLayer.Abstract;
using Topic.DataAccessLayer.Abstract;
using Topic.EntityLayer.Entities;

namespace Topic.BusinessLayer.Concrete
{
	public class BlogManager(IGenericDal<Blog> genericDal, IBlogDal blogDal) : GenericManager<Blog>(genericDal), IBlogService
	{
		private readonly IBlogDal _blogDal = blogDal;

		public List<Blog> TGetBlogsByCategoryId(int id)
		{
			return _blogDal.GetBlogsByCategoryId(id);
		}

		public List<Blog> TGetBlogsWithCategories()
		{
			return _blogDal.GetBlogsWithCategories();
		}

		public Blog TGetBlogWithCategoryById(int id)
		{
			return _blogDal.GetBlogWithCategoryById(id);
		}
	}
}
