/// <summary>
/// 15.	Написать программу формирования сбалансированного RB-дерева из случайного множества n целочисленных ключей и определить его высоту.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        
            RB tree = new RB();
        while (true)
        {
            Console.Clear();
            Console.WriteLine(tree.GetH());
            tree.prettyPrint();
            var str = Console.ReadLine();
            if (str[0]=='d')
            {
            var num = Convert.ToInt32(str.Substring(1));

                tree.deleteNode(num);
            }
            else
            {
                var num = Convert.ToInt32(str);

                tree.insert(num);
            }
            
        }
        
    }
}