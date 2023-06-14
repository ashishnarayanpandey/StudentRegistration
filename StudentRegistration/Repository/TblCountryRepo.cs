using StudentRegistration.Interface;
using StudentRegistration.Models;

namespace StudentRegistration.Repository
{
    public class TblCountryRepo : ITblCountry
    {
        private readonly DatabaseContext _Context;

        public TblCountryRepo(DatabaseContext context)
        {
            _Context = context;
        }
        public void Delete(TblCountry tblCountries)
        {
            _Context.tblCountries.Remove(tblCountries);
        }

        public IEnumerable<TblCountry> GetAll()
        {
            var data =_Context.tblCountries.ToList();
            return data;
        }

        public TblCountry GetById(int id)
        {
            var data = _Context.tblCountries.Where(x=>x.CId== id).FirstOrDefault();
            return data;
        }

        public void Insert(TblCountry tblCountries)
        {
            _Context.tblCountries.Add(tblCountries);
        }

        public void saved()
        {
            _Context.SaveChanges();
        }

        public void Update(TblCountry tblCountries)
        {
            _Context.tblCountries.Update(tblCountries);
        }
    }
}
