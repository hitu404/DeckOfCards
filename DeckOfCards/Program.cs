using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    //Interface for card which can be extended to create any card-trump cards,uno card etc
    public interface ICard
    {
        int Rank { get; set; }
        int Suit { get; set; }

    }

    //Card class which is implementing ICard interface
    public class Card : ICard
    {

        int rank;
        int suit;
        public int Rank { get => rank; set => rank = value; }
        public int Suit { get => suit; set => suit = value; }

        public enum Suits { Clubs = 1, Diamonds, Hearts, Spades };

        public enum Ranks { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

        public Card(int rank, int suit)
        {
            Rank = rank;
            Suit = suit;
        }
    }


   
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards deck = new DeckOfCards();
            
            Card card;
            //try catch since card can be null
            try
            {
                //if deck of cards has any card then only draw top card
                if (deck.deckOfCards.Count > 0)
                {
                    card = DeckOfCards.PlayTopCard(deck.deckOfCards);
                    Console.WriteLine("Rank of card is " + Enum.GetName(typeof(Card.Ranks), card.Rank) + "& Suit of card is " + Enum.GetName(typeof(Card.Suits), card.Suit));
                }

                //shuffling the cards
                DeckOfCards.Shuffle(deck.deckOfCards);

                // Printing all shuffled elements of cards 
                for (int i = 0; i < deck.deckOfCards.Count; i++)
                    Console.WriteLine("Rank of Card is " + Enum.GetName(typeof(Card.Ranks), deck.deckOfCards[i].Rank) + " & Suit of card is " + Enum.GetName(typeof(Card.Suits), deck.deckOfCards[i].Suit) + " ");

                Console.ReadLine();

                //Restarting the game
                DeckOfCards.RestartGame(deck.deckOfCards);

                card = DeckOfCards.PlayTopCard(deck.deckOfCards);

                Console.WriteLine("Rank of card is " + Enum.GetName(typeof(Card.Ranks), card.Rank) + "& Suit of card is " + Enum.GetName(typeof(Card.Suits), card.Suit));

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

    }

    public class DeckOfCards
    {
        //List to hold cards
        public List<Card> deckOfCards;
        //Count of cards i.e 52 in normal card game, might differ in UNO etc
        public int countOfCards;
        public DeckOfCards()    
        {
            deckOfCards = new List<Card>();
            CreateGame(deckOfCards);          

        }

        //Shuffles the deck using random number
        public static void Shuffle(List<Card> cards)
        {
            Random rand = new Random();
            int countOfCards = cards.Count;

            for (int i = 0; i < countOfCards; i++)
            {
                // Random for remaining positions. 
                int index = rand.Next(i + 1);

                //swapping the elements 
                Card temp = cards[i];
                cards[i] = cards[index];
                cards[index] = temp;

            }
        }

        //Whenever user plays, card at top will be played and removed from list of cards
        public static Card PlayTopCard(List<Card> cards)
        {
            
            Card drawnCard = cards[0];
            cards.RemoveAt(0);
            return drawnCard;
        }

        public static void RestartGame(List<Card> cards)
        {
            //reusing create game method to restart the game i.e reinitializing cards list
            CreateGame(cards);
        }

        //Method to reinitialize cards list
        private static void CreateGame(List<Card> cards)
        {
            cards.Clear();
            
            //Creating cards for each type
            for (int suit = (int)Card.Suits.Clubs; suit <= (int)Card.Suits.Spades; suit++)
                for (int rank = (int)Card.Ranks.Ace; rank <= (int)Card.Ranks.King; rank++)
                    cards.Add(new Card(rank, suit));
        }

    }

   
}
