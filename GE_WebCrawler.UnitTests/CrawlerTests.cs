using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GE_WebCrawler.UnitTests
{
    [TestClass]
    public class CrawlerTests
    {
        [TestMethod]
        public void Internet1()
        {

            //var rawJson = "    ["
            //                        + "{"
            //                        + "            \"address\": \"http://foo.bar.com/p1\","
            //                         + " \"links\": ["
            //                        + "    \"http://foo.bar.com/p2\","
            //                         + "   \"http://foo.bar.com/p3\","
            //                         + "   \"http://foo.bar.com/p4\""
            //                         + " ]"
            //                       + " },"
            //                       + " {"
            //                        + "  \"address\": \"http://foo.bar.com/p2\","
            //                        + "  \"links\": ["
            //                       + "     \"http://foo.bar.com/p2\","
            //                        + "    \"http://foo.bar.com/p4\""
            //                        + "  ]"
            //                    + "},"
            //                     + "   {"
            //                       + "   \"address\": \"http://foo.bar.com/p4\", "
            //                       + "  \"links\": [
            //                      + "    \"http://foo.bar.com/p5\","
            //                      + "     \"http://foo.bar.com/p1\","
            //                      + "     \"http://foo.bar.com/p6\""
            //                      + "   ]"
            //                      + "  },"
            //                      + " {"
            //                      + " \"address\": \"http://foo.bar.com/p5\","
            //                       + "   \"links\": [ ]"
            //                      + "  },"
            //                      + "  {"
            //                     + "   \"address\": \"http://foo.bar.com/p6\","
            //                       + "   \"links\": ["
            //                       + "     \"http://foo.bar.com/p7\","
            //                       + "     \"http://foo.bar.com/p4\","
            //                       + "     \"http://foo.bar.com/p5\""
            //                      + "    ]"
            //                       + " }"
            //                     + " ] \"";

            //Determine build path and get read file there.
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(directory, @"Internet1.json");
            var rawJson = File.ReadAllText(path);


            PageHandler pageHandler = new PageHandler();
            pageHandler.CrawlPages(rawJson);

            ResultsModel testResults = new ResultsModel();
            testResults.pagesVisited = (new List<string> { "http://foo.bar.com/p1", "http://foo.bar.com/p2","http://foo.bar.com/p4", "http://foo.bar.com/p5","http://foo.bar.com/p6", "http://foo.bar.com/p3", "http://foo.bar.com/p7" });

            testResults.pagesSkipped = (new List<string> { "http://foo.bar.com/p2","http://foo.bar.com/p4", "http://foo.bar.com/p1","http://foo.bar.com/p5" });

            //testResults.pagesError = (new List<string> {  });
            testResults.pagesVisited.Sort();
            testResults.pagesSkipped.Sort();
            testResults.pagesError.Sort();

            pageHandler.Results.pagesVisited.Sort();
            pageHandler.Results.pagesSkipped.Sort();
            pageHandler.Results.pagesError.Sort();

            Assert.AreEqual(testResults.ToString(), pageHandler.Results.ToString());


        }

        [TestMethod]
        public void Internet2()
        {

            //Determine build path and get read file there.
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(directory, @"Internet2.json");
            var file = File.ReadAllText(path);


            PageHandler pageHandler = new PageHandler();
            pageHandler.CrawlPages(file);

            ResultsModel testResults = new ResultsModel();
            testResults.pagesVisited = (new List<string> {"http://foo.bar.com/p1", "http://foo.bar.com/p2","http://foo.bar.com/p3", "http://foo.bar.com/p4","http://foo.bar.com/p5" });

            testResults.pagesSkipped = (new List<string> { "http://foo.bar.com/p1" });

            testResults.pagesVisited.Sort();
            testResults.pagesSkipped.Sort();
            testResults.pagesError.Sort();

            pageHandler.Results.pagesVisited.Sort();
            pageHandler.Results.pagesSkipped.Sort();
            pageHandler.Results.pagesError.Sort();

            Assert.AreEqual(testResults.ToString(), pageHandler.Results.ToString());

        }




    }
}
