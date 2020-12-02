using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    class HTMLAgilityPack
    {
        public HtmlDocument LoadPagefromURL(string url)
        {
            HtmlWeb webAgent = new HtmlWeb();
            HtmlDocument htmlDocument = webAgent.Load(url);
            return htmlDocument;
        }
        public HtmlDocument LoadPagefromBrower(string url)
        {
            HtmlWeb webAgent = new HtmlWeb();
            HtmlDocument htmlDocument = webAgent.LoadFromBrowser(url);
            return htmlDocument;
        }
        public HtmlDocument LoadPagefromHTMLFile(string path)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(path);
            return htmlDocument;
        }
    }
}
