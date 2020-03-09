using mertens3d.FabProChallenge.Shared.Models;

namespace FabPro.Shared.Interfaces
{
    public interface IRevitBroker
    {
        FpDocState GetFpDocState();
        void AddSelectViewToCurrentSheet(int viewToPlaceId);
        void Create3DView();
        void CreateAssemblyElem();
        void CreateAssemblySheet();
        void CreateTopView();
        void CreateFrontView();
    }
}