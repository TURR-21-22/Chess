using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Figures
    {
        public Figures()
        {
            //createFigures(0, "black", BlackFiguresON, 1);
            //createFigures(7, "white", WhiteFiguresON, -1);

            testFigures();

        }

        private void testFigures()
        {
            /*
            Side = side;
            Type = type;
            ID = id;
            X = x;
            Y = y;
            Kick = kick;
            */



            WhiteFiguresON.Add(new Figure("white", "kiralyno", 1,   0, 7, false));
            WhiteFiguresON.Add(new Figure("white", "huszar", 1,     7,7, false));
            WhiteFiguresON.Add(new Figure("white", "kiraly", 1,     6,6, false));
            WhiteFiguresON.Add(new Figure("white", "bastya", 1,     3, 6, false));
            WhiteFiguresON.Add(new Figure("white", "futo", 1,       6, 2, false));

            BlackFiguresON.Add(new Figure("black", "kiralyno", 1,   0, 1, false));
            BlackFiguresON.Add(new Figure("black", "huszar", 1,     4, 2, false));
            BlackFiguresON.Add(new Figure("black", "kiraly", 1,     6, 3, false));
            BlackFiguresON.Add(new Figure("black", "bastya", 1,     0, 0, false));
            BlackFiguresON.Add(new Figure("black", "futo", 1,       2, 6, false));

        }


        private void createFigures(int y, string side, List<Figure> list, int direction)
        {
            for (int i = 0; i < nobles.Count; i++)
            {
                for (int j = 0; j < nobles.ElementAt(i).Value.Length; j++)
                {
                    list.Add(new Figure(side, nobles.ElementAt(i).Key, j, nobles.ElementAt(i).Value[j], y,false));
                }
            }
            for (int i = 0; i < 8; i++)
            {
                list.Add(new Figure(side, "gyalog", i, i, y + direction,false));
            }
        }




        private Dictionary<string, int[]> nobles = new Dictionary<string, int[]>() 
        {
            { "kiraly",new int[]{4} },
            { "kiralyno",new int[]{3} },
            { "huszar",new int[]{1, 6} },
            { "futo",new int[]{2, 5 } },
            { "bastya",new int[]{0, 7 }},
        };

        private List<Figure> whiteFiguresON = new List<Figure>();
        private List<Figure> blackFiguresON = new List<Figure>();
        private List<Figure> whiteFiguresOFF = new List<Figure>();
        private List<Figure> blackFiguresOFF= new List<Figure>();
        public List<Figure> WhiteFiguresON
        {
            get { return whiteFiguresON; }
            set { whiteFiguresON = value; }
        }
        public List<Figure> BlackFiguresON
        {
            get { return blackFiguresON; }
            set { blackFiguresON = value; }
        }

        public List<Figure> WhiteFiguresOFF
        {
            get { return whiteFiguresOFF; }
            set { whiteFiguresOFF = value; }
        }
        public List<Figure> BlackFiguresOFF
        {
            get { return blackFiguresOFF; }
            set { blackFiguresOFF = value; }
        }

    }
}
