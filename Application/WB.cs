using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain;
using HtmlAgilityPack;
using System.Web;

namespace Application
{
    public class WB 
    {
        public List<Products> ParserData(string locationParam)
        {
            var home = new List<Products>();
            var url = "https://www.wildberries.ru/catalog/"+ HttpUtility.UrlDecode(locationParam);
            var web = new HtmlWeb();

            HtmlNode nextbutton = null;

            do
            {
                var doc = web.Load(url);
                // поменять ноды
               // HtmlNodeCollection parentId = doc.DocumentNode.SelectNodes("//*[@id='offers_table']//*[@class='wrap']");

                
                    // var title = item.SelectSingleNode(".//*[@class='lheight22 margintop5']").InnerText.Trim();
                    var price = doc.DocumentNode.SelectSingleNode(".//*[@class='price-block_final-price']").InnerText.Trim();
                    var name = doc.DocumentNode.SelectSingleNode(".//*[@class='product-page_header").InnerText.Trim();
                    var priceFormat = Regex.Replace(price, @"[^\u0000-\u007F]", string.Empty);
                    // var location = item.SelectSingleNode(".//*[@class='lheight16']/small[1]/span/text()").InnerText.Trim();
                    // var time = item.SelectSingleNode(".//*[@class='lheight16']/small[2]/span/text()").InnerText.Trim();
                    var link = doc.DocumentNode.SelectSingleNode(".//*[@class='photo-cell']//a").GetAttributeValue("href", String.Empty);

                    home.Add(new Products()
                    {
                        Name = name,
                        Price = priceFormat,
                        Link = link
                    });
                    nextbutton = doc.DocumentNode.SelectSingleNode("//*[@class='fbold next abs large']/a");
                    url = nextbutton?.GetAttributeValue<string>("href", null);
                

            }
            while (nextbutton != null);
            return home;
        }
    }
}
    
