using AppointmentCalendar.BLL.Entities;
using AppointmentCalendar.BLL.Models;
using AutoMapper;

namespace AppointmentCalendar.WebApp.Profiles
{
    public class UserViewProfile : Profile
    {
        public UserViewProfile()
        {
            CreateMap<User, UserView>()              
                //.ForMember(d => d.Director, o => o.MapFrom(s => $"{s.Director.FirstName} {s.Director.LastName}"))
                //.ForMember(d => d.GenreName, o => o.NullSubstitute("?"))
                //.ForMember(d => d.YearOfProduction, o => o.Ignore())
                ;
        }
    }
}
