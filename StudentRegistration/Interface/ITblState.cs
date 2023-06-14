using StudentRegistration.Models;

namespace StudentRegistration.Interface
{
    public interface ITblState
    {
        IEnumerable<TblState> GetAll();
        TblState GetById (int id);  
        void Insert (TblState tblStates);
        void Update (TblState tblStates);
        void Delete (TblState tblStates);
        void saved();
    }
}
