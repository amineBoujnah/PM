using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class NewsController : Controller
    {

        private static List<string> ScrapedFeed = new List<string>();
        private static List<string> ScrapedImages = new List<string>();
        private static List<string> ScrapedTitles = new List<string>();

        public async Task<ActionResult> Feed()
        {
            var url = "http://www.otdav.tn/category/nouveautes-otdav/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);



            var titleList = htmlDocument.DocumentNode.DescendantsAndSelf("h2").Where(node => node.GetAttributeValue("class", "").Equals("entry-title"))  ;
            


            var actList = htmlDocument.DocumentNode.Descendants("h2").Where(node => node.GetAttributeValue("class", "").Equals("entry-title")).ToList();

            var imgList = htmlDocument.DocumentNode.Descendants("img").Where(node => node.GetAttributeValue("width", "").Equals("538")).Where(x=>x.GetAttributeValue("src","").Contains("http://www.otdav.tn/wp-content/uploads")).ToList();


            foreach (var item in titleList)
            {
                

                ScrapedTitles.Add(item.InnerText.ToString().Replace("&nbsp"," "));

            }


            foreach (var item in imgList)
            {
                var img = HtmlNode.CreateNode(item.OuterHtml);
                var src = img.Attributes["src"].Value;
                ScrapedImages.Add(src);
            }
          
           




            foreach (var item in actList)
            {
               
                string n = item.InnerText.ToString().Replace("&nbsp", " ");
               
                ScrapedFeed.Add(n);

            }

            ViewBag.NEWS = ScrapedFeed.ToList();
            ViewBag.IMAGES = ScrapedImages.ToList();
            ViewBag.TITLES = ScrapedTitles.ToList();
            return View();

        }



   
     




    }
}