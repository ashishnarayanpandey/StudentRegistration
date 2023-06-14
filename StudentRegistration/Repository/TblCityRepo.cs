using StudentRegistration.Interface;
using StudentRegistration.Models;

namespace StudentRegistration.Repository
{
    public class TblCityRepo : ITblCity
    {
        private readonly DatabaseContext _Context;

        public TblCityRepo(DatabaseContext context)
        {
            _Context = context;
        }
        public void Delete(TblCity tblCities)
        {
            _Context.tblCities.Remove(tblCities);
        }

        public IEnumerable<TblCity> GetAll()
        {
            var data = _Context.tblCities.ToList();
            return data;
        }

        public TblCity GetById(int id)
        {
            var data =_Context.tblCities.Where(x=>x.DId==id).FirstOrDefault();
            return data;
        }

        public void Insert(TblCity tblCities)
        {
            _Context.tblCities.Add(tblCities);
        }

        public void saved()
        {
            _Context.SaveChanges();
        }

        public void Update(TblCity tblCities)
        {
            _Context.tblCities.Update(tblCities);
        }
    }
}
