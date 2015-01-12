using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        MusicStoreEntities storeDB = new MusicStoreEntities();
        /// <summary>
        /// Trần phước Tuấn mới thêm comment tại HomeController, Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // Get most popular albums
            var albums = GetTopSellingAlbums(5);

            return View(albums);
        }

        /// <summary>
        /// tuantp, comment tại HomeController, GetTopSellingAlbums
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count

            return storeDB.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
    }
}