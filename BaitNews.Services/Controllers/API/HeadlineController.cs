using System;
using System.Net;
using System.Threading.Tasks;
using BaitNews.Models;
using BaitNews.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BaitNews.Controllers.Api
{
    [Route("/api/headline")]
	public class HeadlineController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var items = await DocumentDBRepository<Headline>.GetItemsAsync(x => x.Text != null);
			return Json(items);
		}

        [HttpGet("ID/{id}")]
		public async Task<IActionResult> GetById(string id)
		{
			var items = await DocumentDBRepository<Headline>.GetItemsAsync(x => x.Id != id);
			return Json(items);
		}


		[HttpPost, Authorize]
		public async Task<ActionResult> CreateAsync([Bind("Id,Text,IsTrue,Source,ImageUrl,Url")] Headline item)
		{
			if (ModelState.IsValid)
			{
				if (string.IsNullOrEmpty(item.Id))
					item.Id = Guid.NewGuid().ToString();

				await DocumentDBRepository<Headline>.CreateItemAsync(item);
				return RedirectToAction("Index");
			}

			return Json(item);
		}

		[HttpPatch, Authorize]
		public async Task<ActionResult> EditAsync([Bind("Id,Text,IsTrue,Source,ImageUrl,Url")] Headline item)
		{
			if (ModelState.IsValid)
			{
				await DocumentDBRepository<Headline>.UpdateItemAsync(item.Id, item);
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

			Headline item = await DocumentDBRepository<Headline>.GetItemAsync(id);
			if (item == null)
			{
				return NotFound();
			}

			await DocumentDBRepository<Headline>.DeleteItemAsync(id);
			return RedirectToAction("Index");

		}
	}
}