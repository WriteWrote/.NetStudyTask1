using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
  class Program
  {
    private static List<int> traversalA(int[][] array)
    {
      List<int> seq = new List<int>();
      int diff; // for simple sequens (like +diff)

      for (int j = 0; j < array[0].Length - 1; j++)
      {
        if ((j & 1) == 0)
        {
          for (int i = array.Length - 1; i > 0; i--)
          {
            diff = array[i - 1][j] - array[i][j];
            seq.Add(diff);
          }

          diff = array[0][j + 1] - array[0][j];
          seq.Add(diff);
        }
        else
        {
          for (int i = 0; i < array.Length - 1; i++)
          {
            diff = array[i + 1][j] - array[i][j];
            seq.Add(diff);
          }

          diff = array[array.Length - 1][j + 1] - array[array.Length - 1][j];
          seq.Add(diff);
        }
      }

      for (int i = 0; i < array.Length - 1; i++)
      {
        diff = array[i + 1][array[0].Length - 1] - array[i][array[0].Length - 1];
        seq.Add(diff);
      }

      return seq;
    }

    private static bool isOrdered(int[][] array)
    {
      List<int> travSeq = traversalA(array);
      bool isOrdered = false;
      for (int i = 0; i < travSeq.Count - 1; i++)
      {
        if (travSeq[i + 1] - travSeq[i] > 0)
          isOrdered = true;
        else
        {
          return false;
        }
      }
      return isOrdered;
    }

    private static bool searchSequence(int[][] array)
    {
      List<int> seq = new List<int>();
      int diff; // for simple sequens (like +diff) 

      for (int j = 0; j < array[0].Length - 1; j++)
      {
        if ((j & 1) == 0)
        {
          for (int i = array.Length - 1; i > 0; i--)
          {
            diff = array[i - 1][j] - array[i][j];
            seq.Add(diff);
          }

          diff = array[0][j + 1] - array[0][j];
          seq.Add(diff);
        }
        else
        {
          for (int i = 0; i < array.Length - 1; i++)
          {
            diff = array[i + 1][j] - array[i][j];
            seq.Add(diff);
          }

          diff = array[array.Length - 1][j + 1] - array[array.Length - 1][j];
          seq.Add(diff);
        }
      }

      for (int i = 0; i < array.Length - 1; i++)
      {
        diff = array[i + 1][array[0].Length - 1] - array[i][array[0].Length - 1];
        seq.Add(diff);
      }

      foreach (var VARIABLE in seq)
      {
        Console.WriteLine(VARIABLE);
      }

      return false;
    }

    static void Main(string[] args)
    {
      // разобраться!!!

      Console.WriteLine("Hello World! Enter a filepath. If you don't want to change filepath, type 0:");
      string path = Console.ReadLine();
      String file = "";

      if (path != null)
        if (path.Equals("0") || path.Equals(""))
        {
          Console.WriteLine("The default filepath will be used.");
          file = File.ReadAllText("D:\\XXX\\WorkingFiles\\C#_2021\\Task1\\Task1\\array1.txt");
        }
        else
        {
          String checkSymbl = path.Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries)[0];
          try
          {
            if (checkSymbl.Equals("D") || checkSymbl.Equals("C"))
            {
              Console.WriteLine("Succeed");
              file = File.ReadAllText(path);
            }
          }
          catch (Exception e)
          {
            Console.WriteLine(e);
            Console.WriteLine("Don't do such thing again. For your boldness you ought to rerun the program");
            throw;
          }
        }

      // taking array out of file.txt
      try
      {
        var lines = file.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
        int[][] array = new int[lines.Length][];

        for (int j = 0; j < lines.Length; j++)
        {
          var chars = lines[j].Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
          chars[chars.Length - 1] = chars[chars.Length - 1].TrimEnd(new char[] {'\n'});
          array[j] = new int[chars.Length];
          for (int i = 0; i < chars.Length; i++)
          {
            array[j][i] = Convert.ToInt32(chars[i]);
          }
        }

        //searchSequence(array);
        Console.WriteLine(isOrdered(array));
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        Console.WriteLine("Array is null either empty");
        throw;
      }

      Console.ReadKey();
    }
  }
}
