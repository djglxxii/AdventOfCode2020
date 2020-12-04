using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Passport : List<KeyValuePair<string, string>>
    {
        public bool IsValid()
        {
            //example of valid
            //ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
            //byr:1937 iyr:2017 cid:147 hgt:183cm
            bool isValid = true;

            var allKeys = this.Select(k => k.Key).ToArray();

            isValid &= allKeys.Any(k => k == "ecl");
            isValid &= allKeys.Any(k => k == "pid");
            isValid &= allKeys.Any(k => k == "eyr");
            isValid &= allKeys.Any(k => k == "hcl");
            isValid &= allKeys.Any(k => k == "byr");
            isValid &= allKeys.Any(k => k == "iyr");
            isValid &= allKeys.Any(k => k == "hgt");
            
            return isValid;
        }
    }
}
