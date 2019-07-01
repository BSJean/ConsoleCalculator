using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Supported Features: * / + - Acos Asin Atan Atan2
                    Cos Cosh Exp Log Log10 Pow 
                    Sin Sinh Sqrt Tan Tanh");
            Console.ReadLine();
        }

        public delegate double delegateFunction(params double[] args);

        interface IOperation
        {
            double Call(params double[] args);
        }

        public class Operation : IOperation
        {
            delegateFunction delFunction;
            private Dictionary<String, IOperation> SupportedFunctions = new Dictionary<string, IOperation>();
            
            public Operation()
            {
                SupportedFunctions.Add("+", new Operation(Add));
                SupportedFunctions.Add("-", new Operation(Subtract));
                SupportedFunctions.Add("*", new Operation(Multiple));
                SupportedFunctions.Add("/", new Operation(Divide));
                SupportedFunctions.Add("Acos", new Operation(Acos));
                SupportedFunctions.Add("Asin", new Operation(Asin));
                SupportedFunctions.Add("Atan", new Operation(Atan));
                SupportedFunctions.Add("Atan2", new Operation(Atan2));
                SupportedFunctions.Add("Cos", new Operation(Cos));
                SupportedFunctions.Add("Cosh", new Operation(Cosh));
                SupportedFunctions.Add("Exp", new Operation(Exp));
                SupportedFunctions.Add("Log", new Operation(Log));
                SupportedFunctions.Add("Log10", new Operation(Log10));
                SupportedFunctions.Add("Pow", new Operation(Pow));
                SupportedFunctions.Add("Sin", new Operation(Sin));
                SupportedFunctions.Add("Sinh", new Operation(Sinh));
                SupportedFunctions.Add("Sqrt", new Operation(Sqrt));
                SupportedFunctions.Add("Tan", new Operation(Tan));
                SupportedFunctions.Add("Tanh", new Operation(Tanh));
            }

            public Operation(delegateFunction function)
            {
                delFunction = function;
            }

            public double Call(params double[] args)
            {
                return delFunction(args);
            }

            public double Add(params double[] args)
            {
                return args.Sum();
            }

            public double Subtract(params double[] args)
            {
                double result = 2 * args[0];
                foreach (double n in args)
                {
                    result -= n;
                }
                return result;
            }

            public double Multiple(params double[] args)
            {
                double result = 1;
                foreach (double n in args)
                {
                    result *= n;
                }
                return result;
            }

            public double Divide(params double[] args)
            {
                return args[0] / args[1];
            }

            public double Acos(params double[] args)
            {
                return Math.Acos(args[0]);
            }

            public double Asin(params double[] args)
            {
                return Math.Asin(args[0]);
            }

            public double Atan(params double[] args)
            {
                return Math.Atan(args[0]);
            }

            public double Atan2(params double[] args)
            {
                return Math.Atan2(args[0],args[1]);
            }

            public double Cos(params double[] args)
            {
                return Math.Cos(args[0]);
            }

            public double Cosh(params double[] args)
            {
                return Math.Cosh(args[0]);
            }

            public double Exp(params double[] args)
            {
                return Math.Exp(args[0]);
            }

            public double Log(params double[] args)
            {
                if (args.Length==1)
                    return Math.Log(args[0]);
                else
                    return Math.Log(args[0], args[1]);
            }

            public double Log10(params double[] args)
            {
                return Math.Log10(args[0]);
            }

            public double Pow(params double[] args)
            {
                return Math.Pow(args[0],args[1]);
            }

            public double Sin(params double[] args)
            {
                return Math.Sin(args[0]);
            }

            public double Sinh(params double[] args)
            {
                return Math.Sinh(args[0]);
            }

            public double Sqrt(params double[] args)
            {
                return Math.Sqrt(args[0]);
            }

            public double Tan(params double[] args)
            {
                return Math.Tan(args[0]);
            }

            public double Tanh(params double[] args)
            {
                return Math.Tanh(args[0]);
            }
        }

    }
}
