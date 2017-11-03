using System;
using System.Net;
using System.Threading.Tasks;
using BaitNews.Models;
using BaitNews.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BaitNews.Controllers.API;

namespace BaitNews.Controllers.Api
{
	[Route("/api/answer")]
	public class AnswerController : BaseController<Answer>
	{
	}
}