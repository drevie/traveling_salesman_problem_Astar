using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Node : IHeapItem<Node>
    {
        public int NODEID;
        public double GCost;
        public double FCost;
        public double HCost;
        public City current;
        public HashSet<City> unvisited;
        public List<City> path;


        public Node(City current, HashSet<City> unvisited, List<City> path)
        {
            Random rnd = new Random();
            this.current = current;
            this.unvisited = unvisited;
            this.path = path;
            this.NODEID = rnd.Next(0, 100000);
        }


        public double getNearestDistFromUnvisited(City city)
        {
            Dictionary<City, double> map = city.dMap;
            foreach(KeyValuePair<City, double> entry in map)
            {
                if (unvisited.Contains(entry.Key))
                    return entry.Value;
            }

            return 0.0f;
        }

        public double getNearestDistFromUnvisited(City city, HashSet<City> seen)
        {
            Dictionary<City, double> map = city.dMap;
            foreach (KeyValuePair<City, double> entry in map) 
            {
                if (unvisited.Contains(entry.Key) && !seen.Contains(entry.Key))
                    return entry.Value;
            }
            return 0.0f;
        }

        int heapIndex;
        public int HeapIndex
        {
            get
            {
                return heapIndex;
            }
            set
            {
                heapIndex = value;
            }
        }

        public int CompareTo(Node node)
        {
            int compare = FCost.CompareTo(node.FCost);
            if (compare == 0)
            {
                compare = HCost.CompareTo(node.HCost);
                if (compare == 0)
                {
                    compare = GCost.CompareTo(node.GCost);
                }
            }
            return -compare;
        }




    }
}
