using AutoMapper;
using StudentRegistration.ViewModel;

namespace StudentRegistration.Models
{
    public class EmpProfile:Profile
    {
        public EmpProfile()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<TblCountry, TblCountryViewModel>();
            CreateMap<TblState, TblStateViewModel>();
            CreateMap<TblCity, TblCityViewModel>();
        }
    }
}
