// 이게 있다면 삭제할 것
//using System.Drawing;
// 대신 이거 넣을 것
using System.Windows.Controls;

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

        // 0~51까지의 숫자를 갖는 카드 덱 생성
        int[] cardDeck = Enumerable.Range(0, 52).ToArray();

        // 배열의 순서를 섞음
        Random.Shared.Shuffle(cardDeck);

        // 카드 덱에서 앞에 있는 5장의 카드만 뽑기
        // Spread operator (스프레드 연산자) 사용해서 List 생성
        List<int> cardList = [.. cardDeck.Take(5)];
        cardList.Sort();

        for (int i = 0; i < cardList.Count; i++) {
            string suit = suits[cardList[i] / values.Length];
            string value = values[cardList[i] % values.Length];

            // Jack, Queen, King일 때 suit 뒤에 2 붙이기
            if (value is "jack" or "queen" or "king")
                suit += "2";

            if (FindName($"Card{i + 1}") is Image imageCard) {
                imageCard.Source = new BitmapImage(new($"Images/{value}_of_{suit}.png", UriKind.Relative));
            }
        }
    }
}