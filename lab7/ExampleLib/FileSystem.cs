using System;
using System.Collections.Generic;

namespace ExampleLib
{
    public abstract class Component // Component: определяет интерфейс для всех компонентов в древовидной структуре
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }
    }

    public class Directory : Component // Composite: представляет компонент, который может содержать другие компоненты и реализует механизм для их добавления и удаления
    {
        private List<Component> components = new List<Component>();

        public Directory(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine("Node " + name);
            Console.WriteLine("Subnode:");
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print();
            }
        }
    }

    public class File : Component // Leaf: представляет отдельный компонент, который не может содержать другие компоненты
    {
        public File(string name)
                : base(name)
        { }
    }

}
