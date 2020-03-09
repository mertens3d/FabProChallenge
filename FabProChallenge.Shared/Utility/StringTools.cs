using mertens3d.FabProChallenge.Shared.Enums;

namespace mertens3d.FabProChallenge.Shared.Utility
{
    public static class StringTools
    {
        public static string PadStringRight(string target, PaddingStyle paddingStyle, int finalLength)
        {
            string toReturn = target;

            if (paddingStyle.Equals(PaddingStyle.ElipsesRight))
            {
                if (toReturn.Length > finalLength - 3)
                {
                    toReturn = toReturn.Substring(0, finalLength - 3) + "...";
                }
            }

            return toReturn;
        }
    }
}