using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace LuxorCinemaForStaff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            butStart.Click += btnStart_Click;
            butStop.Click += btnStop_Click;

            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        public static HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        СombineSessionsTime Combine = new СombineSessionsTime();

        private void btnStop_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            butStart.Enabled = false;
            if (worker.IsBusy == false)
            {
                worker.RunWorkerAsync();
            }
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <=99; i++)
            {

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                worker.ReportProgress(i);
                Thread.Sleep(10);

            }

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(string.Format("Ошибка : {0}", e.Error.Message));
            }
            else
            {
                string message = e.Cancelled ? "Процесс отменен" : "Процесс завершен";
                MessageBox.Show(message);
                progressBar1.Value = 0;
                
            }
            butStart.Enabled = true;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage + 1;
            progressBar1.Value = e.ProgressPercentage;
            
            //dataGridView1.Rows.Add(Convert.ToString(e.ProgressPercentage));
            //MessageBox.Show(Convert.ToString(e.ProgressPercentage));

        }

        private async void GetFilmInfo()
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

                                dataGridView1.Rows.Add
                                    (nameFilm,
                                    hall.InnerText.Trim(),
                                    sesionStartTime,
                                    Combine.SessionEndTime(sesionStartTime, timefilmStr),
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

        private void Form1_Load(object sender, EventArgs e)
        {
            GetFilmInfo();


            FilmValue f = new FilmValue();
            f.Name = "123";


            //EncodeHtml myEncode = new EncodeHtml();
            //myEncode.EncodeHtmlAsync();
        }

    

       
    }
}

