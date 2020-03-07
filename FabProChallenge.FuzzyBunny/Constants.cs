namespace FuzzyBunny
{
    internal class Constants
    {
        private const string ReleasePrefix = "2020.03.07.13394";

#if DEBUG
        internal const string CurrentRelease = ReleasePrefix;// + ".*";
#else
        public const string CurrentRelease = ReleasePrefix;// + ".*";
#endif

        internal static void EnsureDependacy()
        {
        }
    }
}