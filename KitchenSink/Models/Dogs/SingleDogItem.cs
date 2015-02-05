using System;
using System.Collections.Generic;

namespace KitchenSink.Models.Dogs
{
    public class SingleDogItem
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public decimal AverageCost { get; set; }
        public int NumberAvailable { get; set; }
        public bool IsMale { get; set; }
        public DateTime Birthday { get; set; }
        public IEnumerable<SingleDogItemPicture> Pictures { get; set; }
    }
}