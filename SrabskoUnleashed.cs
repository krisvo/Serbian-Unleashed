using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SrabskoUnleashed
{
    static void Main()
    {
        var allVenues = new Dictionary<string, Dictionary<string, int>>();

        var input = Console.ReadLine();

        while (input != "End")
        {
            var tokens = input.Split(new[] { " @" }, StringSplitOptions.RemoveEmptyEntries);

            if (!(tokens.Length > 1))
            {
                input = Console.ReadLine();
                continue;
            }
            var singer = tokens[0];

            var tokens2 = tokens[1].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var ticketsCount = 0; ;
            var ticketPrice = 0;
            try
            {
                ticketsCount = int.Parse(tokens2[tokens2.Length - 1]);
                ticketPrice = int.Parse(tokens2[tokens2.Length - 2]);

            }
            catch
            {
                input = Console.ReadLine();
                continue;
            }


            var venue = new StringBuilder();
            for (int i = 0; i < tokens2.Length - 2; i++)
            {
                venue.Append(tokens2[i] + " ");
            }

            if (!allVenues.ContainsKey(venue.ToString()))
            {
                allVenues[venue.ToString()] = new Dictionary<string, int>() { { singer, ticketPrice * ticketsCount } };
            }
            else
            {
                if (!allVenues[venue.ToString()].ContainsKey(singer))
                {
                    allVenues[venue.ToString()].Add(singer, ticketPrice * ticketsCount);
                }
                else
                {
                    allVenues[venue.ToString()][singer] += ticketPrice * ticketsCount;
                }
            }

            input = Console.ReadLine();

        }

        foreach (var venue in allVenues)
        {
            Console.WriteLine(venue.Key);
            Console.WriteLine("{0}", string.Join("\n", venue.Value.OrderByDescending(a => a.Value).Select(a => $"#  {a.Key} -> {a.Value}")));
        }
    }
}