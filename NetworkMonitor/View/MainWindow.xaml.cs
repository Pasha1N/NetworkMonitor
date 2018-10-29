using NetworkMonitor.ViewModel;
using System.Windows;

namespace NetworkMonitor.View
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}