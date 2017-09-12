using System;
using System.Net;
using System.Threading.Tasks;
using BaitNews.Models;
using BaitNews.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using BaitNews.Controllers.Api;

namespace BaitNews.Controllers.API
{
    [Route("/api/comment")]
    public class CommentController : BaseController<Comment>
    {
    }
}
