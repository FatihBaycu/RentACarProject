using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Card:IEntity
    {
        public int id { get; set; }
        public string CardNumber { get; set; }
        public string CardOnName { get; set; }
        public string CardValidDate { get; set; }
        public int CardCvv { get; set; }
        public int CustomerId { get; set; }
        public string cardType { get; set; }

    }
}
