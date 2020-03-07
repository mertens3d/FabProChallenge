using FabPro.Shared.Managers;

namespace mertens3d.FabPro.Shared.Managers
{
    public abstract class ManagerBase
    {
        public ManagerBase(ManagerHub hub)
        {
            Hub = hub;
        }

        public ManagerHub Hub { get; private set; }
    }
}