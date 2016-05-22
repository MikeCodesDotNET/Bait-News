using System.Collections.Generic;
using System.Threading.Tasks;

using DailyFail.Models;

namespace DailyFail.Services
{
    public interface IHeadlineService
    {
        Task Initialize();

        Task<IEnumerable<Headline>> GetHeadlines();

        Task SyncToDos();
    }
}