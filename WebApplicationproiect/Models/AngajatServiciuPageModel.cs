using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationproiect.Data;
namespace WebApplicationproiect.Models
{
    public class AngajatServiciuPageModel:PageModel
    {
        public List<AssignedServiciuData> AssignedServiciuDataList;
        public void PopulateAssignedServiciuData(WebApplicationproiectContext context,
        Angajat angajat)
        {
            var allServicii = context.Serviciu;
            var angajatServicii = new HashSet<int>(
            angajat.AngajatServicii.Select(c => c.ServiciuID)); //
            AssignedSerbiciuDataList = new List<AssignedServiciuData>();
            foreach (var ser in allServicii)
            {
                AssignedServiciuDataList.Add(new AssignedServiciuData
                {
                    ServiciuID = ser.ID,
                    Name = ser.DenumireServiciu,
                    Assigned = angajatServicii.Contains(ser.ID)
                });
            }
        }
        public void UpdateAngajatServicii(WebApplicationproiectContext context,
        string[] selectedServicii, Angajat angajatToUpdate)
        {
            if (selectedServicii == null)
            {
                angajatToUpdate.AngajatServicii = new List<AngajatServiciu>();
                return;
            }
            var selectedServiciiHS = new HashSet<string>(selectedServicii);
            var angajatServicii = new HashSet<int>
            (angajatToUpdate.AngajatServicii.Select(c => c.Serviciu.ID));
            foreach (var ser in context.Serviciu)
            {
                if (selectedServiciiHS.Contains(ser.ID.ToString()))
                {
                    if (!angajatServicii.Contains(ser.ID))
                    {
                        angajatToUpdate.AngajatServicii.Add(
                        new AngajatServiciu
                        {
                            AngajatID = angajatToUpdate.ID,
                            ServiciuID = ser.ID
                        });
                    }
                }
                else
                {
                    if (angajatServicii.Contains(ser.ID))
                    {
                        angajatServiciu courseToRemove
                        = angajatToUpdate
                        .AngajatServicii
                        .SingleOrDefault(i => i.ServiciuID == ser.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
