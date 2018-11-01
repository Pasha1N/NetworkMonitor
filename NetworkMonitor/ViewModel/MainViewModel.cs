using NetworkMonitor.Services;
using NetworkMonitor.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NetworkMonitor.ViewModel
{
    public class MainViewModel : EventINotifyPropertyChanged
    {
        private NetworkMonitor.Command.Command commandTheStart;
        private PointCollection points = new PointCollection();
        private INetwork network = new NetworkMock();
        private int x = 1;
        private int y = 301;

        public MainViewModel()
        {
            {
                //Point point = new Point(0, 0);
                //Point point1 = new Point(2, 301);
                //Point point2 = new Point(4, 0);
                //Point point3 = new Point(6, 301);
                //Point point4 = new Point(8, 0);
                //Point point5 = new Point(10, 301);


                //points.Add(point);
                //points.Add(point1);
                //points.Add(point2);
                //points.Add(point3);
                //points.Add(point4);
                //points.Add(point5);

            }

            commandTheStart = new NetworkMonitor.Command.DelegateCommand(Start);
        }

        public PointCollection Points
        {
            get => points;
            set => SetProperty(ref points, value);

        }

        public ICommand CommandTheStart => commandTheStart;

        public void LineDrawing()
        {
            network.GetDataAsync();

        }

        private async void Start()
        {

            int stringsHeigth = 25;
            int indentation = 5; 

            var heigth = ((System.Windows.Controls.Panel)System.Windows.Application.Current.MainWindow.Content).ActualHeight;
          //  var width = ((System.Windows.Controls.Panel)System.Windows.Application.Current.MainWindow.Content).ActualWidth;

            heigth -= stringsHeigth * 2;
            heigth -= indentation * 2;
            bool work = true;

            int f = 0;

            while (work)
            {
                byte[] bytes = await network.GetDataAsync();

                x += 2;


                Point point = new Point(x, y);
                points.Add(point);
                PointCollection points1 = new PointCollection(points);
                Points = points1;

                if (f == 10)
                {
                    break;
                }
                f += 1;
            }
        }
    }
}

