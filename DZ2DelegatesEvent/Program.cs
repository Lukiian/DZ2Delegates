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
            AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();
            StringCollector stringCollector = new StringCollector();
            ConsoleEnterEvent consoleEnterEvent = new ConsoleEnterEvent();
            ConsoleEnterDelegate consoleEnterDelegate = new ConsoleEnterDelegate();
            ConsoleEnterAction consoleEnterAction = new ConsoleEnterAction();

            consoleEnterEvent.enterPressed += stringCollector.StringCollection;
            consoleEnterEvent.enterPressed += alphaNumbericCollector.NumberCollection;

            //consoleEnterEvent.Entered();

            //consoleEnterDelegate.Entered(stringCollector.StringCollection, alphaNumbericCollector.NumberCollection);

            //consoleEnterAction.Entered(stringCollector.StringCollection, alphaNumbericCollector.NumberCollection);
        }
    }

    class AlphaNumbericCollector
    {
        List<string> numberCollection = new List<string>();

        public void NumberCollection(string inputString)
        {
            if (inputString.Any(char.IsNumber))
            {
                numberCollection.Add(inputString);
            }
        }
    }

    class StringCollector
    {
        List<string> stringCollection = new List<string>();

        public void StringCollection(string inputString)
        {
            if (inputString.Any(char.IsNumber))
            { }
            else
                stringCollection.Add(inputString);
        }
    }

    class ConsoleEnterAction
    {
        string stringToIdentify;
        public void Entered(Action<string> actionString, Action<string> actionNumber)
        {
            while (stringToIdentify != "1")
            {
                stringToIdentify = Console.ReadLine();
                if (stringToIdentify != "1")
                {
                    actionString(stringToIdentify);
                    actionNumber(stringToIdentify);
                }
            }
        }
    }

    class ConsoleEnterDelegate
    {
        public delegate void EnterPressed(string inputString);
        string stringToIdentify;
        public void Entered(EnterPressed enterPressedString, EnterPressed enterPressedNumber)
        {
            while(stringToIdentify != "1")
            {
                stringToIdentify = Console.ReadLine();
                if (stringToIdentify != "1")
                {
                    enterPressedString.Invoke(stringToIdentify);
                    enterPressedNumber.Invoke(stringToIdentify);
                }
            }
        }
    }

    class ConsoleEnterEvent
    {
        public delegate void EnterPressed(string inputString);
        public event EnterPressed enterPressed;
        string stringToIdentify;
        public void Entered()
        {
            while (stringToIdentify != "1")
            {
                stringToIdentify = Console.ReadLine();
                if (stringToIdentify != "1")
                    enterPressed(stringToIdentify);
            }
        }
    }
}
