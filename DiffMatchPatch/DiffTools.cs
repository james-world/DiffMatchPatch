using System;

namespace DiffMatchPatch
{
    public static class DiffTools
    {
        public static int CommonPrefixLength(string text1, string text2)
        {
            int smallestLength = Math.Min(text1.Length, text2.Length);
            for (var i = 0; i < smallestLength; i++)
            {
                if (text1[i] != text2[i])
                    return i;
            }

            return smallestLength;
        }
        
        public static int CommonSuffixLength(string text1, string text2)
        {
            int text1Length = text1.Length;
            int text2Length = text2.Length;
            int smallestLength = Math.Min(text1Length, text2Length);
            for (var i = 1; i <= smallestLength; i++)
            {
                if (text1[text1Length - i] != text2[text2Length - i])
                    return i - 1;
            }

            return smallestLength;
        }
    }
}