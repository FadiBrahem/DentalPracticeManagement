using System.Windows;
using DentalPracticeManagement.ViewModels;

namespace DentalPracticeManagement.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
} 