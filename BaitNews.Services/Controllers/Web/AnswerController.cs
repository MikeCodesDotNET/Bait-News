using System;
using System.Net;
using System.Threading.Tasks;
using BaitNews.Models;
using BaitNews.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.ApplicationInsights;

namespace BaitNews.Controllers.Web
{
	[Authorize(Roles = "admin")]
	public class AnswerController : Controller
    {
		DocumentDBRepositoryBase<Answer> DBRepository = new DocumentDBRepositoryBase<Answer>();

		public AnswerController()
		{
			DBRepository.Initialize();
		}

		private TelemetryClient telemetry = new TelemetryClient();

		[ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var items = await DBRepository.GetItemsAsync(x => x.HeadlineId != null);
            return View(items);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind("HeadlineId,UserId,CorrectAnswer")] Answer item)
        {
            if (ModelState.IsValid)
            {
                await DBRepository.UpdateItemAsync(item.Id, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Answer item = await DBRepository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Answer item = await DBRepository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind("Id")] string id)
        {
            await DBRepository.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            Answer item = await DBRepository.GetItemAsync(id);
            return View(item);
        }
    }
}