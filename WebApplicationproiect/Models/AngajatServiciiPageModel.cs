using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationproiect.Data;
namespace WebApplicationproiect.Models
{
    public class AngajatServiciiPageModel:PageModel
    {
        public List<AssignedServiciuData> AssignedServiciuDataList;
        public void PopulateAssignedServiciuData(WebApplicationproiectContext context,
        Angajat angajat)
        {
            var allServicii = context.Serviciu;
            var angajatServicii = new HashSet<int>(
            angajat.AngajatServicii.Select(c => c.ServiciuID)); //
            AssignedServiciuDataList = new List<AssignedServiciuData>();
            foreach (var cat in allServicii)
            {
                AssignedServiciuDataList.Add(new AssignedServiciuData
                {
                    ServiciuID = cat.ID,
                    Nume = cat.NumeleServiciului,
                    Assigned = angajatServicii.Contains(cat.ID)
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
            foreach (var cat in context.Serviciu)
            {
                if (selectedServiciiHS.Contains(cat.ID.ToString()))
                {
                    if (!angajatServicii.Contains(cat.ID))
                    {
                        angajatToUpdate.AngajatServicii.Add(
                        new AngajatServiciu
                        {
                            AngajatID = angajatToUpdate.ID,
                            ServiciuID = cat.ID
                        });
                    }
                }
                else
                {
                    if (angajatServicii.Contains(cat.ID))
                    {
                        AngajatServiciu courseToRemove
                        = angajatToUpdate
                        .AngajatServicii
                        .SingleOrDefault(i => i.ServiciuID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

