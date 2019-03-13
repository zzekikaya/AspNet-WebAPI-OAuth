using System.Collections.Generic;
using System.Web.Http;

namespace AspNetWebAPIOAuth.Controllers
{
    public class OrdersController : ApiController
    {
        [HttpGet]
        [Authorize]
        public List<string> List()
        {
            List<string> orders = new List<string>();

            orders.Add("Elma");
            orders.Add("Armut");
            orders.Add("Erik");

            return orders;
        }
    }
}