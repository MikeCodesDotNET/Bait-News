using System;
using System.Net;
using System.Threading.Tasks;
using BaitNews.Models;
using BaitNews.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BaitNews.Controllers.Web
{
    [Authorize(Roles = "admin")]
	public class HeadlineController : Controller
    {
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var items = await DocumentDBRepository<Headline>.GetItemsAsync(x => x.Text != null);
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
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(item.Id))
                    item.Id = Guid.NewGuid().ToString();
                                    
                await DocumentDBRepository<Headline>.CreateItemAsync(item);
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
                await DocumentDBRepository<Headline>.UpdateItemAsync(item.Id, item);
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

            Headline item = await DocumentDBRepository<Headline>.GetItemAsync(id);
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

            Headline item = await DocumentDBRepository<Headline>.GetItemAsync(id);
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
            await DocumentDBRepository<Headline>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            Headline item = await DocumentDBRepository<Headline>.GetItemAsync(id);
            return View(item);
        }
    }
}