namespace WebApplicationproiect.Models
{
    public class SpecializareServiciu
    {
        public int ID { get; set; }
        public int SpecializareID { get; set; }
        public Specializare Specializare { get; set; }
        public int ServiciuID { get; set; }
        public Serviciu Serviciu { get; set; }
    }
}
