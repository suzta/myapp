using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using travelapp.models;

namespace travelapp.services
{
    public class WebScrapingService: BaseService
    {
        public List<WebScraping> GetAll()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            List<WebScraping> List = new List<WebScraping>();

            string url = "http://www.touropia.com/best-places-to-visit-in-usa/";

            var htmlWeb = new HtmlWeb();
            HtmlDocument document = null;
            document = htmlWeb.Load(url);

            //getting all the span with class toptitle first
            var items = document.DocumentNode.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("toptitle")).ToList();
            
            foreach (var node in items)
            {
                WebScraping item = new WebScraping();
                item.Title = node.InnerText;
                //getting the anchor tag inside the span tag
                item.Url = node.Descendants("a").FirstOrDefault().GetAttributeValue("href", "");
                List.Add(item);
                //var getUrl = document.DocumentNode.Descendants("a");
               // item.Url = node.GetAttributeValue("href", "");
            }
            return List;
        }


        public int Post(WebScraping model)
        {
            int id = 0;
            this.DataProvider.ExecuteNonQuery(
                "WebScrapUrl_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Id", model.Id);
                    paramCol.AddWithValue("@Title", model.Title);
                    paramCol.AddWithValue("@Url", model.Url);
                },
                returnParameters: delegate (SqlParameterCollection paramCol)
                {
                    id = (int)paramCol["@Id"].Value;
                }
            );
            return id;
        }
    }
}
