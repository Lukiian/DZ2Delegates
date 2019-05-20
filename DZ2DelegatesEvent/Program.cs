using System;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Text;

namespace DZ2DelegatesEvent
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Action<string> action;

            AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();
            StringCollector stringCollector = new StringCollector();
            ConsoleEnterEvent consoleEnterEvent = new ConsoleEnterEvent();
            ConsoleEnterDelegate consoleEnterDelegate = new ConsoleEnterDelegate();
            ConsoleEnterAction consoleEnterAction = new ConsoleEnterAction();

            string exit = "0";

            consoleEnterEvent.enter += stringCollector.StringCollection;
            consoleEnterEvent.enter += alphaNumbericCollector.NumberCollection;


            while (exit != "1")
            {
                exit = Console.ReadLine();
                //Event

                //consoleEnterEvent.Entered(exit);


                //Delegate

                //consoleEnterDelegate.Entered(stringCollector.StringCollection, exit);
                //consoleEnterDelegate.Entered(alphaNumbericCollector.NumberCollection, exit);


                //Action

                //action = stringCollector.StringCollection;
                //consoleEnterAction.Entered(exit, action);
                //action = alphaNumbericCollector.NumberCollection;
                //consoleEnterAction.Entered(exit, action);
            }
        }
    }

    class AlphaNumbericCollector
    {
        List<string> numberCollection = new List<string>();

        public void NumberCollection(string n)
        {
            if (n.Any(char.IsNumber))
            {
                numberCollection.Add(n);
            }
        }
    }

    class StringCollector
    {
        List<string> stringCollection = new List<string>();

        public void StringCollection(string s)
        {
            if (s.Any(char.IsNumber))
            { }
            else
                stringCollection.Add(s);
        }
    }

    class ConsoleEnterAction
    {
        public void Entered(string s, Action<string> a)
        {
            a(s);
        }
    }

    class ConsoleEnterDelegate
    {
        public delegate void EnterPressed(string s);

        public void Entered(EnterPressed EP, string s)
        {
            EP.Invoke(s);
        }
    }

    class ConsoleEnterEvent
    {
        public delegate void EnterPressed(string s);
        public event EnterPressed enter;

        public void Entered(string s)
        {
            enter(s);
        }
    }
}
