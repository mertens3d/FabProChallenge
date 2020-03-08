using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FabPro.Shared.Managers;
using FabProChallenge.RevitInterface.vAll;
using FabProChallenge.RevitInterface.vAll.Model;
using System.Windows;

namespace mertens3d.FabProAddOn.v2019
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]
    internal class ChallengeCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData externalCommandData, ref string message, ElementSet elements)
        {
            bool result = false;
            try
            {
                IRevitCRUDVSpec revitVspec2019 = new RevitCRUDVSpec2019(externalCommandData);
                var revitcrudHub = new RevitCrudHub(externalCommandData, revitVspec2019);

                RevitBroker revitBroker = new RevitBroker(revitcrudHub);

                var hub = new ManagerHub(revitBroker);

                hub.Init();
                result = hub.TriggerBigBang();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result ? Result.Succeeded : Result.Failed;
        }
    }
}