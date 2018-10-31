using NetworkMonitor.Services;
using System;
using System.Collections.Generic;
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
    public class MainViewModel
    {
       private NetworkMonitor.Command.Command commandTheStart;
        private PointCollection points = new PointCollection();
        private INetwork network = new NetworkMock();

        public MainViewModel()
        {
            {
                Point point = new Point(0, 0);
                Point point1 = new Point(2,301);
                Point point2 = new Point(4, 0);
                Point point3 = new Point(6, 301);
               Point point4 = new Point(8, 0);
               Point point5 = new Point(10, 301);


                points.Add(point);
                points.Add(point1);
                points.Add(point2);
                points.Add(point3);
                points.Add(point4);
                points.Add(point5);

            }

            commandTheStart = new NetworkMonitor.Command.DelegateCommand(Start);

        }

        public PointCollection Points => points;
        public ICommand CommandTheStart => commandTheStart;


        public void LineDrawing()
        {
            network.GetDataAsync();

        }

        private void Start()
        {
            int stringsHeigth = 25 * 2;
            int indentation = (3 * 2) + (2 * 2);

            var heigth = ((System.Windows.Controls.Panel)System.Windows.Application.Current.MainWindow.Content).ActualHeight;
            var width = ((System.Windows.Controls.Panel)System.Windows.Application.Current.MainWindow.Content).ActualWidth;

            heigth -= stringsHeigth;
            heigth -= indentation;
            bool work = true;

            //while (work)
           // {
            //    network.GetDataAsync();

           //   byte  2000
          //         heigth 136
          //          =
          //  }



        }
    }
}