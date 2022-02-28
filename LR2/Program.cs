using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {

        var random = new Random();

        var linear = new List<double>();
        var binary = new List<double>();
        for (int i = 0; i < 500; i++)
        {
            var array = Enumerable.Range(1, 1000).ToArray();
            var toFind = array[random.Next(0, array.Length - 1)];
            linear.Add(Test(LinearFind, toFind, array));
            binary.Add(Test(BinarySearch, toFind, array));
        }
        Console.WriteLine("Отсортированная последовательность");
        Console.WriteLine($"Линейный\nMs Min:{linear.MinBy(x => x)} Max:{linear.MaxBy(x => x)} Avg:{linear.Sum(x => x) / (float)linear.Count}\nSwap Min:{linear.MinBy(x => x)} Max:{linear.MaxBy(x => x)} Avg:{linear.Sum(x => x) / (float)linear.Count}");
        Console.WriteLine($"Бинарный\nMs Min:{binary.MinBy(x => x)} Max:{binary.MaxBy(x => x)} Avg:{binary.Sum(x => x) / (float)binary.Count}\nSwap Min:{binary.MinBy(x => x)} Max:{binary.MaxBy(x => x)} Avg:{binary.Sum(x => x) / (float)binary.Count}");
        Console.WriteLine();
        for (int i = 0; i < 500; i++)
        {
            var array = Enumerable.Range(1, 1000).OrderBy(x=>random.Next()).ToArray();
            var toFind = array[random.Next(0, array.Length - 1)];
            linear.Add(Test(LinearFind, toFind, array));
        }
        Console.WriteLine("Случайная последовательность");
        Console.WriteLine($"Линейный\nMs Min:{linear.MinBy(x => x)} Max:{linear.MaxBy(x => x)} Avg:{linear.Sum(x => x) / (float)linear.Count}\nSwap Min:{linear.MinBy(x => x)} Max:{linear.MaxBy(x => x)} Avg:{linear.Sum(x => x) / (float)linear.Count}");



    }






    private static double Test(Func<int,int[],int> Find,int toFind, int[] copyArray)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var finded =Find(toFind,copyArray);
        stopwatch.Stop();
        if (finded != toFind)
        {
            throw new Exception("Не найдено");
        }
        return stopwatch.ElapsedMilliseconds;
    }


    static int LinearFind(int toFind,int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i]==toFind)
            {
                return array[i];
            }
        }
        return -1;
    }


    static int BinarySearch( int toFind, int[] array)
    {

        int minNum = 0;
        int maxNum = array.Length - 1;

        while (minNum <= maxNum)
        {
            int mid = (minNum + maxNum) / 2;
            if (toFind == array[mid])
            {
                return ++mid;
            }
            else if (toFind < array[mid])
            {
                maxNum = mid - 1;
            }
            else
            {
                minNum = mid + 1;
            }
        }
        return -1;
    }








}