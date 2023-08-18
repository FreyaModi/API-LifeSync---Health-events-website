using lifesync.Models;

namespace lifesync.Repository
{
    public interface IOutputRepository
    {
        int GetEventsByCity(EventsModel EventsModel);
    }
}
