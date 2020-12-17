using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solutions.Day4
{
    public static class Solution
    {
        public static (int present, int valid) CountValidPassports(IEnumerable<string> input)
        {
            Dictionary<string, string> kvp = new Dictionary<string, string>();
            List<HackedPassport> passports = new List<HackedPassport>();

            foreach (string line in input)
            {
                if (line == string.Empty)
                {
                    passports.Add(new HackedPassport(kvp));
                    kvp = new Dictionary<string, string>();
                }
                else
                {
                    IEnumerable<string> kvps = line.Split(' ');

                    foreach (string s in kvps)
                    {
                        int separator = s.IndexOf(':');
                        string key = s.Substring(0, separator);
                        string value = s.Substring(separator + 1);

                        kvp.Add(key, value);
                    }
                }
            }
            
            passports.Add(new HackedPassport(kvp));

            var present = passports.Count(x => x.HasRequiredProperties);
            var valid = passports.Count(x => x.IsValidPassport());

            return (present, valid);
        }
    }

    public class HackedPassport
    {
        private IEnumerable<string> EyeColours { get; } = new []{"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

        public HackedPassport(Dictionary<string, string> kvp)
        {
            Byr = kvp.TryGetValue("byr", out string byr) ? int.Parse(byr) : 0;
            Iyr = kvp.TryGetValue("iyr", out string iyr) ? int.Parse(iyr) : 0;
            Eyr = kvp.TryGetValue("eyr", out string eyr) ? int.Parse(eyr) : 0;
            
            Hgt = kvp.TryGetValue("hgt", out string hgt) ? hgt : null;
            Ecl = kvp.TryGetValue("ecl", out string ecl) ? ecl : null;
            Hcl = kvp.TryGetValue("hcl", out string hcl) ? hcl : null;
            Pid = kvp.TryGetValue("pid", out string pid) ? pid : null;
            Cid = kvp.TryGetValue("cid", out string cid) ? cid : null;
        }

        public string Ecl { get; }

        public string Hcl { get; }

        public string Pid { get; }

        public string Cid { get; }

        public string Hgt { get; }

        public int Eyr { get; }

        public int Iyr { get; }

        public int Byr { get; }

        /// <summary>
        /// Whether this passport is valid.
        /// </summary>
        /// <returns></returns>
        public bool IsValidPassport()
        {
            if (!HasRequiredProperties)
            {
                return false;
            }
            
            bool byr = Byr >= 1920 && Byr <= 2002;
            bool iyr = Iyr >= 2010 && Iyr <= 2020;
            bool eyr = Eyr >= 2020 && Eyr <= 2030;

            string unit =  Hgt.Substring(Hgt.Length -2);
            bool hgt = false;
            
            if (int.TryParse(Hgt.Substring(0, Hgt.Length - 2), out int value))
            {
                if (unit == "cm")
                {
                    hgt = value >= 150 && value <= 193;
                }
                else if (unit == "in")
                {
                    hgt = value >= 59 && value <= 76;
                }
            }

            bool ecl = EyeColours.Contains(Ecl);
            bool hcl = Regex.IsMatch(Hcl, "#([0-9]|[a-f]){6}$");
            bool pid = Regex.IsMatch(Pid, "[0-9]{9}$");

            return byr && iyr && eyr && hgt && hcl && ecl && pid;
        }
        
        public bool HasRequiredProperties =>    !(Hcl is null ||
                                                  Pid is null ||
                                                  Hgt is null ||
                                                  Ecl is null ||
                                                  Eyr is 0 ||
                                                  Iyr is 0 ||
                                                  Byr is 0);
    }
}