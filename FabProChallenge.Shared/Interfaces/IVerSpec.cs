using mertens3d.FabProChallenge.Shared.Interfaces;

namespace FabPro.Shared.Interfaces
{
    public interface IVerSpec
    {
        string RevitVersionStr { get; set; }

        IRevitTransaction FactoryTransaction(string transactionSuffix, bool useUiDoc);
        bool Create3DView(string viewName);
    }
}