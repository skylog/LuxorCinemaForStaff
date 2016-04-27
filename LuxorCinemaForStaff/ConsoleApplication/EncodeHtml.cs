using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ConsoleApplication
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
                #region Представимся браузером
                /*
                http.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                http.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                http.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                http.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
                */
                #endregion
                html = await http.GetStringAsync(webRnd);
            }
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            return Program.doc = htmlDoc;
        
        }


        public EncodeHtml()
        {
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            Program.doc = web.Load(GetUri());
        }

        public string GetUri()
        {
            return GetUri(null);

        }
        public string GetUri(string webTail)
        {
            Uri u;
            if (webTail != null)
            {
                //Uri u = new Uri(string.Concat(webMain, webTail)); //без этой шляпы не работают ссылки с немецкими символами о.О
                u = new Uri(string.Concat(webMain, webTail)); //без этой шляпы не работают ссылки с немецкими символами о.О
                return u.AbsoluteUri;
            }
            else
            {
                //Uri u = new Uri(webMain);
                u = new Uri(webMain);
                return u.AbsoluteUri;
            }
            
        }

        /// <summary>
        /// EncodeHtml(string insertHtml) - для обработки множества страниц с фильмами
        /// </summary>
        public EncodeHtml(string insertHtml) 
        {
            try
            {
                HtmlWeb web = new HtmlWeb
                    {
                        AutoDetectEncoding = false,
                        OverrideEncoding = Encoding.UTF8,
                    };
                Program.doc = web.Load(GetUri(insertHtml));
            }
            catch(Exception ex)
            {
                Debug.Write(ex.Message);
                Program.doc = null;
            }
        }
    }
}
