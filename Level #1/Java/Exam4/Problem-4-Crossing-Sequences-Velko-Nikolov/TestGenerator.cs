using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class Program
{
    static bool DEBUG = false;
    
    static void Main(string[] args)
    {
        DEBUG = args.Length > 0 && args[0] == "--debug";
        Directory.CreateDirectory("tests");
        for (int ii = 0; ii < 13; ++ii)
        {
            GenerateTest(ii + 1);
        }
    }
    
    static ulong RandomUlong(this Random rand)
    {
        return (((ulong)rand.Next()) << 32) |
                ((ulong)rand.Next());
    }
    
    static IEnumerable<bool> ToBools(this ulong bits)
    {
        return 
            Convert
            .ToString((long)bits, 2)
            .PadLeft(64, '0')
            .Select(c => c == '1');
    }
    
    static string ToDebug(this ulong bits)
    {
        return ToDebug(bits.ToBools());
    }
    static string ToDebug(this IEnumerable<bool> bools)
    {
        return new string(bools.Select(b => b ? '1' : '0').ToArray());
    }
    
    static void GenerateTest(int number)
    {
        var rand = new Random(number);
        while (true)
        {
            try
            {
                checked
                {
                    string file = string.Format("{0:000}", number);
                    if (number > 10)
                    {
                        file = "000." + string.Format("{0:000}", number % 10);
                    }
                    using (var input = new StreamWriter(
                        string.Format(@"tests\test.{0}.in.txt", file)))
                    using (var output = new StreamWriter(
                        string.Format(@"tests\test.{0}.out.txt", file)))
                    using (var debug = DEBUG ? new StreamWriter(
                        string.Format(@"tests\test.{0}.debug.txt", file)) : null)
                    {
                        int t1 = rand.Next(100);
                        int t2 = rand.Next(100);
                        int t3 = rand.Next(1, 100);
                        if (number == 13)
                        {
                            t1 = 1;
                            t2 = 2;
                            t3 = 3;
                        }
                        int t4 = 0;
                        input.WriteLine(t1);
                        input.WriteLine(t2);
                        input.WriteLine(t3);
                        int howManyTrib = rand.Next(100);
                        var hs = new HashSet<int>();
                        hs.Add(t1);
                        hs.Add(t2);
                        hs.Add(t3);
                        if (DEBUG)
                        {
                            debug.Write("{0} {1} {2}", t1, t2, t3);
                        }
                        for (int ii = 0; ii < howManyTrib; ++ii)
                        {
                            t4 = t1 + t2 + t3;
                            hs.Add(t4);
                            t1 = t2;
                            t2 = t3;
                            t3 = t4;
                            if (DEBUG)
                            {
                                debug.Write(" {0}", t4);
                            }
                        }
                        // walk back the spiral
                        int howManySpiral = rand.Next(10, 100);
                        int start = t4;
                        int step = rand.Next(1, 100);
                        if (number == 13)
                        {
                            start = 37;
                            step = 2;
                            howManySpiral = 8;
                        }
                        int wallAfter = (howManySpiral + 1) / 2;
                        int wall = wallAfter;
                        bool oddCorner = (howManySpiral % 2) == 1;
                        int lastSeen = start;
                        if (DEBUG)
                        {
                            debug.WriteLine();
                            debug.WriteLine(howManySpiral);
                            debug.Write(start);
                        }
                        for (int ii = 0; ii < howManySpiral - 1; ++ii)
                        {
                            if (oddCorner)
                            {
                                wall -= 1;
                            }
                            oddCorner = !oddCorner;
                            start -= wall * step;
                            if (DEBUG)
                            {
                                debug.Write(" {0}", start);
                            }
                            if (hs.Contains(start))
                            {
                                if (DEBUG)
                                {
                                    debug.Write("*");
                                }
                                lastSeen = start;
                            }
                        }
                        input.WriteLine(start);
                        input.WriteLine(step);
                        output.WriteLine(lastSeen);
                        break;
                    }
                }
            }
            catch (OverflowException)
            {
                continue;
            }
        }
    }
}




















