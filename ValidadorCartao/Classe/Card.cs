using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidadorCartao.Classe
{
    public class Card
    {
        public Card(string CardType, bool Valid)
        {
            this.cardType = CardType;
            this.valid = Valid;
        }

        public string cardType { get; set; }

        public bool valid { get; set; }
    }
}
