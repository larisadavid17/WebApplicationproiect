using System.Security.Policy;

namespace WebApplicationproiect.Models
{
	public class Angajat
	{
		public int ID { get; set; }
		public string Nume { get; set; }
		public string Experienta { get; set; }

		public string Cursuri { get; set; }
		public int? SpecializareID { get; set; }
		public Specializare? Specializare { get; set; }

	}
}
