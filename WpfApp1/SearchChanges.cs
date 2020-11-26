using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Dictionary<SecurityThreat, SecurityThreat> difference = new Dictionary<SecurityThreat, SecurityThreat>();
        public void SearchChanges()
        {
            
            foreach (SecurityThreat item in threads)
            {
                bool flagdel = false;//если элемент был удалён, то останется false

                foreach (SecurityThreat itemNew in threadsNew)
                {
                    if ((item.Id == itemNew.Id))
                    {
                        flagdel = true;
                        if ((item.Name != itemNew.Name) || (item.Description != itemNew.Description) || (item.ImpactObj != itemNew.ImpactObj) || (item.Source != itemNew.Source) || (item.IsAccessibilityViolat != itemNew.IsAccessibilityViolat) || (item.IsConfidentialityViolat != itemNew.IsConfidentialityViolat) || (item.IsIntegrityViolat != itemNew.IsIntegrityViolat))
                        {
                            difference.Add(item, itemNew);
                        }
                        break;
                    }
                }
                if (!flagdel)
                {
                    difference.Add(item, new SecurityThreat("-1", "-1", "-1", "-1", "-1", false, false, false));//вместо удалённого элемента воткнём такую затычку
                }
            }
            foreach (SecurityThreat itemNew in threadsNew)
            {
                bool flagadd = false;//если элемент был добавлен, то останется false
                foreach (SecurityThreat item in threads)
                {
                    if ((item.Id == itemNew.Id))
                    {
                        flagadd = true;
                        break;
                    }

                }
                if (!flagadd)
                {
                    difference.Add(new SecurityThreat("-1", "-1", "-1", "-1", "-1", false, false, false), itemNew);
                }
            }
           
            if (difference.Count == 0)
            {
                lock (magicBall)
                {
                    MessageBox.Show("Изменений нет!");
                    
                }
                return;
            }
            //для каждой пары, где были изменения, выводим их на экран, иначе пустая строка
            foreach (KeyValuePair<SecurityThreat, SecurityThreat> pair in difference)
            {
                DetailedThreadWindow dif = new DetailedThreadWindow();
                if (pair.Key.Id != "УБИ.-1" && pair.Value.Id != "УБИ.-1")
                {
                    dif.ThreadId.Content += pair.Key.Id;
                    if (pair.Key.Name != pair.Value.Name)
                        dif.ThreadName.Content += "Было " + pair.Key.Name + ", cтало " + pair.Value.Name;
                    if (pair.Key.Description != pair.Value.Description)
                        dif.ThreadDesription.Text += "Было " + pair.Key.Description + ", cтало " + pair.Value.Description;
                    if (pair.Key.ImpactObj != pair.Value.ImpactObj)
                        dif.ThreadObject.Text += "Было " + pair.Key.ImpactObj + ", cтало " + pair.Value.ImpactObj;
                    if (pair.Key.Source != pair.Value.Source)
                        dif.ThreadSource.Text += "Было " + pair.Key.Source + ", cтало " + pair.Value.Source;
                    if (pair.Key.IsAccessibilityViolat != pair.Value.IsAccessibilityViolat)
                        dif.AccesViolation.Content += "Было " + pair.Key.IsAccessibilityViolat + ", cтало " + (pair.Value.IsAccessibilityViolat ? "Да" : "Нет");
                    if (pair.Key.IsConfidentialityViolat != pair.Value.IsConfidentialityViolat)
                        dif.ConfViolation.Content += "Было " + pair.Key.IsConfidentialityViolat + ", cтало " + (pair.Value.IsConfidentialityViolat ? "Да" : "Нет");
                    if (pair.Key.IsIntegrityViolat != pair.Value.IsIntegrityViolat)
                        dif.IntegrityViolation.Content += "Было " + pair.Key.IsIntegrityViolat + ", cтало " + (pair.Value.IsIntegrityViolat ? "Да" : "Нет");
                }
                else if (pair.Key.Id == "УБИ.-1")
                {
                    dif.ThreadId.Content += "Такого Уби не было, стало " + pair.Value.Id;
                    dif.ThreadName.Content += "Новая информация: " + pair.Value.Name;
                    dif.ThreadDesription.Text += "Новая информация: " + pair.Value.Description;
                    dif.ThreadObject.Text += "Новая информация: " + pair.Value.ImpactObj;
                    dif.ThreadSource.Text += "Новая информация: " + pair.Value.Source;
                    dif.AccesViolation.Content += "Новая информация: " + (pair.Value.IsAccessibilityViolat ? "Да" : "Нет");
                    dif.ConfViolation.Content += "Новая информация: " + (pair.Value.IsConfidentialityViolat ? "Да" : "Нет");
                    dif.IntegrityViolation.Content += "Новая информация: " + (pair.Value.IsIntegrityViolat ? "Да" : "Нет");
                }
                else
                {
                    dif.ThreadId.Content += "Следующее Уби было удалено" + pair.Key.Id;
                    dif.ThreadName.Content += "Удалена информация: " + pair.Key.Name;
                    dif.ThreadDesription.Text += "Удалена информация: " + pair.Key.Description;
                    dif.ThreadObject.Text += "Удалена информация: " + pair.Key.ImpactObj;
                    dif.ThreadSource.Text += "Удалена информация: " + pair.Key.Source;
                    dif.AccesViolation.Content += "Удалена информация: " + (pair.Key.IsAccessibilityViolat ? "Да" : "Нет");
                    dif.ConfViolation.Content += "Удалена информация: " + (pair.Key.IsConfidentialityViolat ? "Да" : "Нет");
                    dif.IntegrityViolation.Content += "Удалена информация: " + (pair.Key.IsIntegrityViolat?"Да":"Нет");
                }
                dif.ShowDialog();
            }
            ThreadTable.ItemsSource = threads.Take(Convert.ToInt32(cbNumberOfRecords.SelectedItem));
   
            lock (magicBall)//обновляем данные
            {
                threads = threadsNew;
                ThreadTable.Items.Refresh();
            }
        }
    }

}
