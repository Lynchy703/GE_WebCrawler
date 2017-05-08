using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GE_WebCrawler.Tests
{
    [TestClass]
    public class CrawlerTests 
    {

            [TestMethod]
            public void Internet1()
            {

                var rawJson = "    ["
                                        + "{"
                                        + "            \"address\": \"http://foo.bar.com/p1\","
                                         + " \"links\": ["
                                        + "    \"http://foo.bar.com/p2\","
                                         + "   \"http://foo.bar.com/p3\","
                                         + "   \"http://foo.bar.com/p4\""
                                         + " ]"
                                       + " },"
                                       + " {"
                                        + "  \"address\": \"http://foo.bar.com/p2\","
                                        + "  \"links\": ["
                                       + "     \"http://foo.bar.com/p2\","
                                        + "    \"http://foo.bar.com/p4\""
                                        + "  ]"
                                    + "},"
                                     + "   {"
                                       + "   \"address\": \"http://foo.bar.com/p4\","
                                       + "   \"links\": [
                                      + "    \"http://foo.bar.com/p5\","
                                      + "     \"http://foo.bar.com/p1\","
                                      + "     \"http://foo.bar.com/p6\""
                                      + "   ]"
                                      + "  },"
                                      + " {"
                                      + " \"address\": \"http://foo.bar.com/p5\","
                                       + "   \"links\": [ ]"
                                      + "  },"
                                      + "  {"
                                     + "   \"address\": \"http://foo.bar.com/p6\","
                                       + "   \"links\": ["
                                       + "     \"http://foo.bar.com/p7\","
                                       + "     \"http://foo.bar.com/p4\","
                                       + "     \"http://foo.bar.com/p5\""
                                      + "    ]"
                                       + " }"
                                     + " ] \"";


                PageHandler pageHandler = new PageHandler();
                pageHandler.CrawlPages(rawJson);




            }



            public void Internet1()
            {


            }

    }
}
