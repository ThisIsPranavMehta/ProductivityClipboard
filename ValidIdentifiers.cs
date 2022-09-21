using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace learningForms
{
    internal static class ValidIdentifiers
    {
        private static Dictionary<string,int> ValidKeys = new Dictionary<string, int>();            // storing ascii values for here. 
        static ValidIdentifiers()
        {
            ValidKeys.Add("48", 0);
            ValidKeys.Add("49",1);
            ValidKeys.Add("50",2);
            ValidKeys.Add("51",3);
            ValidKeys.Add("52",4);
            ValidKeys.Add("53",5);
            ValidKeys.Add("54",6);
            ValidKeys.Add("55",7);
            ValidKeys.Add("56",8);
            ValidKeys.Add("57",9);
            ValidKeys.Add("77",10);
            ValidKeys.Add("109",10);
            ValidKeys.Add("84", 11);
            ValidKeys.Add("116", 11);

        }

        internal static bool IsValidIdentifier(string AsciiValue)
        {
            return ValidKeys.ContainsKey(AsciiValue);
        }
        internal static int getChannelId(string AsciiValue)
        {
            return ValidKeys[AsciiValue];
        }
    }
}
