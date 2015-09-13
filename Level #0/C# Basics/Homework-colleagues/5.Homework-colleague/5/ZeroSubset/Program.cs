//Warning: this is going to be painful to read.
using System;
class ZeroSubset
{
    static void Main(string[] args)
    {
        Console.SetBufferSize(1000, 10000);
        int[] givenSet = new int[5];
        for  (int i = 0; i<5 ; i++)
        {
            Console.Write("Enter next number of Set[int] :\t");
            givenSet[i] = int.Parse(Console.ReadLine());
        }
        for ( int  i=0 ; i < givenSet.Length ; i++)
        {
            for ( int j=0 ; j < givenSet.Length ; j++)
            {
                if (j != i)
                {
                    if (givenSet[i] + givenSet[j] == 0)
                    {
                        Console.WriteLine("{0} + {1} = 0", givenSet[i], givenSet[j]);
                    }
                }
                for ( int k = 0; k < givenSet.Length ; k++)
                {
                    if (k != j && k != i)
                    {
                        if (givenSet[i] + givenSet[j] + givenSet[k] == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} = 0", givenSet[i], givenSet[j], givenSet[k]);
                        }
                    }
                    for ( int l = 0 ; l < givenSet.Length ; l++)
                    {
                        if (l != k && l != j && l != i)
                        {
                            if (givenSet[i] + givenSet[j] + givenSet[k] + givenSet[l] == 0)
                            {
                                Console.WriteLine("{0} + {1} + {2} + {3} = 0", givenSet[i], givenSet[j], givenSet[k], givenSet[l]);
                            }
                        }

                        for (int m = 0; m < givenSet.Length; m++)
                        {
                            if (m != l && m != k && m != j && m != i)
                            {
                                if (givenSet[i] + givenSet[j] + givenSet[k] + givenSet[l] + givenSet[m] == 0)
                                {
                                    Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", givenSet[i], givenSet[j], givenSet[k], givenSet[l], givenSet[m]);
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.ReadKey();
        Console.Clear();
    }
}
