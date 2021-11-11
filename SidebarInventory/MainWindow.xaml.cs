using System;
using System.Windows;
using System.Windows.Controls;

namespace SidebarInventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ViewModel();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rect.Visibility == System.Windows.Visibility.Collapsed)
            {
                rect.Visibility = System.Windows.Visibility.Visible;
                (sender as Button).Content = "❮";
            }
            else
            {
                rect.Visibility = System.Windows.Visibility.Collapsed;
                (sender as Button).Content = "❯";
            }
        }


        private void Window_Deactivated(object sender, EventArgs e)
        {
            rect.Visibility = System.Windows.Visibility.Collapsed;
            openButton.Content = "❯";
        }

        private void ListViewScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void SpecialCharacter_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText((sender as Button).Content.ToString());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
