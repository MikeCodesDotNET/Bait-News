using System;
using System.Net;
using System.Threading.Tasks;
using BaitNews.Models;
using BaitNews.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BaitNews.Controllers.Api
{
    [Route("/api/answer")]
	public class AnswerController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var items = await DocumentDBRepository<Answer>.GetItemsAsync(x => x.HeadlineId != null);
			return Json(items);
		}

        [HttpGet("ID/{id}")]
		public async Task<IActionResult> GetById(string id)
		{
			var items = await DocumentDBRepository<Answer>.GetItemsAsync(x => x.Id != id);
			return Json(items);
		}


		[HttpPost, Authorize]
		public async Task<ActionResult> CreateAsync([Bind("HeadlineId,UserId,CorrectAnswer")] Answer item)
		{
			if (ModelState.IsValid)
			{
				if (string.IsNullOrEmpty(item.Id))
					item.Id = Guid.NewGuid().ToString();

				await DocumentDBRepository<Answer>.CreateItemAsync(item);
				return RedirectToAction("Index");
			}

			return Json(item);
		}

		[HttpPatch, Authorize]
		public async Task<ActionResult> EditAsync([Bind("HeadlineId,UserId,CorrectAnswer")] Answer item)
		{
			if (ModelState.IsValid)
			{
				await DocumentDBRepository<Answer>.UpdateItemAsync(item.Id, item);
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

			Answer item = await DocumentDBRepository<Answer>.GetItemAsync(id);
			if (item == null)
			{
				return NotFound();
			}

			await DocumentDBRepository<Answer>.DeleteItemAsync(id);
			return RedirectToAction("Index");

		}
	}
}