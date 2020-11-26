using System;
using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<SecurityThreat> threads = new List<SecurityThreat>();//получаемые при запуске данные, с которыми работаем
        private List<SecurityThreat> threadsNew = new List<SecurityThreat>();//получаемые при обновлении данные
        private bool isSaved = false;//был ли сохранён файл на жёстком диске
        private string destinationpath = @"C:\TempLocalDB";//директория, которая создаётся как временное хранилище временного файла
        private string filename = "thrlist.xlsx";//название временного файла
        private object magicBall = new object();//заглушка для потока

        public MainWindow()//инициализация стартовых значений
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
                cbNumberOfRecords.Items.Add("15");
                cbNumberOfRecords.Items.Add("30");
                cbNumberOfRecords.Items.Add("50");
                cbNumberOfRecords.Items.Add("100");
                cbNumberOfRecords.SelectedItem = 15;
                numberOfRecPerPage = 15;
                lblpageInformation.Content = numberOfRecPerPage + " of " + threads.Count;
                btnPrev.IsEnabled = false;
                btnFirst.IsEnabled = false;
                this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Создаёт необходимые директории и файлы, удаляет лишние файлы из директории, заполняет массивы данными
            PrepareWorkspace();
        }

        private void SeekButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadTable.Visibility = Visibility.Visible;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            if (threads.Count == 0)
            {
                MessageBox.Show("База ещё никогда не скачивалась! Сперва скачайте базу!");
                return;
            }
            //закачиваем файл обновлённой базы из интернета 
            DownloadFile($@"{destinationpath}\thrlistNew.xlsx", "https://bdu.fstec.ru/files/documents/thrlist.xlsx");
            threadsNew = new List<SecurityThreat>();
            difference = new Dictionary<SecurityThreat, SecurityThreat>();
            //получение данных их файла
            threadsNew = GetDataFromExcel($@"{destinationpath}\thrlistNew.xlsx");
           
            if(threadsNew != null)
            {
                    //изменения ищутся в новом потоке, так как это может занять продолжительное время
                    new Thread(SearchChanges).Start(); 
            }
            else
            {
               MessageBox.Show("Упс, кажется, новая база не загрузилась, будем работать со старой...");
            } 
        }
        
        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            DetailedThreadWindow detailedThread = new DetailedThreadWindow();
            //заполняет окошко о выделенном объекте информацией о нём
            GetMoreInfo(detailedThread);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //позволяет задать директорию для сохранения файла и сохраняет его, если получилось
            SaveFile();
        }

        //Даём возможность сохранить файл, если этого не было сделано и убираем мусор
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            
            
                if (!isSaved)
                {
                    string msg = "Файл не сохранён. Закрыть без сохранения?";
                    MessageBoxResult result = MessageBox.Show(msg, "Data App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.No)
                    {
                        e.Cancel = true;
                    }
                }
                if (e.Cancel) return;
            
            if (File.Exists($@"{destinationpath}\thrlistNew.xlsx"))
            {
                File.Delete($@"{destinationpath}\thrlistNew.xlsx");
            }
            if (File.Exists($@"{destinationpath}\{filename}"))
            {
                File.Delete($@"{destinationpath}\{filename}");
            }
            if (Directory.Exists($"{destinationpath}"))
            {
                Directory.Delete($"{destinationpath}");
            }
            //здесь можно было бы закрыть эксель и высвободить все ресурсы(Или может реализовать это с деструктором класса Excel?),
            //но в другой раз
        }


    }
}
