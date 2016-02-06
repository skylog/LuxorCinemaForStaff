using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace LuxorCinemaForStaff
{
    
    public class EncodeHtml
    {
        //static string localhtml = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "simple_test.html");
        private static string webMain = "http://www.luxorfilm.ru";
        private static string webRnd = "http://www.luxorfilm.ru/cinema/rostov-na-donu";
        private static string webSpb = "http://www.luxorfilm.ru/cinema/spb-kontinent";
        
        public async Task<HtmlDocument> EncodeHtmlAsync()  
        {
            string html;
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0(Windows; U; Windows NT 5.1; en - US; rv: x.x.x) Gecko / 20041107 Firefox / x.x");
                /*
                http.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                http.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                http.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                http.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
                */
                html = await http.GetStringAsync(webRnd);
            }
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            return Form1.doc = htmlDoc;
        
        }

        public EncodeHtml()
        {
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            Form1.doc = web.Load(webRnd);
        }


        /// <summary>
        /// EncodeHtml(string insertHtml) - для обработки множества страниц с фильмами
        /// </summary>
        Uri uri;
        public EncodeHtml(string insertHtml)
        {
            try
            {
                uri = new Uri(string.Concat(webMain, insertHtml)); //без этой шляпы не работают ссылки с немецкими символами о.О
                HtmlWeb web = new HtmlWeb
                    {
                        AutoDetectEncoding = false,
                        OverrideEncoding = Encoding.UTF8,
                    };
                    Form1.doc = web.Load(uri.AbsoluteUri);
            }
            catch(Exception ex)
            {
                Debug.Write(ex.Message);
                Form1.doc = null;
            }
        }
    }
}
