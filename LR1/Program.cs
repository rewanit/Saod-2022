


using System.Diagnostics;
using System.Security.Cryptography;

class Program
{
   static int count = 0;
    static void Main(string[] args)
    {
        var random = new Random();

        var qSortList = new List<(double, int)>();
        var shakerList = new List<(double, int)>();
        
        for (int i = 0; i < 500; i++)
        {


            var array = Enumerable.Range(1, 1000).OrderBy(x => random.Next()).ToArray();

            qSortList.Add(Test(QSort, array.ToArray()));
            shakerList.Add(Test(ShakerSort, array.ToArray()));

        }
        Console.WriteLine("Случайная последовательность ");
        Console.WriteLine($"QuickSort \nMs Min:{qSortList.MinBy(x => x.Item1).Item1} Max:{qSortList.MaxBy(x => x.Item1).Item1} Avg:{qSortList.Sum(x => x.Item1) / (float)qSortList.Count}\nSwap Min:{qSortList.MinBy(x => x.Item2).Item2} Max:{qSortList.MaxBy(x => x.Item2).Item2} Avg:{qSortList.Sum(x => x.Item2) / (float)qSortList.Count}");
        Console.WriteLine($"ShakerSort\nMs Min:{shakerList.MinBy(x => x.Item1).Item1} Max:{shakerList.MaxBy(x => x.Item1).Item1} Avg:{shakerList.Sum(x => x.Item1) / (float)shakerList.Count}\nSwap Min:{shakerList.MinBy(x => x.Item2).Item2} Max:{shakerList.MaxBy(x => x.Item2).Item2} Avg:{shakerList.Sum(x => x.Item2) / (float)shakerList.Count}");
        Console.WriteLine();
        qSortList = new();
        shakerList = new();
        for (int i = 0; i < 500; i++)
        {


            var array = Enumerable.Range(1, 1000);

            var arrayHalf = array.TakeLast(500).OrderBy(x => random.Next()).ToList();
           var  array2half =array.Take(500).ToList();
            array2half.AddRange(arrayHalf);
            array = array2half.ToArray();
            qSortList.Add(Test(QSort, array.ToArray()));
            shakerList.Add(Test(ShakerSort, array.ToArray()));

        }
        Console.WriteLine("Полу случайная последовательность");

        Console.WriteLine($"QuickSort \nMs Min:{qSortList.MinBy(x => x.Item1).Item1} Max:{qSortList.MaxBy(x => x.Item1).Item1} Avg:{qSortList.Sum(x => x.Item1) / (float)qSortList.Count}\nSwap Min:{qSortList.MinBy(x => x.Item2).Item2} Max:{qSortList.MaxBy(x => x.Item2).Item2} Avg:{qSortList.Sum(x => x.Item2) / (float)qSortList.Count}");
        Console.WriteLine($"ShakerSort\nMs Min:{shakerList.MinBy(x => x.Item1).Item1} Max:{shakerList.MaxBy(x => x.Item1).Item1} Avg:{shakerList.Sum(x => x.Item1) / (float)shakerList.Count}\nSwap Min:{shakerList.MinBy(x => x.Item2).Item2} Max:{shakerList.MaxBy(x => x.Item2).Item2} Avg:{shakerList.Sum(x => x.Item2) / (float)shakerList.Count}");
        Console.WriteLine();
        qSortList = new();
        shakerList = new();
        for (int i = 0; i < 500; i++)
        {


            var array = Enumerable.Range(1, 1000).Reverse().ToArray();



            qSortList.Add(Test(QSort, array.ToArray()));
            shakerList.Add(Test(ShakerSort, array.ToArray()));

        }
        Console.WriteLine("Обратная последовательность");

        Console.WriteLine($"QuickSort \nMs Min:{qSortList.MinBy(x=>x.Item1).Item1} Max:{qSortList.MaxBy(x => x.Item1).Item1} Avg:{qSortList.Sum(x=>x.Item1)/ (float)qSortList.Count}\nSwap Min:{qSortList.MinBy(x => x.Item2).Item2} Max:{qSortList.MaxBy(x => x.Item2).Item2} Avg:{qSortList.Sum(x => x.Item2) / (float)qSortList.Count}");
        Console.WriteLine($"ShakerSort\nMs Min:{shakerList.MinBy(x => x.Item1).Item1} Max:{shakerList.MaxBy(x => x.Item1).Item1} Avg:{shakerList.Sum(x => x.Item1) / (float)shakerList.Count}\nSwap Min:{shakerList.MinBy(x => x.Item2).Item2} Max:{shakerList.MaxBy(x => x.Item2).Item2} Avg:{shakerList.Sum(x => x.Item2) / (float)shakerList.Count}");
        Console.WriteLine();

        qSortList = new();
        shakerList = new();
        for (int i = 0; i < 500; i++)
        {


            var array = Enumerable.Range(1, 1000);

            qSortList.Add(Test(QSort, array.ToArray()));
            shakerList.Add(Test(ShakerSort, array.ToArray()));

        }
        Console.WriteLine("Отсортированая последовательность");

        Console.WriteLine($"QuickSort \nMs Min:{qSortList.MinBy(x => x.Item1).Item1} Max:{qSortList.MaxBy(x => x.Item1).Item1} Avg:{qSortList.Sum(x => x.Item1) / (float)qSortList.Count}\nSwap Min:{qSortList.MinBy(x => x.Item2).Item2} Max:{qSortList.MaxBy(x => x.Item2).Item2} Avg:{qSortList.Sum(x => x.Item2) / (float)qSortList.Count}");
        Console.WriteLine($"ShakerSort\nMs Min:{shakerList.MinBy(x => x.Item1).Item1} Max:{shakerList.MaxBy(x => x.Item1).Item1} Avg:{shakerList.Sum(x => x.Item1) / (float)shakerList.Count}\nSwap Min:{shakerList.MinBy(x => x.Item2).Item2} Max:{shakerList.MaxBy(x => x.Item2).Item2} Avg:{shakerList.Sum(x => x.Item2) / (float)shakerList.Count}");
        Console.WriteLine();



    }

    private static (double,int) Test(Action<int[]> Sort, int[] copyArray)
    {
        count = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Sort(copyArray);
        stopwatch.Stop();
        if (!copyArray.OrderBy(x => x).SequenceEqual(copyArray))
        {
            throw new Exception("Не отсортировалось");
        }
        return (stopwatch.ElapsedMilliseconds,count);
    }


    //Перемешивание
    static void ShakerSort(int[] myint)
    {
        int left = 0,
            right = myint.Length - 1;

        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                
                if (myint[i] > myint[i + 1])
                    Swap(ref myint[i], ref myint[i + 1]);
            }
            right--;

            for (int i = right; i > left; i--)
            {
                
                if (myint[i - 1] > myint[i])
                    Swap(ref myint[i - 1], ref myint[i]);
            }
            left++;
        }
    }
    
    //Быстрая
    static  void QSort(int[] array)
    {
        QSort(ref array,0,array.Length-1);
    }

    private static void QSort(ref int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(ref arr, left, right);

            if (pivot > 1)
            {
                QSort(ref arr, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                QSort(ref arr, pivot + 1, right);
            }
        }

    }

    private static int Partition(ref int[] arr, int left, int right)
    {
        int pivot = arr[left];
        while (true)
        {

            while (arr[left] < pivot)
            {
                left++;
            }

            while (arr[right] > pivot)
            {
                right--;
            }

            if (left < right)
            {
                if (arr[left] == arr[right]) return right;

                Swap(ref arr[left], ref arr[right]);
            }
            else
            {
                return right;
            }
        }
    }

    static void Swap(ref int x, ref int y) 
        
        {
     
        count++;
        (x, y) = (y, x);
        }
    }




