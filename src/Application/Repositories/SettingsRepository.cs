using Domain.Entities;

namespace Application.Repositories
{
    internal class SettingsRepository : InMemoryRepository<Settings, int>
    {
        public SettingsRepository()
        {
            entities.Add(new Settings(0, "", 1000));
        }
    }
}
