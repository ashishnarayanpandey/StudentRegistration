using StudentRegistration.Models;

namespace StudentRegistration.Interface
{
    public interface ITblCountry
    {
        IEnumerable<TblCountry> GetAll();
        TblCountry GetById(int id);
        void Insert (TblCountry tblCountries);
        void Update (TblCountry tblCountries);
        void Delete (TblCountry tblCountries);
        void saved();
    }
}
