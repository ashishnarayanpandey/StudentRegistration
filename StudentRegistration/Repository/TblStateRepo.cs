using StudentRegistration.Interface;
using StudentRegistration.Models;

namespace StudentRegistration.Repository
{
    public class TblStateRepo : ITblState
    {
        private readonly DatabaseContext _Context;

        public TblStateRepo(DatabaseContext context)
        {
            _Context = context;
        }
        public void Delete(TblState tblStates)
        {
            _Context.tblStates.Remove(tblStates);
        }

        public IEnumerable<TblState> GetAll()
        {
            var data = _Context.tblStates.ToList();
            return data;
        }

        public TblState GetById(int id)
        {
            var data = _Context.tblStates.Where(x => x.SId == id).FirstOrDefault();
            return data;
        }

        public void Insert(TblState tblStates)
        {
            _Context.tblStates.Add(tblStates);
        }

        public void saved()
        {
            _Context.SaveChanges();
        }

        public void Update(TblState tblStates)
        {
             _Context.tblStates.Update(tblStates);
        }
    }
}
