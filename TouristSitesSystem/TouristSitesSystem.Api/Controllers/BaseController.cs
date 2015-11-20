namespace TouristSitesSystem.Api.Controllers
{
    using System.Web.Http;

    using TouristSiteSystem.Data;

    public abstract class BaseController : ApiController
    {
        protected ITouristSiteData data;

        public BaseController(ITouristSiteData data)
        {
            this.data = data;
        }

        ////public BaseController()
        ////    : this(new TouristSiteData())
        ////{
        ////}
    }
}
