using StudentRegistration.Models;

namespace StudentRegistration.Interface
{
    public interface ITblCity
    {
        IEnumerable<TblCity> GetAll();
        TblCity GetById (int id);
        void Insert (TblCity tblCities);
        void Update (TblCity tblCities);
        void Delete (TblCity tblCities);
        void saved();
    }
}
