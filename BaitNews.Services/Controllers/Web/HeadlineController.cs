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
	public class HeadlineController : Controller
    {
		DocumentDBRepositoryBase<Headline> DBRepository = new DocumentDBRepositoryBase<Headline>();

		public HeadlineController()
		{
			DBRepository.Initialize();
		}

		private TelemetryClient telemetry = new TelemetryClient();

		[ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var items = await DBRepository.GetItemsAsync(x => x.Text != null);
            return View(items);
        }


#pragma warning disable 1998
        [ActionName("Create")]
        public async Task<IActionResult> CreateAsync()
        {
            return View();
        }
#pragma warning restore 1998

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Id,Text,IsTrue,Source,ImageUrl,Url")] Headline item)
        {
			telemetry.TrackEvent("CreateHeadline");

			if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(item.Id))
                    item.Id = Guid.NewGuid().ToString();
                                    
                await DBRepository.CreateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind("Id,Text,IsTrue,Source,ImageUrl,Url")] Headline item)
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

            Headline item = await DBRepository.GetItemAsync(id);
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

            Headline item = await DBRepository.GetItemAsync(id);
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
            Headline item = await DBRepository.GetItemAsync(id);
            return View(item);
        }

        [ActionName("Count")]
        public async Task<ActionResult> CountAsync()
        {
            var count = await DBRepository.GetItemsCount();
            return View(count);
        }
    }
}