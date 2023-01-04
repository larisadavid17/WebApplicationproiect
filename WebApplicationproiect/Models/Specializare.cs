namespace WebApplicationproiect.Models
{
	public class Specializare
	{
		public int ID { get; set; }
		public string DenumireSpecializare { get; set; }
		public ICollection<Angajat>? Angajati { get; set; }

        public ICollection<SpecializareServiciu>? SpecializareServicii { get; set; }
    }
}

