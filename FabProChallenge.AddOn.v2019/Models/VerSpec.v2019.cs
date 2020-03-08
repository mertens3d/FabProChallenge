using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FabProChallenge.RevitInterface.vAll.Utilities;
using mertens3d.FabProChallenge.AddOn.v2019;
using mertens3d.FabProChallenge.Shared.Models;
using System.Linq;

namespace mertens3d.FabProAddOn.v2019.Models
{
    public class RevitFireWallV2019
    {
        //private IRevitDocState _docState;
        private FpDocState _fpDocState;

        //public IRevitDocState DocState { get { return _docState ?? (_docState = new RevitDocState2019(externalCommandData)); } }

        public UIDocument ActiveUiDoc { get { return externalCommandData.Application.ActiveUIDocument; } }
        public Document ActiveDoc { get { return ActiveUiDoc.Document; } }
        public View ActiveView { get { return ActiveDoc.ActiveView; } }

        public FpDocState FpDocState
        {
            get { return _fpDocState ?? (_fpDocState = RevitUtilitiesVAll.GetFabProDocState(ActiveDoc)); }
        }

        private ExternalCommandData externalCommandData { get; set; }

        public RevitFireWallV2019(ExternalCommandData externalCommandData)
        {
            this.externalCommandData = externalCommandData;
        }

        public string RevitVersionStr { get; set; } = AddOnConstants.RevitVersion;

        public EffortResult Create3DView(string viewName)
        {
            EffortResult toReturn = new EffortResult();

            ViewFamilyType viewType = new FilteredElementCollector(externalCommandData.Application.ActiveUIDocument.Document)
                .OfClass(typeof(ViewFamilyType))
                .Cast<ViewFamilyType>()
                .FirstOrDefault(x => x.ViewFamily == ViewFamily.ThreeDimensional);

            if (viewType != null)
            {
                View3D view3D = View3D.CreateIsometric(ActiveDoc, viewType.Id);

                view3D.Name = viewName;

                toReturn.MarkSuccessful();
            }

            return toReturn;
        }

        private EffortResult AddViewToSheet(int selectSheetId, int selectViewId)
        {
            var toReturn = new EffortResult();

            var selectSheetElem = ActiveDoc.GetElement(new ElementId(selectSheetId));
            var selectViewElem = ActiveDoc.GetElement(new ElementId(selectViewId));

            if (selectViewElem != null && selectViewElem != null)
            {
                if (Viewport.CanAddViewToSheet(ActiveDoc, selectSheetElem.Id, selectViewElem.Id))
                {
                }
                else
                {
                    toReturn.MarkFailed("Cannot add select element to select view");
                }
            }
            else
            {
                toReturn.MarkFailed("Either the Sheet Id or the View Id is invalid");
            }
            return toReturn;
        }
    }
}