using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairVisitorApp.DAL;
using FairVisitorApp.Model;

namespace FairVisitorApp.BLL
{
   public class ZoneManager
    {
       ZoneDataAccess gateway = new ZoneDataAccess();
        internal string Save(Model.Zone aZone)
        {
            Zone bZone = gateway.GetZoneByName(aZone.Name);
            if (bZone != null)
            {
                return "Zone Already Exiss !!!";
            }
            else
            {
                int result = gateway.Save(aZone);
                if (result > 0)
                {
                    return "Zone Saved Successfully";
                }
                else
                {
                    return "Failed to Save Zone";
                }
            }
            
        }

        internal List<Model.Zone> GetAllZone()
        {
            return gateway.GetAllZone();
        }

        internal List<Model.Zone> GetZoneWiseTotalVisitor()
        {
            return gateway.GetZoneWiseTotalVisitor();
        }
    }
}
