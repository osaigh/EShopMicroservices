using AutoMapper;
using Basket.API.Entities;
using EventBus.Messages.Events;

namespace Basket.API.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<BasketCheckout,BasketCheckoutEvent>().ReverseMap();
        }
    }
}
