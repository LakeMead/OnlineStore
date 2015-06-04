namespace OnlineStore.Web.Models.ViewModels.Administration_Orders
{
    using AutoMapper;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class CustomerInfoViewModel : IMapFrom<CustomerInfo>, IHaveCustomMappings
    {
        public string FistName { get; set; }

        public string LastName { get; set; }

        public string CityName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CustomerInfo, CustomerInfoViewModel>()
                .ForMember(m => m.CityName, opt => opt.MapFrom(e => e.Address.City.Name));
        }
    }
}
