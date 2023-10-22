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
            return;
        }
        else if (shop == steps - 1)
        {
            answer = 0;
            return;
        }
        else if ((steps - shop) % 2 != 0)
        {
            answer = 0;
            return;
        }
        else if (steps == shop + 4)
        {
            float n = shop, k = steps, a = 0;
            a += (n + 3) * (n / 2);
            answer = (int)a;
            return;
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

            if (n != 0 && n <= k && k<=37)
            {                
                entry(10, 10);
                Console.WriteLine(answer);
                File.WriteAllText(outputFile, answer.ToString());
            }
            else
            {
                Console.WriteLine("Distance to shop equal 0, bigger than amount of steps or some of paramets bigger than 37");
            }
           
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
        
    }

}
