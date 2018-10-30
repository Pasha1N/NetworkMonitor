using NetworkMonitor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace NetworkMonitor.ViewModel
{
    public class MainViewModel
    {
        private PointCollection points = new PointCollection();
        private INetwork network = new NetworkMock();

        public MainViewModel()
        {

            Point point = new Point(20,20);
            Point point1 = new Point(20,40);
            Point point2 = new Point(10, 20);
            Point point3 = new Point(-50, 20);
            Point point4 = new Point(50, 20);
            Point point5 = new Point(50, 20);



            points.Add(point);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);



        }

        public PointCollection Points => points;

        public void LineDrawing()
        {
            network.GetDataAsync();

        }
    }
}