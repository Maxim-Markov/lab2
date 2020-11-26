using System;
using System.Windows;
using System.Net;
using System.ComponentModel;
using System.Net.Security;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        
        public void DownloadFile(string fullpath,string url)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("У вас нет доступа в Интернет");
            }
            else
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.KeepAlive = true;
                req.Credentials = CredentialCache.DefaultCredentials;
                /*  ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls//протоколы для использования
                                                         | SecurityProtocolType.Tls11
                                                         | SecurityProtocolType.Tls12
                                                         | SecurityProtocolType.Ssl3;
                  // Пропускаем валидацию ответного сертификата SSL/TLS 
                  ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);*/
                try
                {
                    WebResponse respon = req.GetResponse();
                    Stream responce = respon.GetResponseStream();
                    FileStream file = new FileStream(fullpath, FileMode.Create);
                    responce.CopyTo(file);
                }
                /*
                WebClient downloader = new WebClient();
                // как будто запрос был от браузера
                downloader.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
                downloader.DownloadFile(new Uri(url), fullpath);
                /*
                //обновляем состояние ползунка и статуса загрузки
                downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClientDownloadCompleted);
                downloader.DownloadProgressChanged +=
                    new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            
           */

                catch (WebException ex)
                {
                    MessageBox.Show("Файл закачать не удалось, возникла ошибка: " + ex.Message + @"Попробуйте обновить базу данных или положите файл thrlist.xlsx в папку C:\tempLocalDB");
                    File.Delete(fullpath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + @"Попробуйте обновить базу данных или положите файл thrlist.xlsx в папку C:\tempLocalDB");
                }
            }
        }
        private static bool AlwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            DownloadStatusBox.Text = "In progress";
        }
        private void WebClientDownloadCompleted(object sender, AsyncCompletedEventArgs args)
        {
            if (args.Cancelled)
            {
                MessageBox.Show(args.Error.ToString());
            }
            else
            {
                DownloadStatusBox.Text = "Downloaded";
            }
        }
    }
}
