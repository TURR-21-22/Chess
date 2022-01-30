using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Side { get; set; }
        public string Type { get; set; }
        public int ID { get; set; }
        public bool Replaceable { get; set; }
        public bool LegalNextMove { get; set; }
        public Cell Cell { get; set; }
        public bool Kick { get; set; }
        

        public Figure(int x, int y, string side, string type, int id, bool replaceable)
        {
            X = x;
            Y = y;
            Side = side;
            Type = type;
            ID = id;
            Replaceable = replaceable;
        }
    }
}
