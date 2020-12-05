namespace Day2
{
    public class PasswordV2 : Password
    {
        public PasswordV2(string passwordStr) : base(passwordStr)
        {
        }

        public override bool IsValid()
        {
            int pos1 = _val1 - 1;
            int pos2 = _val2 - 1;

            return (_password[pos1] == _required && _password[pos2] != _required) ||
                   (_password[pos2] == _required && _password[pos1] != _required);
        }
    }
}