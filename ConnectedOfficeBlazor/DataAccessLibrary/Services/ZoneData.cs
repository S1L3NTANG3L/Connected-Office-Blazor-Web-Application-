using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class ZoneData : IZoneData
	{
        //Data access code
		private readonly ISqlDataAccess _db;
		public ZoneData(ISqlDataAccess db)
		{
			_db = db;
		}
        //Get all zones
		public Task<List<ZoneModel>> GetZones()
		{
			string sql = "SELECT * FROM dbo.Zone;";
			return _db.LoadData<ZoneModel, dynamic>(sql, new { });
		}
        //Get single instance of zone
        public Task<ZoneModel> GetZoneById(Guid zoneId)
        {
            var parameters = new { ZoneId = zoneId };
            string sql = "SELECT * FROM dbo.Zone WHERE ZoneID = @ZoneId;";
            return _db.LoadSingle<ZoneModel, dynamic>(sql, parameters);
        }
        //Add new zone
        public Task InsertZone(ZoneModel zone)
        {
            string sql = @"INSERT INTO dbo.Zone (ZoneID, 
                            ZoneName, ZoneDescription, DateCreated) 
							values (@ZoneID, 
                            @ZoneName, @ZoneDescription, @DateCreated);";
            return _db.SaveData(sql, zone);

        }
        //Delete
        public Task DeleteZone(Guid zoneId)
        {
            var parameters = new { ZoneId = zoneId };
            string sql = "DELETE FROM dbo.Zone WHERE ZoneID = @ZoneId;";
            return _db.Delete(sql, parameters);

        }
        //Update zone
        public Task UpdateZone(ZoneModel zone)
        {
            string sql = @"UPDATE dbo.Zone SET ZoneName = @ZoneName,
                           ZoneDescription = @ZoneDescription, DateCreated = @DateCreated
                           WHERE ZoneID = @ZoneID;";
            return _db.SaveData(sql, zone);
        }
    }
}
