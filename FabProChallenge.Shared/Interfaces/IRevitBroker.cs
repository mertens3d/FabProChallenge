using mertens3d.FabProChallenge.Shared.Models;

namespace FabPro.Shared.Interfaces
{
    public interface IRevitBroker
    {
        FpDocState GetFpDocState();
        void AddSelectViewToCurrentSheet(int viewToPlaceId);
        void CreateAssemblyElem();
        void CreateAssemblySheet();
        void CreateView3D();
        void CreateViewBOM();
        void CreateViewFront();
        void CreateViewTop();
    }
}