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
                    string aaa = Grid[ix, iy] ? "0" : " ";
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

        public static bool[,] DoGoL(int[,] grid,bool[,] boolgrid)
        {
            int x = grid.GetUpperBound(0);
            int y = grid.GetUpperBound(1);            

            for (int iy = 0; iy < y; iy++)
            {
                for (int ix = 0; ix < x; ix++)
                {
                    boolgrid[ix,iy] = GoLlogic(grid, boolgrid[ix,iy], ix, iy);

                }
            }
            return boolgrid;
        }

        public static bool GoLlogic(int[,] grid, bool alive,int x,int y)
        {
                        
            if (alive)
            {
                if (grid[x, y] == 2 || grid[x, y] == 3)
                {
                    return true;
                }
                return false;
            }
            if (!alive)
            {
                if (grid[x, y] == 3)
                {
                    return true;
                }
                return false;
            }
            return false;

        }
        public static int[,] MakeNumGrid(bool[,] grid)
        {
            int x = grid.GetUpperBound(0);
            int y = grid.GetUpperBound(1);
            int[,] intgrid = new int[x, y];
            for (int iy = 0; iy < y; iy++)
            {
                for (int ix = 0; ix < x; ix++)
                {
                    if (grid[ix, iy]) 
                    {
                        IncrementNear(intgrid, ix, iy);
                        intgrid[ix, iy]--;
                    }
                }
            }
            return intgrid;
        }

        public static void IncrementNear(int[,] grid,int x,int y)
        {

            for (int iy = 0; iy < 3; iy++)
            {
                for (int ix = 0; ix < 3; ix++)
                {
                    try { grid[x + ix - 1, y + iy - 1]++; } catch { }
                    
                }
            }            
        }

        public static int GetMid(int radius)
        {
            int mid = radius / 2;

            if (radius % 2 == 0) { return mid; } else { int mid2 = (mid * 10 + 5) / 10; return mid2; }
        }

        
    }
}
