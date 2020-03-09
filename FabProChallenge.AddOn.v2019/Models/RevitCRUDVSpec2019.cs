using Autodesk.Revit.UI;
using FabProChallenge.RevitInterface.vAll;
using FabProChallenge.RevitInterface.vAll.Interfaces;
using mertens3d.FabProChallenge.AddOn.v2019.Models;

namespace mertens3d.FabProAddOn.v2019
{
    internal class RevitCRUDVSpec2019 : IRevitCRUDVSpec
    {
        public ExternalCommandData CommandData { get; set; }

        public IRevitTransaction FactoryTransaction(string transactionName)
        {
            IRevitTransaction toReturn = null;

            if (CommandData != null)
            {
                toReturn = new Revitv2019Transaction(CommandData, transactionName);
            }

            return toReturn;
        }

        public RevitCRUDVSpec2019(ExternalCommandData CommandData)
        {
            this.CommandData = CommandData;
        }
    }
}