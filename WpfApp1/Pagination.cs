using System;
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
    partial class MainWindow : Window
    {
        private enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4, PageCountChange = 5 };
        public int pageIndex = 1;
        private int numberOfRecPerPage;

       
        public void btnFirst_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.First);
        }

        public void btnNext_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Next);

        }

        public void btnPrev_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Previous);

        }

        public void btnLast_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Last);
        }

        public void cbNumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigate((int)PagingMode.PageCountChange);
        }
        private void Navigate(int mode)
        {
            int count;
            switch (mode)
            {
                
                case (int)PagingMode.Next:
                    btnPrev.IsEnabled = true;
                    btnFirst.IsEnabled = true;
                  
                    if (threads.Count >= (pageIndex * numberOfRecPerPage))
                    {
                        ThreadTable.ItemsSource = null;
                        count = (pageIndex * numberOfRecPerPage) + (threads.Skip(pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage)).Count();
                        
                        if (threads.Skip(pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage).Count() == 0)
                        {
                            
                            ThreadTable.ItemsSource = threads.Skip((pageIndex * numberOfRecPerPage) - numberOfRecPerPage).Take(numberOfRecPerPage);
                           
                        }
                    
                        else
                        {
                            ThreadTable.ItemsSource = threads.Skip(pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage);
                            
                            pageIndex++;
                        }
                        if (count == threads.Count)
                        {
                            btnNext.IsEnabled = false;
                            btnLast.IsEnabled = false;
                           
                        }

                        lblpageInformation.Content = count + " of " + threads.Count;
                    }
                    break;
                case (int)PagingMode.Previous:
                    btnNext.IsEnabled = true;
                    btnLast.IsEnabled = true;
                    if (pageIndex > 1)
                    {
                        pageIndex --;
                        ThreadTable.ItemsSource = null;
                        if (pageIndex == 1)
                        {
                            btnPrev.IsEnabled = false;
                            btnFirst.IsEnabled = false;
                            ThreadTable.ItemsSource = threads.Take(numberOfRecPerPage);
                            count = threads.Take(numberOfRecPerPage).Count();
                            lblpageInformation.Content = count + " of " + threads.Count;
                        }
                        else
                        {
                            
                            count = Math.Min(pageIndex * numberOfRecPerPage, threads.Count);
                            
                                ThreadTable.ItemsSource = threads.Skip(pageIndex * numberOfRecPerPage - numberOfRecPerPage).Take(numberOfRecPerPage);
             
                            lblpageInformation.Content = count + " of " + threads.Count;
                        }
                    }
                    
                    break;

                case (int)PagingMode.First:
                    pageIndex = 2;
                    Navigate((int)PagingMode.Previous);
                    break;
                case (int)PagingMode.Last:
                    pageIndex = (threads.Count / numberOfRecPerPage);
                    Navigate((int)PagingMode.Next);
                    break;

                case (int)PagingMode.PageCountChange:
                    pageIndex = 1;
                    numberOfRecPerPage = Convert.ToInt32(cbNumberOfRecords.SelectedItem);
                    ThreadTable.ItemsSource = null;
                    ThreadTable.ItemsSource = threads.Take(numberOfRecPerPage);
                    count = (threads.Take(numberOfRecPerPage)).Count();
                    lblpageInformation.Content = count + " of " + threads.Count;
                    btnNext.IsEnabled = true;
                    btnLast.IsEnabled = true;
                    btnPrev.IsEnabled = true;
                    btnFirst.IsEnabled = true;
                    break;
            }
        }
    }
}
