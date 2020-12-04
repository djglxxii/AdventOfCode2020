using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day4
{
    public class PassportV2 : Passport
    {
        public override bool IsValid()
        {
            bool isValid = true;

            isValid &= IsValidBirthYear();
            isValid &= IsValidIssueYear();
            isValid &= IsValidExpirationYear();
            isValid &= IsValidHeight();
            isValid &= IsValidHairColor();
            isValid &= IsValidEyeColor();
            isValid &= IsValidPassportId();
            
            return isValid;
        }

        // byr (Birth Year) - four digits; at least 1920 and at most 2002.
        private bool IsValidBirthYear()
        {
            return IsValidIntRange(GetKvpByKey("byr").Value, 1920, 2002);
        }

        // iyr (Issue Year) - four digits; at least 2010 and at most 2020.
        private bool IsValidIssueYear()
        {
            return IsValidIntRange(GetKvpByKey("iyr").Value, 2010, 2020);
        }

        // eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
        private bool IsValidExpirationYear()
        {
            return IsValidIntRange(GetKvpByKey("eyr").Value, 2020, 2030);
        }

        // hgt (Height) - a number followed by either cm or in:
        //     If cm, the number must be at least 150 and at most 193.
        //     If in, the number must be at least 59 and at most 76.
        private bool IsValidHeight()
        {
            var hgtVal = GetKvpByKey("hgt").Value;

            if (string.IsNullOrEmpty(hgtVal)) return false;

            string valStr = hgtVal.Substring(0, hgtVal.Length - 2);
            string units = hgtVal.Substring(hgtVal.Length - 2, 2);

            switch (units)
            {
                case "cm":
                    return IsValidIntRange(valStr, 150, 193);

                case "in":
                    return IsValidIntRange(valStr, 59, 76);

                default:
                    return false;
            }
        }

        // hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        private bool IsValidHairColor()
        {
            var hclVal = GetKvpByKey("hcl").Value;

            if (string.IsNullOrEmpty(hclVal)) return false;
            
            if (!hclVal.StartsWith("#") || hclVal.Length != 7) return false;
            
            return int.TryParse(hclVal.Replace("#", ""),
                NumberStyles.HexNumber,
                CultureInfo.InvariantCulture,
                out int _);
        } 
        
        // ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        private bool IsValidEyeColor()
        {
            var eclVal = GetKvpByKey("ecl").Value;

            string[] validColors = new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

            return validColors.Any(c => c == eclVal);
        }

        // pid (Passport ID) - a nine-digit number, including leading zeroes.
        private bool IsValidPassportId()
        {
            var pidVal = GetKvpByKey("pid").Value;

            if (string.IsNullOrEmpty(pidVal)) return false;
            
            if (pidVal.Length != 9) return false;

            return int.TryParse(pidVal, out int _);
        }
        
        private KeyValuePair<string, string> GetKvpByKey(string key)
        {
            return this.SingleOrDefault(e => e.Key == key);
        }

        private bool IsValidIntRange(string valueStr, int min, int max)
        {
            if (int.TryParse(valueStr, out int value))
            {
                return value >= min && value <= max;
            }

            return false;
        }
    }
}
