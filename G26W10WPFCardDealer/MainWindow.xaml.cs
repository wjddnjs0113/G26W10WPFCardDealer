using System.Windows;

namespace G26W10WPFCardDealer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        DataContext = new CardViewModel(new CardModel());
    }
}