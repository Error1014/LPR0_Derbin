using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LPR0_Derbin
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        int k = 0;
        public Result(List<Otrezki> otrezki)
        {
            InitializeComponent();
            ShowResult(SortResult(otrezki));

        }
        public List<Otrezki> SortResult(List<Otrezki> otrezki)
        {
            var sort = from o in otrezki.OrderBy(o => o.distance)select o;
            List<Otrezki> result = new List<Otrezki>();
            foreach (var item in sort)
            {
                result.Add(item);
            }
            return result;
        }
        public void ShowResult(List<Otrezki> otrezki)
        {
            foreach (var item in otrezki)
            {
                if (k < 2)
                {
                    ResultRedTextBlock.Text += item.point1 + " - " + item.point2 + ": " + item.distance + "\n";
                }
                else
                {
                    ResultTextBlock.Text += item.point1 + " - " + item.point2 + ": " + item.distance + "\n";
                }
                
                k++;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            this.Close();
            MW.Show();
        }
    }
}
