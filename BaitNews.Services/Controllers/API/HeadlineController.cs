using BaitNews.Models;
using Microsoft.AspNetCore.Mvc;
using BaitNews.Controllers.API;
using System.Threading.Tasks;

namespace BaitNews.Controllers.Api
{
    [Route("/api/headline")]
	public class HeadlineController : BaseController<Headline>
	{
	}
}