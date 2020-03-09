namespace FabProChallenge.RevitInterface.vAll
{
    internal static class Constants
    {
        internal static string AssemblyNamePrefix = "mertens.";
        internal static string TargetTitleBlockName = "B 11 x 17 Horizontal";
        
        


        internal struct Views
        {
            internal struct Prefix
            {
                internal static string DetailViewNamePrefix = "mertens.detail.view.";
                internal static string ThreeDimensionalNamePrefix = "mertens.3d.";
            }
        }

        internal struct Transactions
        {
            public struct Prefix
            {
                internal static string CreateAssemblyElement = "Create Assembly Element";
                internal static string CreateAssemblySheet = "Create Assembly Sheet";
                internal static string NameAssembly = "Name Assembly";
                internal static string CreateThreeDimensionalView = "Create 3d View";
                internal static string PlaceSelectViewOnSheet = "Place Select View on Current Sheet";
                internal static string CreateDetailView = "Create Detail View";
            }
        }
    }
}