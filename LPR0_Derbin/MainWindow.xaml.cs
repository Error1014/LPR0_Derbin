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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LPR0_Derbin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num = 0;
        public List<Point> points = new List<Point>();
        public List<Otrezki> otrezki = new List<Otrezki>();
        string[] ABC = new string[6] { "A", "B", "C", "D", "E"," "};
        public MainWindow()
        {
            InitializeComponent();
            numTextBlock.Text = "Точка " + ABC[num];
        }

        private void NextKoordinate(object sender, RoutedEventArgs e)
        {
            num++;
            numTextBlock.Text = "Точка " + ABC[num];
            float X = ProverkaPole(textBoxKoor1.Text);
            float Y = ProverkaPole(textBoxKoor2.Text);
            float Z = ProverkaPole(textBoxKoor3.Text);
            ClearPole();
            points.Add(new Point(X, Y, Z));
            if (num != 5) return;
            
            Result result = new Result(GetAllOtrez());
            this.Close();
            result.Show();

        }
        public float ProverkaPole(string s)
        {
            if (s=="" +
                "")
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(s);
            }
        }
        private void ClearPole()
        {
            textBoxKoor1.Text = "";
            textBoxKoor2.Text = "";
            textBoxKoor3.Text = "";

        }

        private List<Otrezki> GetAllOtrez()
        {
            for (int i = 0; i < points.Count(); i++)
            {
                for (int j = i+1; j < points.Count(); j++)
                {
                    //MessageBox.Show(points[j].X.ToString()+" "+ points[j].X.ToString() + " " + points[j].X.ToString());
                    double distance = Math.Sqrt(((points[i].X - points[j].X) * (points[i].X - points[j].X)) + ((points[i].Y - points[j].Y) * (points[i].Y - points[j].Y)) + ((points[i].Z - points[j].Z) * (points[i].Z - points[j].Z)));
                    otrezki.Add(new Otrezki(ABC[i], ABC[j], Math.Round(distance, 3)));
                }
            }
            return otrezki;
        }

        private void textBoxKoor1_TextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",")
               && (!textBox.Text.Contains(".")
               && textBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }

    public class Point
    {
        public float X;
        public float Y;
        public float Z;

        public Point(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
    public class Otrezki
    {
        public string point1;
        public string point2;
        public double distance;
        public Otrezki(string point1,string point2,double distance)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.distance = distance;
        }
    }

 }
