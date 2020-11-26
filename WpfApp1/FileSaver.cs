using System;
using System.Windows;
using System.IO;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        
        public void SaveFile()
        {
            PathToSaveWindow pathWind = new PathToSaveWindow();

            if (pathWind.ShowDialog() == true)
            {
                bool isSuccess = true;
                try
                {
                    if (File.Exists($@"{destinationpath}\thrlistNew.xlsx"))
                    {
                        File.Copy($@"{destinationpath}\thrlistNew.xlsx", $@"{pathWind.pathBox.Text}\MyThreadList.xlsx");
                    }
                    else
                    {
                        File.Copy($@"{destinationpath}\{filename}", $@"{pathWind.pathBox.Text}\MyThreadList.xlsx");
                    }  
                }
                catch (DirectoryNotFoundException)
                {
                    isSuccess = false;
                    MessageBox.Show("Указанной директории не существует или вы не переключили раскладку клавиатуры, попробуйте ещё");
                }
                catch (IOException ex)
                {
                    isSuccess = false;
                    MessageBox.Show("Ошибка, что-то пошло не так..." + ex.Message);
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (!isSuccess)
                    {
                        SaveFile();
                    }
                    else
                    {
                        MessageBox.Show("Файл успешно сохранён");
                        isSaved = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы отменили сохранение файла, файл не сохранён!");
            }
        }
    }
}
