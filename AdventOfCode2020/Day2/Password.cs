using System;
using System.Linq;

namespace Day2
{
    public class Password
    {
        protected int _val1;
        protected int _val2;
        protected char _required;
        protected char[] _password;

        public Password(string passwordStr)
        {
            var arr1 = passwordStr.Replace(":", "").Split(' ');
            _password = arr1.Last().ToCharArray();
            _required = Char.Parse(arr1[1]);

            var arr2 = arr1[0].Split('-');
            _val1 = int.Parse(arr2[0]);
            _val2 = int.Parse(arr2[1]);
        }

        public virtual bool IsValid()
        {
            int charCount = _password.Count(c => c == _required);

            return charCount >= _val1 && charCount <= _val2;
        }
    }
}