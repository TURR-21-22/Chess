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
            //createFigures(0, "black", model_blackFiguresON, 1 );
            //createFigures(7, "white", model_whiteFiguresON, -1 );
            testFigures();
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
                    list.Add(new Figure(x, y, side, type, j));
                }
            }
            for (int i = 0; i < 8; i++)
            {
                list.Add(new Figure(i, y + direction, side, "gyalog", i));
            }
        }


        private void testFigures()
        {
            object[,] whiteGroup = new object[8, 5]{

                { 4, 3, "white", "kiraly",1 },
                { 7, 7, "white", "kiralyno",1 },
                { 7, 2, "white", "bastya", 1 },
                { 4, 2, "white", "huszar", 1 },
                { 3, 0, "white", "futo", 1 },
                { 5, 5, "white", "gyalog", 1 },
                { 3, 5, "white", "gyalog", 2 },
                { 7, 0, "white", "gyalog", 3 }
            };
            object[,] blackGroup = new object[8,5] {
                { 0, 0, "black", "kiraly",1 },
                { 1, 1, "black", "kiralyno",1 },
                { 2, 4, "black", "bastya", 1 },
                { 6, 6, "black", "huszar", 1 },
                { 4, 5, "black", "futo", 1 },
                { 5, 4, "black", "gyalog", 1 },
                { 6, 2, "black", "gyalog", 2 },
                { 6, 7, "black", "gyalog", 3 }
            };
           
            for (int i = 0; i < whiteGroup.GetLength(0); i++)
            {
                model_whiteFiguresON.Add(new Figure(
                    (int)whiteGroup[i,0],
                    (int)whiteGroup[i,1],
                    (string)whiteGroup[i,2],
                    (string)whiteGroup[i,3],
                    (int)whiteGroup[i,4]));
                model_blackFiguresON.Add(new Figure(
                    (int)blackGroup[i,0],
                    (int)blackGroup[i,1],
                    (string)blackGroup[i,2],
                    (string)blackGroup[i,3],
                    (int)blackGroup[i,4]));
            };
        }
    }
}