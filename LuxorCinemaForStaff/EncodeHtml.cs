using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace LuxorCinemaForStaff
{
    
    public class EncodeHtml
    {
        //static string localhtml = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "simple_test.html");
        private static string webhtml = "http://www.luxorfilm.ru/cinema/rostov-na-donu";

        

        public EncodeHtml()
        {
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            Form1.doc = web.Load(webhtml);
        }

        public EncodeHtml(string insertHtml)
        {
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            Form1.doc = web.Load(insertHtml);
        }



    }
}
