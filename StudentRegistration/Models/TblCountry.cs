using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class TblCountry
    {
        [Key]
        public int CId { get; set; }
        public string CName { get; set; }
    }
}
