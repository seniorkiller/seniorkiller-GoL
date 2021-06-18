using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoLConsoleApp
{
    public class GridManager
    {
        public static bool[,] MakeSBool(int[] obj, int x, int y, int radius)
        {
            bool[,] arr = new bool[radius, radius];
            int i = 0;
            for (int iy = 0; iy < y; iy++)
            {

                for (int ix = 0; ix < x; ix++)
                {
                    arr[ix + GetMid(radius) - GetMid(x), iy + GetMid(radius) - GetMid(y)] = obj[i] == 1; i++;
                }

            }
            return arr;
        }

        public static string MakeScreen(bool[,] Grid, int radius)
        {
            string text = "";
            for (int i = 0; i < radius + 1; i++)
            {
                text +=  "--";
            } //this is the border
            text += "\n";
            for (int iy = 0; iy < radius; iy++)
            {
                text += "|";


                for (int ix = 0; ix < radius; ix++)
                {
                    string aaa = Grid[ix, iy] ? "X" : " ";
                    text = text + aaa + " ";
                }

                text += "|\n";


            }
            for (int i = 0; i < radius + 1; i++)
            {
                text += "--";//this just the border
            }//this is the border
            return text;
        }

        public static bool[,] DoGoL(bool[,] Boolgrid)
        {
            int x = Boolgrid.GetUpperBound(0);
            int y = Boolgrid.GetUpperBound(1);
            bool[,] newBoolgrid = new bool[x+1, y+1];

            for (int iy = 0; iy < y; iy++)
            {
                for (int ix = 0; ix < y; ix++)
                {
                    newBoolgrid[ix, iy] = GoLlogic(Boolgrid, ix, iy);
                }

            }

            return newBoolgrid;
        }

        public static bool GoLlogic(bool[,] grid , int ix, int iy)
        {            
            
            
            if (grid[ix, iy])
            {
                if (GetTrueNum(grid, ix, iy) == 2 || GetTrueNum(grid, ix, iy) == 3)
                {
                    return true;
                }
                return false;
            }
            if (!grid[ix, iy])
            {
                if (GetTrueNum(grid, ix, iy) != 3)
                {
                    return false;
                }
                return true;
            }
            return false;
            
               
                



            
        }

        public static int GetTrueNum(bool[,] grid,int x,int y)
        {
            int num = 0;
            int m = 0;
            for (int iy=0; iy < 3; iy++)
            {
                for (int ix=0; ix < 3; ix++)
                {
                    try { num += grid[x - 1 + ix, y - 1 + iy] ? 1 : 0; } catch { m++; }
                }
            }
            num -= grid[x, y] ? 1 : 0;
            return num;
        }

        public static int GetMid(int radius)
        {
            int mid = radius / 2;

            if (radius % 2 == 0) { return mid; } else { int mid2 = (mid * 10 + 5) / 10; return mid2; }
        }

        
    }
}
