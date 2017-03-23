using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class A_Star
    {
        tsp_problem problem;
        public int numNodes;
        public int size;

        public A_Star(tsp_problem prob, int numNodes, int size)
        {
            this.problem = prob;
            this.numNodes = numNodes;
            this.size = size;
            Console.WriteLine("THIS IS A STAR");
        }

        public Node begin()
        {
            Node current = problem.firstState;
            Heap<Node> frontier = new Heap<Node>(10000000);
            HashSet<Node> visited = new HashSet<Node>();
            frontier.Add(current);
            bool firstFlag = true;


            while (frontier.Count != 0)
            {
                current = frontier.RemoveFirst();
                visited.Add(current);
                // Console.Read();

                if (problem.goalTest(current) && !firstFlag)
                {
                    Console.WriteLine("FINAL FCOST = " + current.FCost + "Node Expansion = " + numNodes + "size of map = " + size);
                    frontier = null;
                    visited = null;
                    problem = null;
                    //Console.Read();
                    return current;
                }

                if (firstFlag)
                    firstFlag = false;

                double currGCost = current.GCost;
                
                foreach (Node neighbor in problem.formNeighbors(current))
                {

                    if (visited.Contains(neighbor))
                        continue;

                    double tempGCost = currGCost + problem.getDistance(current, neighbor);
                    if (tempGCost < neighbor.GCost || !frontier.Contains(neighbor))
                    {
                        numNodes++;
                        neighbor.GCost = tempGCost;
                        problem.calculateFCost(neighbor, tempGCost);

                        if (!(frontier.Contains(neighbor)))
                        {
                            frontier.Add(neighbor);
                        }
                        else
                        {
                            frontier.UpdateItem(neighbor);
                        }

                        current.unvisited = null;
                    }

                }
            }

            return null;
        }
    }
}