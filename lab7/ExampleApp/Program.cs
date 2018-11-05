using ExampleLib;
using System;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            Component leaf = new Leaf();

            Console.WriteLine("\n\nClient: I get a simple component:");
            client.ClientCode(leaf);

            Composite tree = new Composite();

            Composite branch1 = new Composite();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());

            Composite branch2 = new Composite();
            branch2.Add(new Leaf());

            tree.Add(branch1);
            tree.Add(branch2);

            Console.WriteLine("\n\nClient: Now I get a composite tree:");
            client.ClientCode(tree);

            Console.Write("\n\nClient: I can merge two components without checking their classes:\n");
            client.ClientCode2(tree, leaf);
        }

        class Client
        {
            public void ClientCode(Component leaf)
            {
                Console.Write("RESULT: ");
                leaf.Operation();
            }

            public void ClientCode2(Component component1, Component component2)
            {
                if (component1.IsComposite())
                {
                    component1.Add(component2);
                }

                Console.Write("RESULT: ");
                component1.Operation();

                Console.WriteLine();
            }
        }

    }
}
