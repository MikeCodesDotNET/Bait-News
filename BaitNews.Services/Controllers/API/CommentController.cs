using System;
using System.Net;
using System.Threading.Tasks;
using BaitNews.Models;
using BaitNews.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace BaitNews.Controllers.API
{
    [Route("/api/comment")]
	public class CommentController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var items = await DocumentDBRepository<Comment>.GetItemsAsync(x => x.Content != null);
			return Json(items);
		}

		[HttpGet("ID/{id}")]
		public async Task<IActionResult> GetById(string id)
		{
			var items = await DocumentDBRepository<Comment>.GetItemsAsync(x => x.Id != id);
			return Json(items);
		}


		[HttpPost, Authorize]
		public async Task<ActionResult> CreateAsync([Bind("Id,Text,IsTrue,Source,ImageUrl,Url")] Comment item)
		{
			if (ModelState.IsValid)
			{
				if (string.IsNullOrEmpty(item.Id))
					item.Id = Guid.NewGuid().ToString();

                Headline headline = await DocumentDBRepository<Headline>.GetItemAsync(item.HeadlineId);


				await DocumentDBRepository<Comment>.CreateItemAsync(item);
				return RedirectToAction("Index");
			}

			return Json(item);
		}

		[HttpPatch, Authorize]
		public async Task<ActionResult> EditAsync([Bind("Id,Text,IsTrue,Source,ImageUrl,Url")] Comment item)
		{
			if (ModelState.IsValid)
			{
				await DocumentDBRepository<Comment>.UpdateItemAsync(item.Id, item);
				return RedirectToAction("Index");
			}

			return Json(item);
		}

		[Authorize(Roles = "admin"), HttpDelete]
		public async Task<ActionResult> DeleteAsync(string id)
		{
			if (id == null)
			{
				return BadRequest();
			}

			Comment item = await DocumentDBRepository<Comment>.GetItemAsync(id);
			if (item == null)
			{
				return NotFound();
			}

			await DocumentDBRepository<Comment>.DeleteItemAsync(id);
			return RedirectToAction("Index");

		}
	}
}
