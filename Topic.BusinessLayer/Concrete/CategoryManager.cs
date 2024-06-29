using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinessLayer.Abstract;
using Topic.DataAccessLayer.Abstract;
using Topic.EntityLayer.Entities;

namespace Topic.BusinessLayer.Concrete
{
	public class CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : GenericManager<Category>(genericDal), ICategoryService
	{
		private readonly ICategoryDal _categoryDal = categoryDal;

		public List<Category> TGetActiveCategories()
		{
			return _categoryDal.GetActiveCategories();
		}
	}
}
