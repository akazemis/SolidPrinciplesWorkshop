using System;

namespace DIP.Examples.Example01
{
    public class Item
    {
        public string ID { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}