using System;
using System.Collections.Generic;
using System.Linq;

public interface IOperation
{
    double Call(params double[] args);
}

public delegate double delegateFunction(params double[] args);

public class Operation : IOperation
{
    delegateFunction delFunction;
    static Dictionary<String, IOperation> supportedFunctions;

    protected Operation(delegateFunction function)
    {
        delFunction = function;
    }

    public static bool Check(string s, params double[] args)
    {
        if ((s=="+" || s=="-" || s=="*" ||s=="/" || s=="pow" ||s=="atan2") && args.Length < 2)
        {
            Console.WriteLine("Need more arguments!");
            return false;
        }
        else
            return true;
            
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


    public static Dictionary<string, IOperation> SupportedFunctions
    {
        get
        {
            return supportedFunctions;
        }
    }

    public static void DictionarySet()
    {
        supportedFunctions = new Dictionary<string, IOperation>();
        supportedFunctions.Add("+", new Operation(Add));
        supportedFunctions.Add("-", new Operation(Subtract));
        supportedFunctions.Add("*", new Operation(Multiple));
        supportedFunctions.Add("/", new Operation(Divide));
        supportedFunctions.Add("acos", new Operation(Acos));
        supportedFunctions.Add("asin", new Operation(Asin));
        supportedFunctions.Add("atan", new Operation(Atan));
        supportedFunctions.Add("atan2", new Operation(Atan2));
        supportedFunctions.Add("cos", new Operation(Cos));
        supportedFunctions.Add("cosh", new Operation(Cosh));
        supportedFunctions.Add("exp", new Operation(Exp));
        supportedFunctions.Add("log", new Operation(Log));
        supportedFunctions.Add("log10", new Operation(Log10));
        supportedFunctions.Add("pow", new Operation(Pow));
        supportedFunctions.Add("sin", new Operation(Sin));
        supportedFunctions.Add("sinh", new Operation(Sinh));
        supportedFunctions.Add("sqrt", new Operation(Sqrt));
        supportedFunctions.Add("tan", new Operation(Tan));
        supportedFunctions.Add("tanh", new Operation(Tanh));
    }
       
    public static string Help
    {
        get
        {
            return @"Supported Features: * / + - Acos Asin Atan Atan2
                                Cos Cosh Exp Log Log10 Pow 
                                Sin Sinh Sqrt Tan Tanh.";
                                //Type help or info for this information.
                                //Type exit or quit for exit.
        }
    }

}

