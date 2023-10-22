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

    int answer = 0;
    void entry(int shop, int steps)
    {
        if (steps == shop)
        {
            answer = 1;
        }
        else if (shop == steps - 1)
        {
            answer = 0;
        }
        else if ((steps - shop) % 2 != 0)
        {
            answer = 0;
        }
        else if (steps == shop + 4)
        {
            float n = shop, k = steps, a = 0;
            a += (n + 3) * (n / 2);
            answer = (int)a;
        }
        else
        {
            solve(shop, steps);
        }
    }

    void solve(int shop, int steps)
    {
      
        if (shop == 0)
        {
            return;
        }
        else if (shop == steps - 2)
        {
            answer += shop;
        }
        else
        {
            solve( shop - 1, steps - 1);
            solve( shop + 1, steps - 1);
        }
    }
    void OnExecute() 
    {
        string[] input = File.ReadAllText(inputFile).Split();
        try
        {

            int n = int.Parse(input[0]);

            int k = int.Parse(input[1]);
            if (n != 0 || n <= k)
            {                
                entry(n, k);
                Console.WriteLine(answer);
                File.WriteAllText(outputFile, answer.ToString());
            }
            else
            {
                Console.WriteLine("Distance to shop equal 0 or bigger than amount of steps");
            }
           
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
        
    }

}
