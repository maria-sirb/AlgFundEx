using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgFundEx4
{
    class Program
    {
        static void Main(string[] args)
        {
            P2();
            Console.ReadKey();
        }
        private static void P1()
        {
            using (StreamReader sr = new StreamReader(@"..\..\TextFile1.txt"))
            {
                int n1 = int.Parse(sr.ReadLine());
                string[] data1 = sr.ReadLine().Split(' ');
                int[] v1 = new int[n1];
                for(int i = 0; i < n1; i++)
                {
                    v1[i] = int.Parse(data1[i]);
                }

                int n2 = int.Parse(sr.ReadLine());
                string[] data2 = sr.ReadLine().Split(' ');
                int[] v2 = new int[n2];
                for (int i = 0; i < n2; i++)
                {
                    v2[i] = int.Parse(data2[i]);
                }
                List<int> even = new List<int>();
                int j = 0, k = 0;
                while(j < n1 && k < n2)
                {
                    if(v1[j] < v2[k])
                    {
                        if (v1[j] % 2 == 0)
                            even.Add(v1[j]);
                        j++;
                    }
                    else if (v2[k] < v1[j])
                    {
                        if (v2[k] % 2 == 0)
                            even.Add(v2[k]);
                        k++;
                    }
                    else if(v1[j] == v2[k])
                    {
                        if (v1[j] % 2 == 0)
                        {
                            even.Add(v1[j]);
                            even.Add(v2[k]);
                        }
                        j++;
                        k++;
                    }

                }
                while(j < n1)
                {
                    if (v1[j] % 2 == 0)
                        even.Add(v1[j]);
                    j++;
                }
                while (k < n2)
                {
                    if (v2[k] % 2 == 0)
                        even.Add(v2[k]);
                    k++;
                }

                for(int i = 0; i < even.Count; i++)
                {
                    Console.Write(even[i] + " ");
                }

            }

        }
        private static void P2()
        {
            using(StreamReader sr = new StreamReader(@"..\..\TextFile2.txt"))
            {
                string[] dim = sr.ReadLine().Split(' ');
                int n = int.Parse(dim[0]);
                int m = int.Parse(dim[1]);
                int[,] arr = new int[n, m];
                for(int i = 0; i < n; i++)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    for(int j = 0; j < m; j++)
                    {
                        arr[i, j] = int.Parse(line[j]);
                    }

                }
                bool[,] vis = new bool[n, m];
                int one = 0, two = 0, three = 0;
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < m; j++)
                    {
                        if(arr[i, j] != 0 && !vis[i, j])
                        {
                            int start = arr[i, j];
                            DFS(i, j, arr, vis, ref start);
                            switch(start)
                            {
                                case 1:
                                    one++;
                                    break;
                                case 2:
                                    two++;
                                    break;
                                case 3:
                                    three++;
                                    break;

                            }
                        }
                    }
                }
                Console.WriteLine(one + " " + two + " " + three);

            }
        }
        private static void DFS(int l, int c, int[,] arr, bool[,] vis, ref int start)
        {
            if(l < 0 || c < 0 || l >= arr.GetLength(0) || c >= arr.GetLength(1) || vis[l, c] || arr[l, c] != start)
            {
                return;
            }
            vis[l, c] = true;
           
            DFS(l - 1, c, arr, vis, ref start);
            DFS(l, c + 1, arr, vis, ref start);
            DFS(l + 1, c, arr, vis, ref start);
            DFS(l, c - 1, arr, vis, ref start);


        }
    }
}
