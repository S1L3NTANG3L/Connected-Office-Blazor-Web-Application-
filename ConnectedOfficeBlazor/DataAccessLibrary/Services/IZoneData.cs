using DataAccessLibrary.Models;

namespace DataAccessLibrary.Services
{
	//Just an interface class
	public interface IZoneData
	{
		Task<List<ZoneModel>> GetZones();
		Task InsertZone(ZoneModel zone);
		Task<ZoneModel> GetZoneById(Guid zoneId);
		Task DeleteZone(Guid zoneId);
		Task UpdateZone(ZoneModel zone);
    }
}