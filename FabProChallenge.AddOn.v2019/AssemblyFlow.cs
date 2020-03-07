using System.Reflection;
using System.Text;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FabPro.Shared.Managers;
using mertens3d.FabProAddOn.v2019.Models;

namespace mertens3d.FabProAddOn.v2019
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]
    [Obfuscation(Exclude = true, ApplyToMembers = true)]
    // ReSharper disable once InconsistentNaming
    internal class hatch22v2019 : IExternalCommand
    {
        public Result Execute(ExternalCommandData externalCommandData, ref string message, ElementSet elements)
        {

            var verSpec = new VerSpecV2019(externalCommandData);
            var hub = new ManagerHub(verSpec);

            var result = hub.TriggerBigBang();

            return result ? Result.Succeeded : Result.Failed;
        }
    }
}