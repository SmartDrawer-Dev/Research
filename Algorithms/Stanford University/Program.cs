using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms {
    public class Program {
        static void Main(string[] args) {
            //Course1();
            Course2();
            //Course3();
            //Course4();
        }

        public static void Course1() {
            {   // Week 1
                var a = new DivideAndConquer.Karatsuba("3141592653589793238462643383279502884197169399375105820974944592");
                var b = new DivideAndConquer.Karatsuba("2718281828459045235360287471352662497757247093699959574966967627");
                var ab = String.Join("", (a * b));                
                // 8539734222673567065463550869546574495034888535765114961879601127067743044893204848617875072216249073013374895871952806582723184
            }
            {   // Week 2
                var data = Array.ConvertAll(File.ReadAllLines(@"..\..\IntegerArray.txt"), int.Parse);
                var inversions = DivideAndConquer.Inversion.Count(data);
                // 2407905288
            }
            {   // Week 3 
                var data = Array.ConvertAll(File.ReadAllLines(@"..\..\QuickSort.txt"), int.Parse);
                var d1 = (int[])data.Clone();
                var d2 = (int[])data.Clone();
                var d3 = (int[])data.Clone();
                var firstCMP  = DivideAndConquer.QuickSort.Sort(ref d1, DivideAndConquer.Option.FIRST);
                var finalCMP  = DivideAndConquer.QuickSort.Sort(ref d2, DivideAndConquer.Option.FINAL);
                var medianCMP = DivideAndConquer.QuickSort.Sort(ref d3, DivideAndConquer.Option.MEDIAN);
                // 162085
                // 164123
                // 138382
            }
            {   // Week 4
                var data = File.ReadAllLines(@"..\..\kargerMinCut.txt").Select(n => new List<int>(Array.ConvertAll(n.Split(new char[0], StringSplitOptions.RemoveEmptyEntries), int.Parse))).ToList();
                var result = DivideAndConquer.Krager.Compute(ref data);
                // 17
            }
        }

        public static void Course2() {
            { // Week 1 
              //    var scc = String.Join(",", new GraphSearch.Graph(@"..\..\SCC.txt").ComputeSCCs(5));
              //    434821,968,459,313,211
            }
            { // Week 2
              //    var ans = String.Join(",", new GraphSearch.Dijkstra(@"..\..\dijkstraData.txt").Compute(1, 7, 37, 59, 82, 99, 115, 133, 165, 188, 197));
              //    2599,2610,2947,2052,2367,2399,2029,2442,2505,3068
            }
            { // Week 3

            }
            { // Week 4

            }
        }

        public static void Course3() {
            { // Week 1

            }
            { // Week 2

            }
            { // Week 3

            }
            { // Week 4

            }
        }

        public static void Course4() {
            { // Week 1

            }
            { // Week 2

            }
            { // Week 3

            }
            { // Week 4

            }
        }
    }
}