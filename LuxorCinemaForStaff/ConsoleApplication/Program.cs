using System;
using System.Linq;
using LuxorCinemaForStaff.BL;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Collections.Generic;

namespace ConsoleApplication
{
    class Program
    {
        public static HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

        static void Main(string[] args)
        {
            #region
            /*
            FilmValue[] filmArray = new FilmValue[]
           {
                new FilmValue("Форсаж", "1ч. 45мин.")
                //new FilmValue("Фильм 2", "2ч. 15мин."),
                //new FilmValue("Фильм 3", "2ч. 5мин."),
           };

            HallValue[] hallArray = new HallValue[]
            {
                new HallValue("Зал 1","13:30"),
                new HallValue("Зал 1","15:45"),
                new HallValue("Зал 1","18:10"),
                new HallValue("Зал 2","11:30"),
                new HallValue("Зал 2","13:45"),
                new HallValue("Зал 2","17:10"),
            };

            var query = from element in hallArray
                        where element.Name == "Зал 1"
                        orderby element.Name, element.Start
                        select new
                        {
                            Name = element.Name,
                            Start = element.Start
                        };
            Session sesList = new Session(filmArray);

            FilmValue fList = new FilmValue(hallArray);

            foreach (FilmValue f in sesList)
            {
                foreach (HallValue h in fList)
                {
                    Console.WriteLine("{0} {1} {2} {3}", f.Name, f.Duration, h.Name, h.Start);
                } 
            }
            foreach (var item in query)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Start);
            }
            

            /*
            FilmValue Film = new FilmValue()
            {
                Duration = TimeSpan.Parse("1 ч. 40 мин.") 
            };

            FilmValue Film1 = new FilmValue();
            Film1.Duration = TimeSpan.Parse("2 ч. 30 мин.");
            Film1.Name = null;

            FilmValue Film2 = new FilmValue("Хоббит", TimeSpan.Parse("3 ч. 10 мин."));
            HallValue Hall2 = new HallValue("Зал №3", "14:10");
            */
            //FilmValue Film1 = new FilmValue();
            //Session s = new Session();
            //FilmValue type = typeof(FilmValue);

            //Session myObject = (Session)Activator.CreateInstance(type);
            //var hall = new HallValue();
            //var film = new FilmValue();
            //s.CreateSession(Hall2, Film2);


            //Console.WriteLine(Film.Duration);
            //Console.WriteLine(Film1.Duration + Film1.Name );
            //Console.WriteLine("{0}, длительность фильма: {1}, {2}, сеанс {3}",  Film2.Name, Film2.Duration, Hall2.Name, Hall2.Start);
            //Console.WriteLine(myObject); Console.WriteLine(s);
            #endregion
            GetFilmInfo();
            Console.ReadLine();
            
        }

        public static string SessionEndTime(string sessionStart, string length)
        {
            DateTime s1Time = Convert.ToDateTime(DateTime.Parse(sessionStart));
            // DateTime dt1 = Convert.ToDateTime(s1Time);

            string s2Replase = length.Replace("ч.", ":").Replace("мин.", "").Replace(" ", "");

            if (s2Replase.Count() <= 5)
            {
                string pattern = @"([:])";
                string[] elements = System.Text.RegularExpressions.Regex.Split(s2Replase, pattern);
                int valueHour = Convert.ToInt32(elements[0]);
                int valueMinute = Convert.ToInt32(elements[2]);

                DateTime addTime = s1Time.AddHours(valueHour).AddMinutes(valueMinute);
                TimeSpan justTime = new TimeSpan(addTime.Hour, addTime.Minute, 0);
                string res = Convert.ToString(justTime);
                return res;
            }
            return "Упс";

        }

        static private async void GetFilmInfo()
        {

            EncodeHtml myEncode = new EncodeHtml();
            await myEncode.EncodeHtmlAsync();
            //GetHtmlEncode(webhtml); //передаем ссылку ростовского люксора для конверна => убиваем кракозябры
            HtmlNodeCollection trMainLine = doc.DocumentNode.SelectNodes("//tr[@class='one-film-line']"); //именно здесь лежит инфа типа: фильм + время сеанса - зал, время сеанса - зал..
            if (trMainLine != null)
            {
                foreach (HtmlNode line in trMainLine)
                {
                    try
                    {
                        string nameFilm = line.ChildNodes.FindFirst("h3").ChildNodes[1].InnerText.Trim(); //название фильма
                        string linkFilm = line.ChildNodes.FindFirst("h3").ChildNodes[1].Attributes["href"].Value; //ссылка на страницу с описанием фильма
                        EncodeHtml myLinkEncode = new EncodeHtml(linkFilm);
                        string timefilmStr;

                        try
                        {
                            timefilmStr = doc.DocumentNode.SelectSingleNode("//div[@class='cast-away']/table/tbody/tr[7]/td[2]").InnerText;
                            if (timefilmStr.Length > 12)
                            {
                                HtmlNodeCollection elementsTd = doc.DocumentNode.SelectNodes("//td");
                                if (elementsTd != null)
                                {
                                    foreach (var td in elementsTd)
                                    {
                                        if (td.InnerText == "Продолжительность:")
                                        {
                                            timefilmStr = td.NextSibling.NextSibling.InnerText;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Print(ex.Message);
                            timefilmStr = null;
                        }

                        //еще костыль, пока хз как получать Продолжительность, т.к. инфа просто в в определенной таблице
                        IEnumerable<HtmlNode> hallsLine = line.Descendants()
                            .Where(n => n.Attributes["class"] != null
                            && n.Attributes["class"].Value == "hall-td"); //получаем список залов <td class ='hall-td'>Зал N</td>  

                        if (hallsLine != null)
                        {
                            foreach (HtmlNode hall in hallsLine)
                            {
                                string sesionStartTime = hall.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.FirstChild.InnerText.Trim();
                                //так делать нельзя, но приходится т.к. время сеансов находится в <a class ='shedule-data  session_completed' || 'shedule-data  '
                                //тег <a> видоизменяется в зависимости от времени (сеанс закончен или нет), 
                                //поэтому решил идти снизу вверх (зал внизу, время наверху), т.к. зал - обязательный потомок для тегов shedule-data.  

                                Console.WriteLine
                                    (nameFilm+" "+
                                    hall.InnerText.Trim() + " " +
                                    sesionStartTime + " " +
                                    SessionEndTime(sesionStartTime, timefilmStr) + " " +
                                    timefilmStr);
                            }
                        
                        }
                    }
                    catch
                    {
                        Exception ex = new Exception();
                        Debug.Print("Случилась неведомая чертовщина");
                    }
                }
            }
            else Debug.Print("Не найден tr @class='one-film-line'");
        }
    }
}
