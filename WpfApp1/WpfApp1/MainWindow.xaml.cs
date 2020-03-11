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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var daten = new List<Tag>();
            var ran = new Random();
            for (int i = 0; i < 10; i++)
            {
                var t = new Tag() { Date = DateTime.Now.AddDays(i) };
                t.Zeug.Add(new Zeug() { Text = ran.Next().ToString() }); 
                t.Zeug.Add(new Zeug() { Text = ran.Next().ToString() }); 
                t.Zeug.Add(new Zeug() { Text = ran.Next().ToString() }); 
                t.Zeug.Add(new Zeug() { Text = ran.Next().ToString() }); 
                daten.Add(t);
            }
            treeView.ItemsSource = daten;
        }
    }

    public class Tag
    {
        public DateTime Date { get; set; }

        public List<Zeug> Zeug { get; set; } = new List<Zeug>();
    }

    public class Zeug
    {
        public string Text { get; set; }
    }

}
