using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using McMaster.Extensions.CommandLineUtils;
class Program 
{
    static void Main(string[] args)
        => CommandLineApplication.Execute<Program>(args);

    [Option(ShortName = "i")]
    public string inputFile { get; set; }

    [Option(ShortName = "o")]
    public string outputFile { get; set; }
    

    static float entry(int steps, float shop)
    {
        
        if (shop == 0 || shop > steps)
            return 0;
        if (steps == shop)
            return 1;
        if (steps == shop + 2)
            return shop;
        else
            return solve(steps, shop);
    }

    static float solve(int steps, float shop)
    {
        if (steps == shop + 4)
        {
            float s = (shop + 3) * (shop / 2);
            return s;
        }
        else
        {
            float s = solve(steps - 1, shop + 1) + solve(steps - 1, shop - 1);
            return s;
        }
    }
    void OnExecute() 
    {
        string[] input = File.ReadAllText(inputFile).Split();
        try
        {
            int n = int.Parse(input[0]);

            int k = int.Parse(input[1]);

            float result = entry(k, n);
            Console.WriteLine(result);
            File.WriteAllText(outputFile, result.ToString());
        }
        catch (Exception e) 
        {
            File.WriteAllText(outputFile, "Your data was in wrong format");
        }
        
    }

}
