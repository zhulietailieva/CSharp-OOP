using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Cards
{
    public class Card
    {
        public Card(string face, char suit)
        {
            //2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A
            if (face != "2" && face != "3" && face != "4"
                && face != "5" && face != "6" && face != "7"
                && face != "8" && face != "9" && face != "10"
                && face != "J" && face != "Q" && face != "K" && face != "A") throw new FormatException("Invalid card!");

            if (suit != 'S' && suit != 'H' && suit != 'D' && suit != 'C')
                throw new FormatException("Invalid card!");

            this.Face = face;
            this.Suit = suit;

        }
        public string Face { get; private set; }
        public char Suit { get; private set; }

        public override string ToString()
        {
            char symbol;
            switch (Suit)
            {
                case 'S': symbol = '\u2660'; break;
                case 'H': symbol = '\u2665'; break;
                case 'D': symbol = '\u2666'; break;
                case 'C': symbol = '\u2663'; break;
                default: symbol = 'n'; break;
            }
            return $"[{this.Face}{symbol}]";
        }
    }
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Card> validCards = new List<Card>();

            string[] cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < cards.Length; i++)
            {
                string[] cardInp = cards[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string face = cardInp[0];
                char suit = cardInp[1].ToCharArray()[0];
                Card card;
                try
                {
                    card = new Card(face, suit);
                    validCards.Add(card);
                }
                catch (FormatException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
                StringBuilder sb = new StringBuilder();
            foreach (var c in validCards)
            {              
                sb.Append(c.ToString() + " ");
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}