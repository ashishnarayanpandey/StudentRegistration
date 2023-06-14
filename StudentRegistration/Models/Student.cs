using Microsoft.CodeAnalysis.Operations;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }
        public string Student_Name { get; set; }
        public string School_Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Standard_Class { get; set; }
        public string Student_Image { get; set; }
        public int CId { get; set; }
        public int DId { get; set; }
        public int SId { get; set; }

    }
}
