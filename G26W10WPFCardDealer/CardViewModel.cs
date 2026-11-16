using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace G26W10WPFCardDealer;

public partial class CardViewModel(
    CardModel model
) : ObservableObject {

    [ObservableProperty]
    private ObservableCollection<string> _cardResource = [..
        Enumerable.Repeat("Images/black_joker.png", CardModel.NUMBER_OF_CARDS)
    ];

    [RelayCommand]
    public void DealCards() {
        model.DealCards();

        for (int i = 0; i < model.Cards.Count; i++) {
            CardResource[i] = GetCardImageName(model.Cards[i]);
        }
    }

    private string GetCardImageName(Card card) {
        string[] suits = ["spades", "diamonds", "hearts", "clubs"];
        string[] values = ["ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king"];

        if (card.Suit < 0 || card.Value < 0)
            return "Images/black_joker.png";

        string suit = suits[card.Suit];
        string value = values[card.Value];

        return value is "jack" or "queen" or "king"
            ? $"Images/{value}_of_{suit}2.png"
            : $"Images/{value}_of_{suit}.png";
    }
}
