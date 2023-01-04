namespace WebApplicationproiect.Models
{
    public class AngajatServiciu
    {
        public int ID { get; set; }
        public int AngajatID { get; set; }
        public Angajat Angajat { get; set; }
        public int ServiciuID { get; set; }
        public Serviciu Serviciu{ get; set; }

    }
}
