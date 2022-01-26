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
            createFigures(0, "black", model_blackFiguresON, 1 );
            createFigures(7, "white", model_whiteFiguresON, -1 );
          //  testFigures2();
        }
        
        
        public void createFigures(int y, string side, List<Figure> list, int direction)
        {
            int x;
            string type;
            for (int i = 0; i < nobles.Count; i++)
            {
                for (int j = 0; j < nobles.ElementAt(i).Value.Length; j++)
                {
                    x = nobles.ElementAt(i).Value[j];
                    type = nobles.ElementAt(i).Key;
                    list.Add( new Figure(x, y, side, type, j) ); //, modelCell
                }
            }

            /*for (int i = 0; i < 8; i++)
            {
                list.Add(new Figure(side, "gyalog", i, i, y + direction));
            }*/
        }
        
        private Dictionary<string, int[]> nobles = new Dictionary<string, int[]>() 
        {
            { "kiraly",new int[]{4} },
            { "kiralyno",new int[]{3} },
            { "huszar",new int[]{1, 6} },
            { "futo",new int[]{2, 5 } },
            { "bastya",new int[]{0, 7 }},
        };

        private List<Figure> model_whiteFiguresON = new List<Figure>();
        private List<Figure> model_blackFiguresON = new List<Figure>();
        private List<Figure> model_whiteFiguresOFF = new List<Figure>();
        private List<Figure> model_blackFiguresOFF = new List<Figure>();
        public List<Figure> Model_whiteFiguresON { get { return model_whiteFiguresON; } set { model_whiteFiguresON = value; } }
        public List<Figure> Model_blackFiguresON { get { return model_blackFiguresON; } set { model_blackFiguresON = value; } }
        public List<Figure> Model_whiteFiguresOFF { get { return model_whiteFiguresOFF; } set { model_whiteFiguresOFF = value; } }
        public List<Figure> Model_blackFiguresOFF { get { return model_blackFiguresOFF; } set { model_blackFiguresOFF = value; } }

        /*
        private void testFigures()
        {
            // only for testing purpose
            // Side = side, Type = type, ID = id, X = x, Y = y, Kick = kick 
            model_whiteFiguresON.Add(new Figure("white", "kiralyno", 1, 0, 7));
            model_whiteFiguresON.Add(new Figure("white", "huszar", 1, 7, 7));
            model_whiteFiguresON.Add(new Figure("white", "kiraly", 1, 3, 3));
            model_whiteFiguresON.Add(new Figure("white", "bastya", 1, 3, 6));
            model_whiteFiguresON.Add(new Figure("white", "futo", 1, 6, 2));
            model_whiteFiguresON.Add(new Figure("white", "bastya", 1, 6, 3));
            model_whiteFiguresON.Add(new Figure("white", "kiralyno", 1, 4, 5));
            model_whiteFiguresON.Add(new Figure("white", "gyalog", 1, 3, 7));

            model_blackFiguresON.Add(new Figure("black", "kiralyno", 1, 0, 1));
            model_blackFiguresON.Add(new Figure("black", "huszar", 1, 4, 2));
            model_blackFiguresON.Add(new Figure("black", "kiraly", 1, 6, 3));
            model_blackFiguresON.Add(new Figure("black", "bastya", 1, 0, 0));
            model_blackFiguresON.Add(new Figure("black", "futo", 1, 2, 6));
            model_blackFiguresON.Add(new Figure("black", "huszar", 1, 4, 1));
            model_blackFiguresON.Add(new Figure("black", "kiralyno", 1, 2, 4));
            model_blackFiguresON.Add(new Figure("black", "gyalog", 1, 5, 4));
        }
    */
    }
}
