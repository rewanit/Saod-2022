


using System.Diagnostics;

class Program
{
   static int count = 0;
    static void Main(string[] args)
    {
        var random = new Random();

        var qSortList = new List<(double, int)>();
        var shakerList = new List<(double, int)>();
        
        for (int i = 0; i < 100; i++)
        {


            var array = Enumerable.Range(1, 1000).OrderBy(x => random.Next()).ToArray();

            qSortList.Add(Test(QSort, array.ToArray()));
            shakerList.Add(Test(ShakerSort, array.ToArray()));

        }

        Console.WriteLine($"qSort\nMs Min:{qSortList.MinBy(x=>x.Item1).Item1} Max:{qSortList.MaxBy(x => x.Item1).Item1} Avg:{qSortList.Sum(x=>x.Item1)/ (float)qSortList.Count}\nSwap Min:{qSortList.MinBy(x => x.Item2).Item2} Max:{qSortList.MaxBy(x => x.Item2).Item2} Avg:{qSortList.Sum(x => x.Item2) / (float)qSortList.Count}");
        Console.WriteLine($"ShakerSort\nMs Min:{shakerList.MinBy(x => x.Item1).Item1} Max:{shakerList.MaxBy(x => x.Item1).Item1} Avg:{shakerList.Sum(x => x.Item1) / (float)shakerList.Count}\nSwap Min:{shakerList.MinBy(x => x.Item2).Item2} Max:{shakerList.MaxBy(x => x.Item2).Item2} Avg:{shakerList.Sum(x => x.Item2) / (float)shakerList.Count}");





    }

    private static (double,int) Test(Action<int[]> Sort, int[] copyArray)
    {
        count = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Sort(copyArray);
        stopwatch.Stop();

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
        QSort(ref array,0,-1);
    }

    static void QSort(ref int[] array, int firstIndex, int lastIndex)
    {
        if (lastIndex < 0)
            lastIndex = array.Length - 1;
        if (firstIndex >= lastIndex)
            return;
        int middleIndex = (lastIndex - firstIndex) / 2 + firstIndex, currentIndex = firstIndex;
        Swap(ref array[firstIndex], ref array[middleIndex]);
        for (int i = firstIndex + 1; i <= lastIndex; ++i)
        {
            if (array[i] <= array[firstIndex])
            {
                Swap(ref array[++currentIndex], ref array[i]);
            }
        }
        Swap(ref array[firstIndex], ref array[currentIndex]);
        QSort(ref array, firstIndex, currentIndex - 1);
        QSort(ref array, currentIndex + 1, lastIndex);
    }

    static void Swap(ref int x, ref int y) 
        
        {
     
        count++;
        (x, y) = (y, x);
        }
    }




