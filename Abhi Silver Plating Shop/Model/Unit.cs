using System;
using System.Collections.Generic;
using System.Text;

namespace Abhi_Silver_Plating_Shop.Model
{
    class Unit
    {
        private string id;
        private string name;
        private Double rate;

        public Unit()
        {
        }

        public Unit(string id, string name, Double rate)
        {
            this.Id = id;
            this.Name = name;
            this.Rate = rate;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name?.ToUpper(); set => name = value?.ToUpper(); }
        public Double Rate { get => rate; set => rate = value; }
    }
}
