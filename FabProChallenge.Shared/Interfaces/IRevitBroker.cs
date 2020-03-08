using mertens3d.FabProChallenge.Shared.Models;

namespace FabPro.Shared.Interfaces
{
    public interface IRevitBroker
    {
        void Create3DView();

        void CreateAssemblyElem();

        void CreateAssemblySheet();

        FpDocState GetFpDocState();
    }
}