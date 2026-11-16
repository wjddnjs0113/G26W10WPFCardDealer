namespace G26W10WPFCardDealer;

public record Card(int Suit, int Value) {
    public static readonly int NUMBER_OF_SUITS = 4;
    public static readonly int NUMBER_OF_VALUES = 13;

    public Card(int number)
        : this(number / NUMBER_OF_VALUES, number % NUMBER_OF_VALUES) { }
}

public class CardModel {
    public static readonly int NUMBER_OF_CARDS = 5;

    // -1, -1이면 Jocker 출력
    private readonly List<Card> _cards = [.. Enumerable.Repeat(new Card(-1, -1), NUMBER_OF_CARDS)];
    public List<Card> Cards => _cards;

    public void DealCards() {
        // 0~51까지의 숫자를 갖는 카드 덱 생성
        int[] cardDeck = Enumerable.Range(0, 52).ToArray();

        // 배열의 순서를 섞음
        Random.Shared.Shuffle(cardDeck);

        // 카드 덱에서 앞에 있는 5장의 카드만 뽑기
        // Spread operator (스프레드 연산자) 사용해서 List 생성
        List<int> cardList = [.. cardDeck.Take(5)];
        cardList.Sort();

        _cards.Clear();
        foreach (var cardNumber in cardList) {
            _cards.Add(new Card(cardNumber));
        }
    }
}