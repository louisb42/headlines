using AutoMapper;

using Headline.API.RequestModels;
using Headline.Common.Models;

namespace Headline.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateHeadlineRequest, HeadlineModel>();
            CreateMap<UpdateHeadlineRequest, HeadlineModel>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null)
                            return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string) prop))
                            return false;

                        return true;
                    }
                ));
        }
    }
}
