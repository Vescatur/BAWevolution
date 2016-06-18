using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BAWsurvival
{
    class Cell
    {
        public int score;
        int x;
        int y;



        public void Initialize (int Tx,int Ty,int Tscore)
        {
            x = Tx;
            y = Ty;
            score = Tscore;
        }

        public Color GetColor(float Frame)
        {
            byte b = GetB(Frame);
            return Color.FromRgb(b, b, b); 
        }

        public byte GetB(float Frame)
        {
            return (byte)score;
        }

    }
}
