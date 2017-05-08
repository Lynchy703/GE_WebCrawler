using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE_WebCrawler
{
    public class ResultsModel
    {

        public List<string> _pagesVisited { get; set; }
        public List<string> _pagesSkipped { get; set; }
        public List<string> _pagesError { get; set; }

        public List<string> pagesVisited
        {
            get { return _pagesVisited; }
            set { _pagesVisited =  value; }
        }

        public List<string> pagesSkipped
        {
            get { return _pagesSkipped; }
            set { _pagesSkipped = value; }
        }

        public List<string> pagesError
        {
            get { return _pagesError; }
            set { _pagesError = value; }
        }
        public ResultsModel()
        {
            this.pagesVisited = new List<string>();
            this.pagesSkipped = new List<string>();
            this.pagesError = new List<string>();
        }
    }
}
