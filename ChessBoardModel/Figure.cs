using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Figure
    {
        private string side;
        private string type;
        private int id;
        public int X { get; set; }
        public int Y { get; set; }
        public string Side { get => side; set => side = value; }
        public string Type { get => type; set => type = value; }
        public int ID { get => id; set => id = value; }
        public bool LegalNextMove { get; set; }
        public bool Kick { get; set; }

        //public bool Kick { get ; set ; }

        public Figure(string side, string type, int id,int x, int y) //, bool kick
        {
            Side = side;
            Type = type;
            ID = id;
            X = x;
            Y = y;
//            Kick = kick;
        }
    }
}
