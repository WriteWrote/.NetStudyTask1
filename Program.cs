using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
  class Program
  {
    private static String ReadFile(String path)
    {
      String file = "";
      if (path != null)
        if (path.Equals("0") || path.Equals(""))
        {
          Console.WriteLine("The default filepath will be used.");
          file = File.ReadAllText("D:\\XXX\\WorkingFiles\\C#_2021\\Task1\\Task1\\array0.txt");
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
            else
            {
              Console.WriteLine("Don't do such thing again. For your boldness you ought to rerun the program");
            }
          }
          catch (Exception e)
          {
            Console.WriteLine(e);
            throw;
          }
        }

      return file;
    }

    private static int[][] ReadArray(String file)
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

      return array;
    }

    private static List<int> TraversalA(int[][] array)
    {
      List<int> seq = new List<int>();
      int diff;

      for (int j = 0; j < array[0].Length - 1; j++)
      {
        if ((j & 1) == 0)
        {
          for (int i = array.Length - 1; i > 0; i--)
          {
            diff = array[i - 1][j] - array[i][j];
            seq.Add(diff);
            Console.Write(array[i][j] + " ");
          }

          diff = array[0][j + 1] - array[0][j];
          seq.Add(diff);
          Console.Write(array[0][j] + " ");
        }
        else
        {
          for (var i = 0; i < array.Length - 1; i++)
          {
            diff = array[i + 1][j] - array[i][j];
            seq.Add(diff);
            Console.Write(array[i][j] + " ");
          }

          diff = array[^1][j + 1] - array[^1][j];
          seq.Add(diff);
          Console.Write(array[^1][j] + " ");
        }
      }

      for (int i = 0; i < array.Length - 1; i++)
      {
        diff = array[i + 1][array[0].Length - 1] - array[i][array[0].Length - 1];
        seq.Add(diff);
        Console.Write(array[i][array[0].Length - 1] + " ");
      }

      Console.Write(array[^1][array[0].Length - 1] + " ");
      return seq;
    }

    private static List<int> TraversalC(int[][] array, int index)
    {
      List<int> seq = new List<int>();

      int n = array.GetLength(0);
      int count = n;
      int value = -n;
      int sum = -1;

      do
      {
        value = -1 * value / n;
        for (int i = 0; i < count; i++)
        {
          sum += value;
          Console.Write(array[sum / n][sum % n] + " ");
        }

        value *= n;
        count--;
        for (int i = 0; i < count; i++)
        {
          sum += value;
          Console.Write(array[sum / n][sum % n] + " ");
        }
      } while (count > 0);

      return seq;
    }

    private static int[][] ConvertArray(List<int>[] ex)
    {
      int[][] result = new int[ex.Length][];
      for (int i = 0; i < ex.Length; i++)
      {
        result[i] = ex[i].ToArray();
      }

      return result;
    }

    private static int[][] MoveArray(int[][] array)
    {
      List<int>[] choppedArray = new List<int>[array.Length - 1];

      for (int i = 1; i < array.Length; i++)
      {
        choppedArray[i - 1] = new List<int>();
        for (int j = array[0].Length - 1; j >= 0; j--)
        {
          choppedArray[i - 1].Add(array[i][j]);
        }
      }

      int[][] convertedArray = ConvertArray(choppedArray);
      int[][] result = new int[convertedArray[0].Length][];
      for (int j = 0; j < convertedArray[0].Length; j++)
      {
        result[j] = new int[convertedArray.Length];
        for (int i = 0; i < convertedArray.Length; i++)
        {
          result[j][i] = convertedArray[i][j];
        }
      }

      return result;
    }

    private static List<int> TraversalB(int[][] array, List<int> list)
    {
      List<int> line = new List<int>();

      for (int j = 0; j < array[0].Length - 1; j++)
      {
        line.Add(array[0][j + 1] - array[0][j]);
        Console.Write(array[0][j] + " ");
      }

      Console.Write(array[0][array[0].Length - 1] + " ");
      if (array.Length > 1)
        line.Add(array[1][array[0].Length - 1] - array[0][array[0].Length - 1]);

      list.AddRange(line);
      if (array.Length > 1)
      {
        TraversalB(MoveArray(array), list);
      }

      return list;
    }

    private static bool IsOrdered(int[][] array)
    {
      //List<int> travSeq = TraversalA(array);
      List<int> travSeq = TraversalB(array, new List<int>());
      bool isOrdered = false;
      int diff = travSeq[0];
      for (int i = 0; i < travSeq.Count; i++)
      {
        if (travSeq[i] * diff >= 0)
          isOrdered = true;
        else
        {
          return false;
        }
      }

      return isOrdered;
    }

    private static bool SearchSequence(int[][] array)
    {
      List<int> seq = new List<int>();
      int diff; // for simple sequences (like +diff) 

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

      foreach (var el in seq)
      {
        Console.WriteLine(el);
      }

      return false;
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Hello World! Enter a filepath. If you don't want to change filepath, type 0:");
      string path = Console.ReadLine();
      String file = ReadFile(path);

      try
      {
        int[][] array = ReadArray(file);
        //searchSequence(array);
        Console.WriteLine(IsOrdered(array));
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
