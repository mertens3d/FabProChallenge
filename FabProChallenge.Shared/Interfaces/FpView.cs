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

        private int ViewId { get; set; }
        private string ViewFriendly { get; set; }
        private FpViewTypes ViewType { get; set; }
    }
}