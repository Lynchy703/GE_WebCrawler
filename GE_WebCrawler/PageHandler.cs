using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GE_WebCrawler
{
    public class PageHandler
    {

        public  ResultsModel Results = new ResultsModel();
        static PagesToVisitModel pagesToVisit = new PagesToVisitModel();


        //Method to validate a URL. Should be expanded 
        public bool CheckURLValid(string source)
        {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }


        //Crawls a single page.
        public void HandlePage(string link)
        {
            //Check if page is already visited.
            if (Results.pagesVisited!= null && Results.pagesVisited.Contains(link))
            {
                Results.pagesSkipped.Add(link);
            }
            else
            {
                //Test if valid URL
                if (CheckURLValid(link))
                {
                    Results.pagesVisited.Add(link);
                }
                else {
                    //didn't pass validation URL will return an error
                    Results.pagesError.Add(link);
                }
            }
        }


        //Does most of the work crawling all the pages etc.
        public void CrawlPages(string jsonInput)
        {
            //Deserialize Json Object and put in the pages list
            pagesToVisit.Pages = (List<PageModel>)JsonConvert.DeserializeObject(jsonInput, typeof(List<PageModel>));


            //Go through the list of pages. Skip if page had been visited prior. Error if page doesn't exist or is invalid.
            foreach (PageModel page in pagesToVisit.Pages)
            {
                foreach (string link in page.Links)
                {
                    HandlePage(link);
                }
            }
        }
    }
}
