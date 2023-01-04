using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationproiect.Data;
namespace WebApplicationproiect.Models
{
    public class SpecializareServiciiPageModel:PageModel
    {
        public List<AssignedServiciuData> AssignedServiciuDataList;
        public void PopulateAssignedServiciuData(WebApplicationproiectContext context,
        Specializare specializare)
        {
            var allServicii = context.Serviciu;
            var specializareServicii = new HashSet<int>(
            specializare.SpecializareServicii.Select(c => c.ServiciuID)); //
            AssignedServiciuDataList = new List<AssignedServiciuData>();
            foreach (var ser in allServicii)
            {
                AssignedServiciuDataList.Add(new AssignedServiciuData
                {
                    ServiciuID = ser.ID,
                    Nume = ser.NumeleServiciului,
                    Assigned = specializareServicii.Contains(ser.ID)
                });
            }
        }
        public void UpdateSpecializareServicii(WebApplicationproiectContext context,
        string[] selectedServicii, Specializare specializareToUpdate)
        {
            if (selectedServicii == null)
            {
                specializareToUpdate.SpecializareServicii = new List<SpecializareServiciu>();
                return;
            }
            var selectedServiciiHS = new HashSet<string>(selectedServicii);
            var specializareServicii = new HashSet<int>
            (specializareToUpdate.SpecializareServicii.Select(c => c.Serviciu.ID));
            foreach (var ser in context.Serviciu)
            {
                if (selectedServiciiHS.Contains(ser.ID.ToString()))
                {
                    if (!specializareServicii.Contains(ser.ID))
                    {
                        specializareToUpdate.SpecializareServicii.Add(
                        new SpecializareServiciu
                        {
                            SpecializareID = specializareToUpdate.ID,
                            ServiciuID = ser.ID
                        });
                    }
                }
                else
                {
                    if (specializareServicii.Contains(ser.ID))
                    {
                        SpecializareServiciu courseToRemove
                        = specializareToUpdate
                        .SpecializareServicii
                        .SingleOrDefault(i => i.ServiciuID == ser.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }


    }
}
