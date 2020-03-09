using Autodesk.Revit.UI;
using FabProChallenge.RevitInterface.vAll.Interfaces;

namespace FabProChallenge.RevitInterface.vAll
{
    public interface IRevitCRUDVSpec
    {
        ExternalCommandData CommandData { get; set; }

        IRevitTransaction FactoryTransaction(string transactionName);
    }
}