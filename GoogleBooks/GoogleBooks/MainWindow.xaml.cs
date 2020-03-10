using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GoogleBooks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Laden(object sender, RoutedEventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={suchTb.Text}";

            var web = new HttpClient();
            var json = await web.GetStringAsync(url);

            BooksResult result = JsonConvert.DeserializeObject<BooksResult>(json);

            myGrid.ItemsSource = result.items.Select(x => x.volumeInfo).ToList();

        }

        private async void HalloAsync(object sender, RoutedEventArgs e)
        {
            //stop UI 
            //https://stackoverflow.com/a/3383010
            var d = Dispatcher.DisableProcessing();


            ((Button)sender).IsEnabled = !true;

            for (int i = 0; i < 100; i++)
            {
                pb1.Value = i;
                await Task.Delay(100);
                var sr = new StreamReader(@"E:\eula.txt");
                var txt = await sr.ReadToEndAsync();
            }
            ((Button)sender).IsEnabled = !!true;

            d.Dispose();
        }

        private void HalloTask(object sender, RoutedEventArgs e)
        {
            //Dispatcher = doof aber geht: muss auf UI warten
            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        pb1.Dispatcher.Invoke(() => pb1.Value = i);
            //        Thread.Sleep(100);
            //    }
            //});


            //cool: ab .NET 4
            ((Button)sender).IsEnabled = !true;
            var ts = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Task.Factory.StartNew(() => pb1.Value = i, CancellationToken.None, TaskCreationOptions.None, ts);
                    Thread.Sleep(50);
                }
                Task.Factory.StartNew(() => ((Button)sender).IsEnabled = true, CancellationToken.None, TaskCreationOptions.None, ts);
            });

        }
    }
}
