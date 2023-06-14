using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class TblCity
    {
        [Key]
        public int DId { get; set; }
        public int SId { get; set; }
        public string DName { get; set; }
    }
}
