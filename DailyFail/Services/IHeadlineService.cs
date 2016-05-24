using System.Collections.Generic;
using System.Threading.Tasks;

using BaitNews.Models;

namespace BaitNews.Services
{
    public interface IHeadlineService
    {
        Task Initialize();

        Task<IEnumerable<Headline>> GetHeadlines();

        Task SyncToDos();
    }
}