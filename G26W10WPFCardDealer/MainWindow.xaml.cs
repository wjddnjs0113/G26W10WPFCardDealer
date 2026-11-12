using System.Windows;
using System.Windows.Media.Imaging;

namespace G26W10WPFCardDealer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    private void OnDeal(object sender, RoutedEventArgs e) {
        string[] suits = ["spades", "diamonds", "hearts", "clubs",];
        string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king",];

        int card = Random.Shared.Next(suits.Length * values.Length);

        string suit = suits[card / values.Length];
        string value = values[card % values.Length];

        if (value is "jack" or "queen" or "king")
            suit += "2";

        Card1.Source = new BitmapImage(new($"Images/{value}_of_{suit}.png", UriKind.Relative));
    }
}