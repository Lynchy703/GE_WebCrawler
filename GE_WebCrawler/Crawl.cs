using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;

namespace GE_WebCrawler
{
    class Crawl
    {
        

        static void Main(string[] args)
        {

            //Determine build path and get read file there.
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(directory, @"pagesToCrawl.json");
            var file = File.ReadAllText(path);


            //Handles the work here. Pass in the raw json.
            PageHandler pageHandler = new PageHandler();
            pageHandler.CrawlPages(file);


            //OutPutResult here:
            var results = JObject.FromObject(pageHandler.Results).ToString();
            string OutPutPath = Path.Combine(directory, @"results.json");
            System.IO.File.WriteAllText(OutPutPath, results);
        }
    }
}
