using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator
{
    interface IOperation
    {
        double Call(params double[] args);
    }

    public delegate double delegateFunction(params double[] args);


    public class Operation : IOperation
    {
        delegateFunction delFunction;
        static Dictionary<String, IOperation> SupportedFunctions;
        
        public Operation(delegateFunction function)
        {
            delFunction = function;
        }

        public double Call(params double[] args)
        {
            return delFunction(args);
        }

        private static double Add(params double[] args)
        {
            return args.Sum();
        }

        private static double Subtract(params double[] args)
        {
            double result = 2 * args[0];
            foreach (double n in args)
            {
                result -= n;
            }
            return result;
        }

        private static double Multiple(params double[] args)
        {
            double result = 1;
            foreach (double n in args)
            {
                result *= n;
            }
            return result;
        }

        private static double Divide(params double[] args)
        {
            return args[0] / args[1];
        }

        private static double Acos(params double[] args)
        {
            return Math.Acos(args[0]);
        }

        private static double Asin(params double[] args)
        {
            return Math.Asin(args[0]);
        }

        private static double Atan(params double[] args)
        {
            return Math.Atan(args[0]);
        }

        private static double Atan2(params double[] args)
        {
            return Math.Atan2(args[0], args[1]);
        }

        private static double Cos(params double[] args)
        {
            return Math.Cos(args[0]);
        }

        private static double Cosh(params double[] args)
        {
            return Math.Cosh(args[0]);
        }

        private static double Exp(params double[] args)
        {
            return Math.Exp(args[0]);
        }

        private static double Log(params double[] args)
        {
            if (args.Length == 1)
                return Math.Log(args[0]);
            else
                return Math.Log(args[0], args[1]);
        }

        private static double Log10(params double[] args)
        {
            return Math.Log10(args[0]);
        }

        private static double Pow(params double[] args)
        {
            return Math.Pow(args[0], args[1]);
        }

        private static double Sin(params double[] args)
        {
            return Math.Sin(args[0]);
        }

        private static double Sinh(params double[] args)
        {
            return Math.Sinh(args[0]);
        }

        private static double Sqrt(params double[] args)
        {
            return Math.Sqrt(args[0]);
        }

        private static double Tan(params double[] args)
        {
            return Math.Tan(args[0]);
        }

        private static double Tanh(params double[] args)
        {
            return Math.Tanh(args[0]);
        }

        public static void DictionarySet()
        {
            SupportedFunctions = new Dictionary<string, IOperation>();
            SupportedFunctions.Add("+", new Operation(Add));
            SupportedFunctions.Add("-", new Operation(Subtract));
            SupportedFunctions.Add("*", new Operation(Multiple));
            SupportedFunctions.Add("/", new Operation(Divide));
            SupportedFunctions.Add("acos", new Operation(Acos));
            SupportedFunctions.Add("asin", new Operation(Asin));
            SupportedFunctions.Add("atan", new Operation(Atan));
            SupportedFunctions.Add("atan2", new Operation(Atan2));
            SupportedFunctions.Add("cos", new Operation(Cos));
            SupportedFunctions.Add("cosh", new Operation(Cosh));
            SupportedFunctions.Add("exp", new Operation(Exp));
            SupportedFunctions.Add("log", new Operation(Log));
            SupportedFunctions.Add("log10", new Operation(Log10));
            SupportedFunctions.Add("pow", new Operation(Pow));
            SupportedFunctions.Add("sin", new Operation(Sin));
            SupportedFunctions.Add("sinh", new Operation(Sinh));
            SupportedFunctions.Add("sqrt", new Operation(Sqrt));
            SupportedFunctions.Add("tan", new Operation(Tan));
            SupportedFunctions.Add("tanh", new Operation(Tanh));
        }

        static void Help()
        {
            Console.WriteLine(@"Supported Features: * / + - Acos Asin Atan Atan2
                    Cos Cosh Exp Log Log10 Pow 
                    Sin Sinh Sqrt Tan Tanh.
                    Type help or info for this information.
                    Type end or quit for exit.");
        }

        static void Run()
        {

            string opString, cmd;
            bool isRight = false;
            do
            {
                Console.Write("Op: ");
                cmd = opString = Console.ReadLine().Trim(' ').ToLower();
                if (cmd == "end" || cmd == "quit")
                {
                    Environment.Exit(0);
                }
                else if (cmd == "help" || cmd == "info")
                {
                    Help();
                }
                else
                {
                    foreach (string s in SupportedFunctions.Keys)
                    {
                        if (s == opString)
                        {
                            isRight = true;
                            break;
                        }
                    }
                    if (!isRight)
                    {
                        Console.WriteLine("Wrong operation!");
                    }
                }
            } while (!isRight);

            List<double> argsList = new List<double>();
            isRight = false;
            do
            {
                Console.Write("Args: ");
                string[] argsString = Console.ReadLine().Split(' ');
                cmd = argsString[0];
                if (cmd == "end" || cmd == "quit")
                    Environment.Exit(0);
                foreach (string s in argsString)
                {
                    double result;
                    if (Double.TryParse(s, out result))
                    {
                        argsList.Add(result);
                        isRight = true;
                    }
                    else if (s != "")
                    {
                        isRight = false;
                        break;
                    }
                }
                if (!isRight)
                {
                    Console.WriteLine("Wrong arguments!");
                    argsList.Clear();
                }
                if (isRight && argsList.Count == 1)
                {
                    if (opString == "/" || opString == "atan2" || opString == "pow"
                        || opString == "*" || opString == "+" || opString == "-")
                    {
                        isRight = false;
                        Console.WriteLine("Not enough arguments!");
                        argsList.Clear();
                    }
                }
                if (isRight && opString == "/" && argsList[1] == 0)
                {
                    Console.WriteLine("Can not divide by zero!");
                    isRight = false;
                    argsList.Clear();
                }

            } while (!isRight);

            double[] argsFunc = argsList.ToArray();
            double res = SupportedFunctions[opString].Call(argsFunc);
            Console.WriteLine($"Result: {res}\n");
        }

        static void Main(string[] args)
        {
            Help();
            DictionarySet();
            while (true)
            {
                Run();
            }
        }
    }
}
