using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairVisitorApp.DAL;

namespace FairVisitorApp.BLL
{
   public class VisitorManager
    {
       VisitorDataAccess gateway = new VisitorDataAccess();
        internal bool Save(Model.Visitor aVisitor)
        {
            int result = gateway.Save(aVisitor);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal int GetLastId()
        {
            return gateway.GetLastId();
        }

        internal void InsertVisitorZone(int visitorId, int zoneId)
        {
            gateway.InsertVisitorZone(visitorId,zoneId);
        }

        internal List<Model.Visitor> GetVisitorByZoneId(int zoneId)
        {
            return gateway.GetVisitorByZoneId(zoneId);
        }

        internal List<Model.Visitor> GetAllVisitor()
        {
            return gateway.GetAllVisitors();
        }
    }
}
