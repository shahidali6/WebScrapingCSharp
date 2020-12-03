using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace CommonClasses
{
    public class HTMLAgilityPack
    {
        public List<string> FirstName { get; set; }
        public static HtmlDocument LoadPagefromURL(string url)
        {
            HtmlWeb webAgent = new HtmlWeb();
            HtmlDocument htmlDocument = webAgent.Load(url);
            return htmlDocument;
        }
        public static HtmlDocument LoadPagefromBrower(string url)
        {
            HtmlWeb webAgent = new HtmlWeb();
            HtmlDocument htmlDocument = webAgent.LoadFromBrowser(url);
            return htmlDocument;
        }
        public static HtmlDocument LoadPagefromHTMLFile(string path)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(path);
            return htmlDocument;
        }
        public static HtmlNodeCollection FilterHTMLTagsFromSource(HtmlDocument htmlSource, string xPath)
        {
            HtmlNodeCollection htmlNodes = htmlSource.DocumentNode.SelectNodes(xPath);
            return htmlNodes;
        }
        public static List<string> GetAllCourseURLstoList(HtmlNodeCollection allNodes, bool displayConsoleData)
        {
            List<string> listOfCourseURLs = new List<string>();
            foreach (var node in allNodes)
            {
                listOfCourseURLs.Add(node.GetAttributeValue("href", String.Empty));
                //Console.WriteLine(node.Attributes["href"].Value);
                if (displayConsoleData)
                {
                    Console.WriteLine(node.GetAttributeValue("href", String.Empty));
                }
            }
            return listOfCourseURLs;
        }
        public static List<string> GetAllCourseNamestoList(HtmlNodeCollection allNodes, bool displayConsoleData)
        {
            List<string> listOfCourseNames = new List<string>();
            foreach (var node in allNodes)
            {
                string refineHtml = node.InnerText;
                refineHtml = HTMLCodeSnippet.ReplaceSpecialCharacters(refineHtml);
                listOfCourseNames.Add(refineHtml);
                if (displayConsoleData)
                {
                    Console.WriteLine(refineHtml);
                }
            }
            return listOfCourseNames;
        }
        public static List<CourseNameAndURL> GetAllCourseNamesAndURLstoList(HtmlNodeCollection allNodes, List<string> listOfCourseNames, List<string> listOfCourseURLs)
        {
            List<CourseNameAndURL> CousreNameURLList = new List<CourseNameAndURL>();
            CourseNameAndURL CourseNameURL = new CourseNameAndURL();
            foreach (var node in allNodes)
            {
                string refineHtml = node.InnerText;
                refineHtml = HTMLCodeSnippet.ReplaceSpecialCharacters(refineHtml);
                CourseNameURL.courseName = refineHtml;
                Console.WriteLine(refineHtml);
                CourseNameURL.cousreURL = node.GetAttributeValue("href", String.Empty);
                //listOfCourseURLs.Add(node.GetAttributeValue("href", String.Empty));
                //Console.WriteLine(node.Attributes["href"].Value);
                Console.WriteLine(node.GetAttributeValue("href", String.Empty));
                CousreNameURLList.Add(CourseNameURL);
            }
            return CousreNameURLList;
        }
        public struct CourseNameAndURL
        {
            public string courseName;
            public string cousreURL;
        }
    }
}
