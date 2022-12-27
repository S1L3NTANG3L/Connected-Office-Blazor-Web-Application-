using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class DeviceData : IDeviceData
    {
        //Data access code
        private readonly ISqlDataAccess _db;
		public DeviceData(ISqlDataAccess db)
        {
            _db = db;
        }
        //Get all instances of devices
        public Task<List<DeviceModel>> GetDevices()
        {
			string sql = "SELECT * FROM dbo.Device;";
            return _db.LoadData<DeviceModel, dynamic>(sql, new { });
        }
        //Get single device instance
        public Task<DeviceModel> GetDeviceById(Guid device)
        {
            var parameters = new { DeviceId = device};
            string sql = "SELECT * FROM dbo.Device where DeviceID = @DeviceId;";
            
            return _db.LoadSingle<DeviceModel, dynamic>(sql, parameters);
        }
        //Create a new device
        public Task InsertDevice(DeviceModel device)
        {
            string sql = @"INSERT INTO dbo.Device (DeviceID, 
                            DeviceName, CategoryID, ZoneID, Status, 
                            IsActive, DateCreated) values (@DeviceID, 
                            @DeviceName, @CategoryID, @ZoneID @Status, 
                            @IsActive, @DateCreated);";
            return _db.SaveData(sql, device);
        }       
        //Update a device
        public Task UpdateDevice(DeviceModel device)
        {
            string sql = @"UPDATE dbo.Device SET DeviceName = @DeviceName, CategoryID = @CategoryID, 
                           ZoneID = @ZoneID, Status = @Status, IsActive = @IsActive, DateCreated = @DateCreated
                           WHERE DeviceID = @DeviceID;";
            return _db.SaveData(sql, device);
        }
        //Delete a device
        public Task DeleteDevice(Guid deviceId)
        {
            var parameters = new { DeviceId = deviceId };
            string sql = "DELETE FROM dbo.Device WHERE DeviceID = @DeviceId;";
            return _db.Delete(sql, parameters);
        }
    }
}
