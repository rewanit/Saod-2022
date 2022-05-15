class Program
{
    static void Main(string[] args)
    {
        AVL tree = new AVL();
        while (true)
        {
            tree.DisplayTree();
            var num = Convert.ToInt32(Console.ReadLine());
            if (tree.Find(num))
                tree.Delete(num);
            else
                tree.Add(num);
        }
    }
}
