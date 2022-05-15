﻿class Program
{
    static void Main(string[] args)
    {
        int count = 0;
        while (true)
        {

            Console.Clear();
            Console.WriteLine(count++);
            var nums = Enumerable.Range(1, 5).Select(x => Random.Shared.Next(100, 105)).ToList();

            Console.WriteLine(String.Join(' ', nums));



            var alg1Rez = Alg1(nums);
            var alg2Rez = Alg2(nums);
            Console.WriteLine(alg1Rez);
            Console.WriteLine();
            Console.WriteLine(alg2Rez);
            if (alg1Rez!=alg2Rez)
            {
            Console.ReadKey();

            }
            Thread.Sleep(2);
        }




    }
    //ВСЕГДА O(N^N-1)
    private static int Alg2(List<int> nums)
    {
        Console.WriteLine("Alg2");
        int rez = 0;
        for (int i = 0; i < nums.Count; i++)
        {
            int x = 1;   
            for (int l = 0; l < nums.Count; l++)
            {
                if (i!=l&&nums[i].ToString()[^2..^0] == nums[l].ToString()[^2..^0])
                {
                    x++;
                }
            }
            if (x == 1) rez++;
        }
        return rez; 


    }
    //O(N+X)
    //Лучший O(N+1)
    //Средний O(N+N/2)
    //Худший O(N+N)
    private static int Alg1(List<int> nums)
    {
        Console.WriteLine("Alg1");
        var groped = nums.GroupBy(x => x.ToString()[^2..^0]);
        foreach (var item in groped)
        {
            Console.WriteLine($"{item.Key}:{item.Count()}");
        }

        var rez = groped.Where(x => x.Count() <= 1).Count();
        return rez;
    }
}