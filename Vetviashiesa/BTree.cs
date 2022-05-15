namespace Vetviashiesa
{
    internal class BTree
    {
        public class Node
        {
            readonly static int Max = 5;
            public Node(int data)
            {
                Add(data);
            }

            public int? Key { get; set; } = null;
            public List<Node> Childrens { get; set; } = new();


            public void Add(int value)
            {
                
                if (Key != null)
                {
                    if (Childrens.Any(x => x.Key < value))
                    {
                        Childrens.Where(x => x.Key < value).First().Add(value);

                    }
                    else if(Childrens.Count >= Max)
                    {
                        Childrens.Last().Add(value);
                    }
                    else
                    {
                        Childrens.Add(new Node(value));
                    }

                }
                else
                {
                    Key = value;
                }
            }



        }

        internal void Print()
        {
            Print(Root, "", false);
        }

        Node? Root { get; set; }

        public int? GetNearestLower(int? value)
        {
            List<(Node, int)?> list = new();

            foreach (var item in Root.Childrens)
            {

                list.Add(DeepFind(item,value));
            }

            var compeleted = list.Where(x => x != null);
            if (compeleted.Count()>0)
            {
                return compeleted.MinBy(x => x.Value.Item2).Value.Item1.Key;
            }
            else
            return null;

        }

        private (Node,int)? DeepFind(Node root, int? value,int depth=0)
        {
            (int?, int?)? lol;
            if (root.Key<value)
            {
                return (root, depth);
            }
            else
            {
                List<(Node, int)?> list = new ();
                foreach (var item in root.Childrens)
                {
                        list.Add(DeepFind(item, value, depth + 1));
                }
                var compeleted = list.Where(x => x != null);
                if (compeleted.Count() > 0)
                {
                    return compeleted.MinBy(x => x.Value.Item2);
                }
                else
                    return null;
            }
        }


        public void Print(Node root, String indent, bool last)
        {
            if (Root != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("----");
                    indent += "     ";
                }
                else
                {
                    Console.Write("----");
                    indent += "|    ";
                }

                Console.WriteLine(root.Key);


                if (root.Childrens.Count > 0)
                {
                    for (int i = 0; i < root.Childrens.Count() - 1; i++)
                    {


                        Print(root.Childrens[i], indent, false);

                    }
                    Print(root.Childrens.Last(), indent, true);

                }

            }
        }



        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new Node(value);
            }
            else
            {
                Root.Add(value);
            }

        }




    }
}
