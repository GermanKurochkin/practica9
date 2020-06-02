using System;
using System.Collections.Generic;
using System.Collections;

namespace practica9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] {1,2,3,4,5,6 };
            ListOne<int> l = new ListOne<int>(mas);
            ListOne<int> l2= new ListOne<int>();
            Console.WriteLine("Начальная:");
            l.ShowList();
            l2.Reverse(l);
            Console.WriteLine();
            Console.WriteLine("Новая:");
            l2.ShowList();
            l2 = new ListOne<int>();
            Console.WriteLine("Новая:");
            l2.ShowList();
          
            l2.ReverseRecursion(l);
            Console.WriteLine();
            Console.WriteLine("Новая(рекурсией):");
            l2.ShowList();

        }
    }
    public class Point<T>
    {
        public T Data { get; set; }
        public Point<T> Next { get; set; }

        public Point()
        {
            Next = null;
            Data = default(T);
        }

        public Point(T data)
        {
            Data = data;
            Next = null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
    public class ListOne<T> 
    {
        public Point<T> Beg { get; set; }

        public ListOne()
        {
            Beg = null;
        }

        public ListOne(params T[] mas)
        {
            Beg = new Point<T>();
            Beg.Data = mas[0];
            Point<T> p = Beg;
            for (int i = 1; i < mas.Length; i++)
            {
                Point<T> temp = new Point<T>();
                temp.Data = mas[i];
                p.Next = temp;
                p = temp;
            }
        }

        public void Reverse(ListOne<T> list)
        {
            if (list.Beg == null)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }
            else
            {
                if (list.Beg.Next == null)
                {
                    Console.WriteLine("Коллекция состоит из 1 элемента");
                    Beg = new Point<T>(list.Beg.Data);
                    return;
                }
                else
                {
                    Point<T> p = list.Beg;
                    Point<T> p2 = p.Next;
                    Point<T> p3;
                    Point<T> pNew= new Point<T>(p.Data);
                    Point<T> pNew2 = new Point<T>(p2.Data);

                    while (p2.Next != null)
                    {
                        pNew2.Next = pNew;

                        p3 = p2.Next;
                        pNew = pNew2;
                        pNew2 = new Point<T>(p3.Data);

                        p2 = p3;
                    }
                    pNew2.Next = pNew;
                    Beg = pNew2;
                }
            }
        }
        public void ReverseRecursion(ListOne<T> list)
        {
            if (list.Beg == null)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }
            else
            {
                if (list.Beg.Next == null)
                {
                    Console.WriteLine("Коллекция состоит из 1 элемента");
                    Beg = new Point<T>(list.Beg.Data);
                    return;
                }
                else
                {
                    Point<T> p = list.Beg;
                    Point<T> p2 = p.Next;
                    Point<T> pNew = new Point<T>(p.Data);
                    Point<T> pNew2 = new Point<T>(p2.Data);
                    pNew2.Next = ReverseNext(pNew,p2,pNew2);

                }
            }
        }
        public Point<T> ReverseNext(Point<T> pNew, Point<T> p2, Point<T> pNew2)
        {
            if (p2.Next==null)
            {
                Beg = pNew2;
                return pNew;
            }
            else
            {
                Point<T> p3 = p2.Next;
                Point<T> pNew3 = new Point<T>(p3.Data);
                pNew3.Next=ReverseNext(pNew2, p3, pNew3);

                return pNew;
            }
        
        }

        public void ShowList()
        {
            if (Beg == null)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }
            else
            {
                Point<T> p = Beg;
                while (p != null)
                {
                    Console.WriteLine(p);
                    p = p.Next;
                }
                Console.WriteLine();
            }
        }

    }
}
