using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace WebApplicationproiect.Models
{
    public class Programare
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? AngajatID { get; set; }
        public Angajat? Angajat { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Data Programarii")]
        public DateTime ReturnDate { get; set; }
    }
}
