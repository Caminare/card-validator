using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidadorCartao.Classe;

namespace ValidadorCartao.Repositorio
{
    public class Validator
    {
        public Card ValidateCard(string card)
        {
            if (!IsValidLength(card))
                return new Card("Unknown", false);

            string type = CheckCardType(card);
            bool valid = IsValidCard(card);

            var creditCard = new Card(type, valid);

            return creditCard;
        }



        public bool IsValidLength(string card)
        {
            return card.Length >= 13 && card.Length <= 16;
        }

        public string CheckCardType(string card)
        {
            var start = card.Substring(0, 3);

            string type = card.StartsWith("4") 
                ? "Visa" : card.StartsWith("6011") 
                ? "Discover" : (card.StartsWith("34") || card.StartsWith("37")) 
                ? "AMEX" : "Mastercard";

            return type;
        }

        public bool IsValidCard(string card)
        {
            var cardNumbers = card.Select(x => new string(x, 1)).ToArray().Reverse();
            int[] numbers = cardNumbers.Select(x => Convert.ToInt32(x)).ToArray();
            var count = 1;
            List<int> newNumbers = new List<int>();

            foreach (var number in numbers)
            {
                int[] arr = { };
                var newNumber = 0;

                if (count % 2 == 0)
                    newNumber = number * 2;
                else
                    newNumber = number;

                if (newNumber.ToString().Length > 1)
                    newNumber = newNumber.ToString()
                        .Select(x => Convert.ToInt32(new string(x, 1))).Sum();

                count++;

                newNumbers.Add(newNumber);
            }

            var sum = newNumbers.Sum();

            return sum % 10 == 0;

        }
    }
}
