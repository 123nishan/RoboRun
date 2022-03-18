using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace RoboRun
{
    public class Item
    {
        public int x;
        public int y;
        public string name;
        public string direction;
        public Item(int x, int y, string name, string direction)
        {
            this.x = x;
            this.y = y;
            this.name = name;
            this.direction = direction;

        }
    }
}
