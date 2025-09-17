using System.ComponentModel.DataAnnotations;

namespace DBCommunicationADONET.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int? Age { get; set; }

        // [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
