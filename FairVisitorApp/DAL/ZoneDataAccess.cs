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
    public class ZoneDataAccess
    {

        private string connectionString =
            ConfigurationManager.ConnectionStrings["fairVisitorConnectionString"].ConnectionString;
        internal int Save(Model.Zone aZone)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO ZoneTbl Values('" + aZone.Name + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int affectedRow = command.ExecuteNonQuery();
            connection.Close();
            return affectedRow;
        }

        internal List<Model.Zone> GetAllZone()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM ZoneTbl";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Zone> zoneList = new List<Zone>();
            while (reader.Read())
            {
                Zone aZone = new Zone();
                aZone.Id = int.Parse(reader[0].ToString());
                aZone.Name = reader[1].ToString();
                zoneList.Add(aZone);
            }
            reader.Close();
            connection.Close();
            return zoneList;
        }

        internal List<Zone> GetZoneWiseTotalVisitor()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM ZoneWiseCount";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Zone> zoneList = new List<Zone>();
            while (reader.Read())
            {
                Zone aZone = new Zone();
                aZone.Name = reader["Zone"].ToString();
                aZone.NumberOfVisitor = int.Parse(reader["Number OF Visitor"].ToString());
                zoneList.Add(aZone);
            }
            reader.Close();
            connection.Close();
            return zoneList;
        }

        internal Zone GetZoneByName(string ZoneName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM ZoneTbl WHERE Zone = '" + ZoneName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Zone zone = null;
            while (reader.Read())
            {
                zone = new Zone();
                zone.Id = int.Parse(reader[0].ToString());
                zone.Name = reader[1].ToString();

            }
            reader.Close();
            connection.Close();
            return zone;
        }
    }
}
