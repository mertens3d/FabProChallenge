using mertens3d.FabProChallenge.Shared.Enums;

namespace mertens3d.FabProChallenge.Shared.Interfaces
{
    public class FpView
    {
        public FpView(int integerValue, string viewName, FpViewTypes viewType)
        {
            this.ViewId = integerValue;
            this.ViewFriendly = viewName;
            this.ViewType = viewType;
        }

        public string ViewNameForDialog
        {
            get
            {
                var fullStr = ViewType.ToString() + SharedConstants.Misc.ViewDivider + ViewFriendly;

                fullStr = Utility.StringTools.PadStringRight(fullStr, PaddingStyle.ElipsesRight, SharedConstants.Layout.ViewListCharCount);

                return fullStr;
            }
        }

        public int ViewId { get; set; }
        public string ViewFriendly { get; set; }
        public FpViewTypes ViewType { get; set; }
    }
}