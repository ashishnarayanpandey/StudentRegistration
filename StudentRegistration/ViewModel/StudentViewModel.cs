using StudentRegistration.Models;
using System.ComponentModel;

namespace StudentRegistration.ViewModel
{
    public class StudentViewModel
    {
        public int Student_Id { get; set; }
        public string Student_Name { get; set; }
        public string School_Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Standard_Class { get; set; }
        public string Student_Image { get; set; }
        [DisplayName("Country")]
        public int CId { get; set; }
        [DisplayName("State")]
        public int DId { get; set; }
        [DisplayName("City")]
        public int SId { get; set; }
        public List<StudentViewModel> ListStudents { get; set; }
        public List<TblCountryViewModel> tblCountries { get; set; }
        public List<TblStateViewModel> tblStates { get; set; }
        public List<TblCityViewModel> tblCities { get; set; }
    }
}
