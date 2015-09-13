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
              ulong bits = rand.RandomUlong();
              input.WriteLine(bits);
              if (DEBUG) debug.WriteLine(bits.ToDebug());
              var bitsAsBools = bits.ToBools();
              int sieves = rand.Next(10);
              if (number == 12)
                sieves = 0;
              input.WriteLine(sieves);
              for (int ii = 0; ii < sieves; ++ii)
              {
                  ulong sieve = rand.RandomUlong();
                  var sieveAsBools = sieve.ToBools();
                  if (DEBUG) 
                  {
                    debug.WriteLine(sieve.ToDebug());
                    debug.WriteLine();
                  }
                  input.WriteLine(sieve);
                  bitsAsBools = bitsAsBools.Zip(sieveAsBools,
                      (b1, b2) => (b1 && !b2));
                  if (DEBUG) debug.WriteLine(bitsAsBools.ToDebug());
              }
              int answer = bitsAsBools.Count(b => b);
              if (answer == 0 && rand.Next(100) < 80)
                continue;
              if (number == 11 && answer < 3)
                continue;
              output.WriteLine(answer);
              break;
          }
        }
    }
}




















