using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

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
                //Test if valid URL You would also want to add a simple ping here in this check if you were doing this on valid pages.
                if (CheckURLValid(link))
                {
                    ////You could add the actually testing here for crawling pages
                    //WebRequest myWebRequest;
                    //WebResponse myWebResponse;

                    //myWebRequest = WebRequest.Create(link);
                    //myWebResponse = myWebRequest.GetResponse();//Returns a response from an Internet resource

                    //Stream streamResponse = myWebResponse.GetResponseStream();//return the data stream from the internet
                    //                                                          //and save it in the stream

                    //StreamReader sreader = new StreamReader(streamResponse);//reads the data stream
                    //var pageContent= sreader.ReadToEnd();//reads it to the end
                    //var linksOnPage = Extract(pageContent);//gets the links only could use this to reiterate through more links
                    //foreach(string l in linksOnPage)
                    //{
                    //    List<string> li = new List<string>;
                    //    li.Add(l);
                    //    pagesToVisit.Pages.Add(new PageModel { address = l, Links = li });
                    //}

                    //streamResponse.Close();
                    //sreader.Close();
                    //myWebResponse.Close();

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

        /// <summary>
        /// Extracts all src and href links from a HTML string.
        /// </summary>
        /// <param name="html">The html source</param>
        /// <returns>A list of links - these will be all links including javascript ones.</returns>
        public static List<string> Extract(string html)
        {
            List<string> list = new List<string>();

            Regex regex = new Regex("(?:href|src)=[\"|']?(.*?)[\"|'|>]+", RegexOptions.Singleline | RegexOptions.CultureInvariant);
            if (regex.IsMatch(html))
            {
                foreach (Match match in regex.Matches(html))
                {
                    list.Add(match.Groups[1].Value);
                }
            }

            return list;
        }
    }
}
