using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairVisitorApp.Model;

namespace FairVisitorApp.DAL
{
  public class VisitorDataAccess
    {

      private string connectionString =
           ConfigurationManager.ConnectionStrings["fairVisitorConnectionString"].ConnectionString;
        internal int Save(Model.Visitor aVisitor)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO VisitorTbl Values('" + aVisitor.Id + "','" + aVisitor.Name + "','" + aVisitor.Email + "','" + aVisitor.ContactNumber + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int affectedRow = command.ExecuteNonQuery();
            connection.Close();
            return affectedRow;
        }

        internal int GetLastId()
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT ID FROM VisitorTbl ORDER BY ID desc";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
           Object id = command.ExecuteScalar();
           if (id != null)
            {
                result = (int)id;
            }
            connection.Close();
            return result;
        }

        internal void InsertVisitorZone(int visitorId, int zoneId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO ZoneVisitorTbl Values('" + visitorId + "','" + zoneId + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            
        }

        internal List<Model.Visitor> GetVisitorByZoneId(int zoneId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT VisitorTbl.ID,VisitorTbl.Name,VisitorTbl.Email,VisitorTbl.Contact FROM VisitorTbl,ZoneVisitorTbl WHERE VisitorTbl.ID = ZoneVisitorTbl.VisitorId AND ZoneVisitorTbl.ZoneId = '" + zoneId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Visitor> visitorList = new List<Visitor>();
            while (reader.Read())
            {
                Visitor aVisitor = new Visitor();
                aVisitor.Id = int.Parse(reader[0].ToString());
                aVisitor.Name = reader[1].ToString();
                aVisitor.Email = reader[2].ToString();
                aVisitor.ContactNumber = reader[3].ToString();
                visitorList.Add(aVisitor);
            }
            reader.Close();
            connection.Close();
            return visitorList;
        }

        internal List<Visitor> GetAllVisitors()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM VisitorTbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Visitor> visitorList = new List<Visitor>();
            while (reader.Read())
            {
                Visitor aVisitor = new Visitor();
                aVisitor.Id = int.Parse(reader[0].ToString());
                aVisitor.Name = reader[1].ToString();
                aVisitor.Email = reader[2].ToString();
                aVisitor.ContactNumber = reader[3].ToString();
                visitorList.Add(aVisitor);
            }
            reader.Close();
            connection.Close();
            return visitorList;
        }
    }
}
