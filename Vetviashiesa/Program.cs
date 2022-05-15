using System.Runtime.Intrinsics.X86;
namespace Vetviashiesa;

class Program
{
    static void Main(string[] args)
{
        BTree tree = new ();
        Enumerable.Range(1,20).Select(x=>Random.Shared.Next(1,100)).ToList().ForEach(x=>tree.Add(x));
        int? num = null;
        while (true)
        {
            Console.Clear();
            tree.Print();
            Console.WriteLine(tree.GetNearestLower(num));
            //tree.DisplayTree();
            num = Convert.ToInt32(Console.ReadLine());
            //if (tree.Find(num))
            //    tree.Delete(num);
            //else
                //tree.Add(num);
        }
    }
}