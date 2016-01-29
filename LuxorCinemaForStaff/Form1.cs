using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace LuxorCinemaForStaff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        public static СombineSessionsTime Combine = new СombineSessionsTime();

        private void GetFilmInfo_1()
        {
            EncodeHtml myEncode = new EncodeHtml();
            //GetHtmlEncode(webhtml); //передаем ссылку ростовского люксора для конверна => убиваем кракозябры
            var trMainLine = doc.DocumentNode.SelectNodes("//tr[@class='one-film-line']"); //именно здесь лежит инфа типа: фильм + время сеанса - зал, время сеанса - зал..
            if (trMainLine != null)
            {
                foreach (var line in trMainLine)
                {
                    try
                    {
                        var nameFilm = line.ChildNodes.FindFirst("h3").ChildNodes[1].InnerText.Trim(); //название фильма
                        var linkFilm = line.ChildNodes.FindFirst("h3").ChildNodes[1].Attributes["href"].Value; //ссылка на страницу с описанием фильма
                        EncodeHtml myLinkEncode = new EncodeHtml(linkFilm);
                        //GetHtmlEncode(linkFilm); //передаем полученную ссылку для парсинга продолжительности фильма
                        var timefilm = doc.DocumentNode.SelectSingleNode("//div[@class='cast-away']/table/tbody/tr[7]/td[2]").InnerText;
                        //еще костыль, пока хз как получать Продолжительность, т.к. инфа просто в в определенной таблице
                        var hallsLine = line.Descendants()
                            .Where(n => n.Attributes["class"] != null
                            && n.Attributes["class"].Value == "hall-td"); //получаем список залов <td class ='hall-td'>Зал N</td>  

                        if (hallsLine != null)
                        {
                            foreach (var hall in hallsLine)
                            {
                                var sesionStartTime = hall.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.FirstChild.InnerText.Trim();
                                //так делать нельзя, но приходится т.к. время сеансов находится в <a class ='shedule-data  session_completed' || 'shedule-data  '
                                //тег <a> видоизменяется в зависимости от времени (сеанс закончен или нет), 
                                //поэтому решил идти снизу вверх (зал внизу, время наверху), т.к. зал - обязательный потомок для тегов shedule-data.  

                                dataGridView1.Rows.Add(nameFilm, hall.InnerText.Trim(), sesionStartTime, Combine.SessionEndTime(sesionStartTime, timefilm), timefilm);

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

        private void Form1_Load(object sender, EventArgs e)
        {
            GetFilmInfo_1();
        }
    }
}

