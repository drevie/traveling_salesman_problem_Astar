using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    using System;
    using System.Diagnostics;



    public class tsp_prob
    {

        static string entry = "";
        static void Main()
        {
            entry += "Size NodesExpanded FCost RunTime(ms)";
            text_files();
            call_reads();
            Console.Write("End of Program");
            Console.ReadLine();
        }

        public tsp_prob()
        {
        }

        static void text_files()
        {
            int size;

            // For Size 10 
            size = 10;
            write_text_files(size);
            // For Size 25
            size = 25;
            write_text_files(size);
            // For Size = 50 
            size = 50;
            write_text_files(size);
            // For Size = 100 
            size = 100;
            write_text_files(size);
        }

        static void write_text_files(int size)
        {
            string filename_numb = size.ToString() + "-";
            string filename;
            int xCoordinate;
            int yCoordinate;
            bool[,] cities;
            Random rnd = new Random();

            for (int i = 0; i < 25; i++)
            {
                // Create new text file
                cities = new bool[100,100];
                filename = filename_numb + i;
                string entry = "";
                for (int j = 0; j < size; j++)
                {
                    redo:
                    // Create a new city 
                    xCoordinate = rnd.Next(0, 100);
                    yCoordinate = rnd.Next(0, 100);

                    if (!cities[xCoordinate, yCoordinate])
                    {
                        entry += j + ", " + xCoordinate + ", " + yCoordinate + "\n";

                        cities[xCoordinate, yCoordinate] = true;
                    }

                    else
                        goto redo;
                    // Write to new text file
                }
                System.IO.File.WriteAllText(@"C:\Users\Daniel\TSP_Text_Files\" + filename, entry);
            }
        }

        public static void call_reads()
        {
            int size;
            size = 10;
            read_files(size);
            size = 25;
            read_files(size);
            size = 50;
            read_files(size);
            size = 100;
            read_files(size);


        }

        static void read_files(int size)
        {
            System.IO.StreamReader file;
            // Iterate through 25 files for each size
            for (int i = 0; i < 25; i++)
            {
                file = new System.IO.StreamReader(@"C:\Users\Daniel\TSP_Text_Files\" + size + "-" + i);
                tsp_problem prob = new tsp_problem();
                prob.initializeProblem(file, size);
                A_Star a = new A_Star(prob, 1, size);

                Stopwatch sw = new Stopwatch();
                sw.Start();
                Node done = a.begin();
                entry += a.size + " "  + a.numNodes + " " + done.FCost + " " + sw.ElapsedMilliseconds + "ms\n";
                System.IO.File.WriteAllText(@"C:\Users\Daniel\TSP_Text_Files\Results", entry);
            }
        }
    }

}
