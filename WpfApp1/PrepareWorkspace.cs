using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Linq;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public void PrepareWorkspace()
        {
            if (!Directory.Exists(destinationpath))
            {
                Directory.CreateDirectory(destinationpath);
            }
            string[] files = Directory.GetFiles(destinationpath);
            string[] directories = Directory.GetDirectories(destinationpath);
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i] != $@"{destinationpath}\{filename}")
                {
                    File.Delete(files[i]);
                }
            }
            for (int i = 0; i < directories.Length; i++)
            {
                Directory.Delete(directories[i], true);
            }
            if (!File.Exists($@"{destinationpath}\{filename}"))
            {
                MessageBoxResult result = MessageBox.Show("Загрузить данные?",
                        "Локальная база отсутствует на компьютере",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question,
                        MessageBoxResult.Yes,
                        MessageBoxOptions.DefaultDesktopOnly);
                while (result != MessageBoxResult.Yes)
                {

                    result = MessageBox.Show("До тех пор, пока данные не будут загружены, продолжить работу невозможно." +
                        "Загрузить данные?",
                       "Локальная база отсутствует на компьютере",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Error,
                       MessageBoxResult.Yes,
                       MessageBoxOptions.DefaultDesktopOnly);
                }
                DownloadFile($@"{destinationpath}\{filename}", "https://bdu.fstec.ru/files/documents/thrlist.xlsx");
            }
            progressBar.Value = 100;
            DownloadStatusBox.Text = "Downloaded";
            threads = new List<SecurityThreat>();
            threads = GetDataFromExcel($@"{destinationpath}\{filename}");//в случае неудачи вернёт null
            if(threads == null)
            {
                MessageBox.Show("Будет использована самая свежая на 26.11.2020 база данных");
                File.Copy(Directory.GetCurrentDirectory() + "\\thrlist.xlsx", $@"{destinationpath}\{filename}",true);
               threads = GetDataFromExcel($@"{destinationpath}\{filename}");
            }
            ThreadTable.ItemsSource = threads.Take(numberOfRecPerPage);

        }
    }
}
