using AutoMapper;
using Topic.DTOLayer.DTOs.CategoryDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mappings
{
	public class CategoryMapping : Profile
	{
		public CategoryMapping()
		{
			CreateMap<ResultCategoryDto, Category>().ReverseMap();
			CreateMap<CreateCategoryDto, Category>().ReverseMap();
			CreateMap<UpdateCategoryDto, Category>().ReverseMap();
		}
	}
}
