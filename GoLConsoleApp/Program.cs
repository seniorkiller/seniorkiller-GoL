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
            int time = 10;
            Console.WriteLine("The Acorn");
            string s=Console.ReadLine();

            if (s == "yes") 
            {
                Console.WriteLine("\n\nHow many Generation you want to play?");
                n = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("\nHow many Generation You want to play per secon");
                int time1 = Convert.ToInt32(Console.ReadLine());
                time = 1000 / time1;
            }

            
            int[] Grid ={
                0,1,0,0,0,0,0 ,
                0,0,0,1,0,0,0 ,
                1,1,0,0,1,1,1 };
            int[] GridDim = { 7, 3 };
            int rad = 30;
            bool[,] boolgrid = GridManager.MakeSBool(Grid, GridDim[0], GridDim[1], rad);
            int[,] intgrid=new int[rad,rad];
            

            string message = GridManager.MakeScreen(boolgrid, rad);
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            Stopwatch stopwatch = new Stopwatch();            
            for (int i = 0; i < n; i++)
            {
                
                stopwatch.Reset();
                stopwatch.Start();

                intgrid = GridManager.MakeNumGrid(boolgrid);
                boolgrid=GridManager.DoGoL(intgrid, boolgrid);

                message = GridManager.MakeScreen(boolgrid, rad);

                Console.Clear();
                Console.WriteLine(message);
                stopwatch.Stop();
                Thread.Sleep(time);
                

            }



        }
    }
}
