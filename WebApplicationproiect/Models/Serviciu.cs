namespace WebApplicationproiect.Models
{
    public class Serviciu
    {
        public int ID { get; set; }
        public string NumeleServiciului { get; set; }

        public int Pret { get; set; }

        public ICollection<SpecializareServiciu>? SpecializareServicii { get; set; }
        public ICollection<AngajatServiciu>? AngajatServicii { get; set; }
    }
}
