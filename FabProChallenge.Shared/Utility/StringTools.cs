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
                if (toReturn.Length > finalLength - SharedConstants.Misc.Elipses.Length)
                {
                    toReturn = toReturn.Substring(0, finalLength - SharedConstants.Misc.Elipses.Length) + SharedConstants.Misc.Elipses;
                }
            }

            return toReturn;
        }
    }
}