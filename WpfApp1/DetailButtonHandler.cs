using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.ComponentModel;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private void GetMoreInfo(DetailedThreadWindow detailedThread)
        {
            int curIndex = ThreadTable.SelectedIndex + (pageIndex - 1) * (numberOfRecPerPage);
            if (curIndex == -1) {
                MessageBox.Show("Ничего не выбрано");
                return;
            }
            else
            {
                detailedThread.ThreadId.Content += threads[curIndex].Id;
                detailedThread.ThreadName.Content += threads[curIndex].Name;
                detailedThread.ThreadDesription.Text += threads[curIndex].Description;
                detailedThread.ThreadObject.Text += threads[curIndex].ImpactObj;
                detailedThread.ThreadSource.Text += threads[curIndex].Source;
                if (threads[curIndex].IsAccessibilityViolat)
                {
                    detailedThread.AccesViolation.Content += "Да";
                }
                else
                {
                    detailedThread.AccesViolation.Content += "Нет";
                }
                if (threads[curIndex].IsIntegrityViolat)
                {
                    detailedThread.IntegrityViolation.Content += "Да";
                }
                else
                {
                    detailedThread.IntegrityViolation.Content += "Нет";
                }
                if (threads[curIndex].IsConfidentialityViolat)
                {
                    detailedThread.ConfViolation.Content += "Да";
                }
                else
                {
                    detailedThread.ConfViolation.Content += "Нет";
                }
            }
            detailedThread.ShowDialog();
        }
    }
}
