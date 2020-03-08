using mertens3d.FabProChallenge.Shared.Models;

namespace FabPro.Shared.Interfaces
{
    public interface IFpUpdate
    {
        EffortResult NameAssembly(string name, int assemblyId);
    }
}