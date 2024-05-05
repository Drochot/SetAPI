using SetAPI.models;

namespace SetAPI.Services
{
    public class SetService : ISetService
    {
        int setCount = 0;
        Card[] setToCheck = new Card[3];

        public int CountSetsOnBoard(Card[] deck, int numCardsOnBoard)
        {
            setCount = 0;
            Card[] cardsOnBoard = new Card[numCardsOnBoard];


            for (int i = 0; i < numCardsOnBoard; i++)
            {
                cardsOnBoard[i] = deck[i];
            }

            CountSets(cardsOnBoard, 0);

            return setCount / 6;
        }

        public bool ValidateSet(Card[] cards)
        {
            if (cards.Length != 3)
            {
                return false;
            }

            // check if cards are identical
            if (cards[0] == cards[1] || cards[0] == cards[2] || cards[1] == cards[2])
            {
                return false;
            }

            if (cards[0].Shape != cards[1].Shape && cards[0].Shape != cards[2].Shape && cards[1].Shape != cards[2].Shape || cards[0].Shape == cards[1].Shape && cards[1].Shape == cards[2].Shape)
            {
                if (cards[0].Color != cards[1].Color && cards[0].Color != cards[2].Color && cards[1].Color != cards[2].Color || cards[0].Color == cards[1].Color && cards[1].Color == cards[2].Color)
                {
                    if (cards[0].Fill != cards[1].Fill && cards[0].Fill != cards[2].Fill && cards[1].Fill != cards[2].Fill || cards[0].Fill == cards[1].Fill && cards[1].Fill == cards[2].Fill)
                    {
                        if (cards[0].Number != cards[1].Number && cards[0].Number != cards[2].Number && cards[1].Number != cards[2].Number || cards[0].Number == cards[1].Number && cards[1].Number == cards[2].Number)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CountSets(Card[] cards, int cardNumber)
        {
            if (cardNumber >= 3)
            {
                if (ValidateSet(setToCheck))
                {
                    setCount++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            for (int i = 0; i < cards.Length; i++)
            {
                setToCheck[cardNumber] = cards[i];
                CountSets(cards, cardNumber + 1);
            }
            return false;
        }

        public Card[] FindHint(Card[] cards, int cardNumber)
        {
            if (cardNumber >= 3)
            {
                if (ValidateSet(setToCheck))
                {
                    return setToCheck;
                }
                else{
                    return null;
                }
            }
            for (int i = 0; i < cards.Length; i++)
            {
                setToCheck[cardNumber] = cards[i];
                if( FindHint(cards, cardNumber + 1) != null) {
                    return setToCheck;
                }
            }
            return null;
        }
    }
}