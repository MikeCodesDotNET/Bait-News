using BaitNews.Models;
using Microsoft.AspNetCore.Mvc;
using BaitNews.Controllers.API;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;

namespace BaitNews.Controllers.Api
{
    [Route("/api/headline")]
	public class HeadlineController : BaseController<Headline>
	{
	}
}