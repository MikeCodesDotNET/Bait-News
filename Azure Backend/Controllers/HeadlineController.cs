using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using DailyFail.Backend.DataObjects;
using DailyFail.Backend.Models;

namespace DailyFail.Backend.Controllers
{
    public class HeadlineController : TableController<Headline>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            HeadlinerContext context = new HeadlinerContext();
            DomainManager = new EntityDomainManager<Headline>(context, Request);
        }

        // GET tables/Headline
        public IQueryable<Headline> GetAllHeadline()
        {
            return Query(); 
        }

        // GET tables/Headline/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Headline> GetHeadline(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Headline/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Headline> PatchHeadline(string id, Delta<Headline> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Headline
        public async Task<IHttpActionResult> PostHeadline(Headline item)
        {
            Headline current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Headline/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteHeadline(string id)
        {
             return DeleteAsync(id);
        }
    }
}
