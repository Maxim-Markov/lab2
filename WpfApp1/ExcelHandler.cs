using System;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        public List<SecurityThreat> GetDataFromExcel(string fullpath)
            {
            try
            {
                oXL = new Excel.Application
                {
                    Visible = false
                };
                oWB = oXL.Workbooks.Open(fullpath, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            int tableRow = 3;
            List<SecurityThreat> whereToRecordList = new List<SecurityThreat>();
            while ((Convert.ToString(oSheet.Cells[tableRow, 1].Value2)) != null)
            {
                whereToRecordList.Add(new SecurityThreat(
                    Convert.ToString(oSheet.Cells[tableRow, 1].Value2),
                    Convert.ToString(oSheet.Cells[tableRow, 2].Value2),
                    Convert.ToString(oSheet.Cells[tableRow, 3].Value2),
                    Convert.ToString(oSheet.Cells[tableRow, 4].Value2),
                    Convert.ToString(oSheet.Cells[tableRow, 5].Value2),
                    Convert.ToBoolean(oSheet.Cells[tableRow, 6].Value2),
                    Convert.ToBoolean(oSheet.Cells[tableRow, 7].Value2),
                    Convert.ToBoolean(oSheet.Cells[tableRow, 8].Value2)));
                tableRow++;
            }
            return whereToRecordList;
        }
    }
}
