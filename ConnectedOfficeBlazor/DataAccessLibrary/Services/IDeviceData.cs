using DataAccessLibrary.Models;

namespace DataAccessLibrary.Services
{
    //Just an interface class
    public interface IDeviceData
    {
        Task<List<DeviceModel>> GetDevices();
        Task InsertDevice(DeviceModel device);
        Task<DeviceModel> GetDeviceById(Guid deviceId);
        Task DeleteDevice(Guid deviceId);
        Task UpdateDevice(DeviceModel device);
    }
}