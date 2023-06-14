using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class TblState
    {
        [Key]
        public int SId { get; set; }
        public int CId { get; set; }
        public string SName { get; set; }
    }
}
