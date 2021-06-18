using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoLConsoleApp
{
    public class Program
    {

        static void Main(string[] args)
        {
            int n = 1000;
            int time = 100;
            int[] Grid ={
                0,1,0,0,0,0,0 ,
                0,0,0,1,0,0,0 ,
                1,1,0,0,1,1,1 };
            int[] GridDim = { 7, 3 };
            int rad = 30;
            bool[,] boolGrid = GridManager.MakeSBool(Grid, GridDim[0], GridDim[1], rad);

            

            string message = GridManager.MakeScreen(boolGrid, rad);
            Console.WriteLine(message);
            Stopwatch stopwatch = new Stopwatch();            
            for (int i = 0; i < n; i++)
            {
                stopwatch.Reset();
                bool[,] newBoolgrid = GridManager.DoGoL(boolGrid);               
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                Thread.Sleep(time - (int)stopwatch.ElapsedMilliseconds);
                Console.WriteLine(GridManager.MakeScreen(newBoolgrid, rad));
                boolGrid = newBoolgrid;

            }



        }
    }
}
