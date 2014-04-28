using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seaBattle.Common
{
    
    public class AutoGenerationFild
    {
        private bool[,] BattleField = new bool[10, 10];
        private bool CanFilledIn(bool isx,int min,int max, int pos)
        {
            int Error=0;
            if ((min>=0) && ( max <=9) && (max>=min) && (pos>=0) && (pos<=9))
            {
            int minYAvail, minXAvail, maxYAvail, maxXAvail;
            if (isx) 
            {
                if (min > 0) { minXAvail = min - 1; }
                else { minXAvail = min; };
                if (max < 9) { maxXAvail = max + 1; }
                else { maxXAvail = max; };
                if (pos > 0) { minYAvail = pos - 1; }
                else { minYAvail = pos;};
                if (pos < 9) { maxYAvail = pos + 1; }
                else { maxYAvail = pos; };
            }
            else
            {
                if (min > 0) { minYAvail = min - 1; }
                else { minYAvail = min; };
                if (max < 9) { maxYAvail = max + 1; }
                else { maxYAvail = max; };
                if (pos > 0) { minXAvail = pos - 1; }
                else { minXAvail = pos;};
                if (pos < 9) { maxXAvail = pos + 1; }
                else { maxXAvail = pos;};
            };


            for (int i = minXAvail;i<=maxXAvail;i++)
            {
                for (int j = minYAvail;j<=maxYAvail;j++)
                {
                       if (BattleField[i,j]) { Error = 1; }
                };
            };
            if (Error == 0) { return true; }
            else { return false; };
            }
            else {return false;};
        }
        public bool[,] GetFilledIn()
        {
            int x,y;
            int navi;
            int length = 4;
            bool filled = false;
            int currentcount=0;
            int count = 1;
            bool end = false ;
            Random rand = new Random();
            do
            {
            x = rand.Next(0,9);
            y = rand.Next(0,9);
            navi = rand.Next(1, 4);
            switch (navi)
            {
                case 1:
                    {
                        if (CanFilledIn(true,x - (length-1),x,y))
                        {
                            for (int i = x - (length - 1); i <= x; i++)
                                BattleField[i, y] = true;
                            filled = true;
                        }
                        break;
                    };
                case 2:
                    {
                        if (CanFilledIn(false,y - (length-1),y,x))
                        {
                            for (int i = y - (length - 1); i <= y; i++)
                                BattleField[x, i] = true;
                            filled = true;
                        }
                        break;
                    };
                case 3:
                    {
                        if (CanFilledIn(true, x, x + (length - 1), y))
                        {
                            for (int i = x + (length - 1); i >= x; i--)
                                BattleField[i, y] = true;
                            filled = true;
                        }
                        break;
                    }
                case 4:
                    {
                        if (CanFilledIn(false, y, y + (length - 1), x))
                        {
                            for (int i = y + (length - 1); i >= y; i--)
                                BattleField[x, i] = true;
                            filled = true;
                        }
                        break;
                    };
            };
            if (filled) { currentcount++; filled = false; };
            if (currentcount==count)
            {
                currentcount = 0;
                count++;
                length--;
            };
            if (count == 5) { end = true; }
            }while (!end);
            return BattleField;
            

        }
    }
}
