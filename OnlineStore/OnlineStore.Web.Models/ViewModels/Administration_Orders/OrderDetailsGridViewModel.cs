namespace OnlineStore.Web.Models.ViewModels.Administration_Orders
{
    using System.Linq;

    using AutoMapper;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class OrderDetailsGridViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string FistName { get; set; }

        public string LastName { get; set; }

        public string CityName { get; set; }

        public int ProductCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Order, OrderDetailsGridViewModel>()
                .ForMember(m => m.CityName, opt => opt.MapFrom(e => e.CustomerInfo.Address.City.Name))
                .ForMember(m => m.FistName, opt => opt.MapFrom(e => e.CustomerInfo.FirstName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(e => e.CustomerInfo.LastName))
                .ForMember(m => m.ProductCount, opt => opt.MapFrom(e => e.OrderDetails.Count));
        }
    }
}
