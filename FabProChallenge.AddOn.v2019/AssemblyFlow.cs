using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FabPro.Shared.Managers;
using mertens3d.FabProAddOn.v2019.Models;
using System.Reflection;
using System.Windows;

namespace mertens3d.FabProAddOn.v2019
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]
    internal class Challenge : IExternalCommand
    {
        public Result Execute(ExternalCommandData externalCommandData, ref string message, ElementSet elements)
        {
            bool result = false;
            try
            {
                var verSpec = new RevitActionsVerSpectV2019(externalCommandData);
                var hub = new ManagerHub(verSpec);
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