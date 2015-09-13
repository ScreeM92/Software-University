using System;
class PrintADeckOf52Cards
    {
        static void Main()
        {
            for (int i = 0; i < 52; i++)
            {
                string card = string.Empty;
                string suit = string.Empty;
                switch ((i %13)  + 2)
                {
                    case 11: card = "J"; break;
                    case 12: card = "Q"; break;
                    case 13: card = "K"; break;
                    case 14: card = "A"; break;
                    default:
                        card = ((i %13 )+ 2).ToString();
                        break;
                }
                switch ((i /13)% 4)
                {
                    case 0: suit = "♠"; break;
                    case 1: suit = "♥"; break;
                    case 2: suit = "♦"; break;
                    case 3: suit = "♣"; break;
                    default:
                        break;
                }

                Console.WriteLine("{0} {1}", card, suit);
            }
        }
    }

