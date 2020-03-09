using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FabPro.Shared.Managers;
using FabProChallenge.RevitInterface.vAll;
using FabProChallenge.RevitInterface.vAll.Model;
using mertens3d.FabProChallenge.Shared.Models;
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
            EffortResult result = new EffortResult();
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
                result.MarkFailed(ex.ToString());
            }

            if (!result.WasSuccessful())
            {
                MessageBox.Show(result.ErrorMessagesBigString());
            }

            return result.WasSuccessful() ? Result.Succeeded : Result.Failed;
        }
    }
}