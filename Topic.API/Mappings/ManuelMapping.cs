using AutoMapper;
using Topic.DTOLayer.DTOs.ManuelDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mappings
{
	public class ManuelMapping : Profile
	{
		public ManuelMapping()
		{
			CreateMap<CreateManuelDto, Manuel>().ReverseMap();
			CreateMap<UpdateManuelDto, Manuel>().ReverseMap();
		}
	}
}
