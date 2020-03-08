using mertens3d.FabProChallenge.Shared.Interfaces;
using mertens3d.FabProChallenge.Shared.Models;
using System.Collections.Generic;

namespace FabPro.Shared.Interfaces
{
    public interface IVerSpec
    {
        string RevitVersionStr { get; set; }

        IRevitTransaction FactoryTransaction(string transactionSuffix);
        EffortResult Create3DView(string viewName);
        EffortResult CreateAssemblyElem();
        EffortResult NameAssembly(string name, int assemblyId);
        EffortResult CreateAssemblySheet();
    }
}