// See https://aka.ms/new-console-template for more information







static class Program
{
   

    

    public static List<string> MySort(this List<string> input)
    {


        var newList = new List<string>();
        newList.Add(input.First());
        input.RemoveAt(0);


        foreach (var item in input)
        {
            bool t = false;
            for (int i = 0; i <newList.Count; i++)
            {

                string v = newList[i];
                
                if (string.CompareOrdinal(v, item)<0)
                {
                    newList.Insert(i, item);
                    t = true;
                    break;
                }


            }
            if (!t)
            {
                newList.Add(item);
            }
        }

        return newList.Reverse<string>().ToList();
    }


    static void Main(string[] args)
    {
        var random = new Random();
        var list = File.ReadAllLines("TextFile1.txt").ToList();

        list = list.OrderBy(x => random.Next()).ToList().GetRange(0, 5);



        Console.WriteLine("----------------");
        foreach (var item in list.OrderBy(x=>x))
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("----------------");
        foreach (var item in list.MySort())
        {
            Console.WriteLine(item);
        }
    }
}

