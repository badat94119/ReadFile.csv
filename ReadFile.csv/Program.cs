using System;
using System.Collections.Generic;
using System.IO;

class IPRange
{
    public string StartIP { get; set; }
    public string EndIP { get; set; }
    public int StartIPDecimal { get; set; }
    public int EndIPDecimal { get; set; }
    public string CountryCode { get; set; }
    public string CountryName { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Read the IP range list from a file
        List<IPRange> ipRanges = new List<IPRange>();
        using (StreamReader reader = new StreamReader("./ipranges.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');
                IPRange range = new IPRange();
                range.StartIP = fields[0].Trim('"');
                range.EndIP = fields[1].Trim('"');
                range.StartIPDecimal = int.Parse(fields[2]);
                range.EndIPDecimal = int.Parse(fields[3]);
                range.CountryCode = fields[4].Trim('"');
                range.CountryName = fields[5].Trim('"');
                ipRanges.Add(range);
            }
        }

        // Render the IP range list in the console
        foreach (IPRange range in ipRanges)
        {
            Console.WriteLine("{0} - {1} ({2} - {3}): {4} ({5})",
                range.StartIP, range.EndIP, range.StartIPDecimal, range.EndIPDecimal,
                range.CountryCode, range.CountryName);
        }
    }
}
