using System;
using System.Collections.Generic;

namespace ExampleLib
{
    public abstract class Component // Component: определяет интерфейс для всех компонентов в древовидной структуре
    {
        public Component() { }

        public abstract void Operation();

        public abstract void Add(Component c);

        public abstract void Remove(Component c);

        public abstract bool IsComposite();
    }

    public class Composite : Component
    {
        List<Component> _children = new List<Component>();

        public Composite()
        {
        }

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }

        public override bool IsComposite()
        {
            return true;
        }

        public override void Operation()
        {
            int i = 0;

            Console.Write("Branch(");
            foreach (Component component in _children)
            {
                component.Operation();
                if (i != _children.Count - 1)
                {
                    Console.Write("+");
                }
                i++;
            }
            Console.Write(")");
        }
    }

    public class Leaf : Component
    {
        public Leaf()
        {
        }

        public override void Operation()
        {
            Console.Write("LEAF");
        }

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public override bool IsComposite()
        {
            return false;
        }
    }

}
