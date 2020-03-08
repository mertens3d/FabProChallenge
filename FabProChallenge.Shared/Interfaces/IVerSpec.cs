using mertens3d.FabProChallenge.Shared.Interfaces;
using mertens3d.FabProChallenge.Shared.Models;

namespace FabPro.Shared.Interfaces
{
    public interface IRevitActionsVerSpec
    {
        string RevitVersionStr { get; set; }

        IRevitDocState DocState { get; }
        IRevitTransaction FactoryTransaction(string transactionSuffix);
        EffortResult Create3DView(string viewName);
        EffortResult CreateAssemblyElem();
        EffortResult NameAssembly(string name, int assemblyId);
        EffortResult CreateAssemblySheet();
    }
}