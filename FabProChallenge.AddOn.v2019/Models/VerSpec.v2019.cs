using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FabPro.Shared.Interfaces;
using FabProChallenge.RevitInterface.vAll.Utilities;
using mertens3d.FabProChallenge.AddOn.v2019.Models;
using mertens3d.FabProChallenge.Shared.Interfaces;
using mertens3d.FabProChallenge.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace mertens3d.FabProAddOn.v2019.Models
{
    public class RevitActionsVerSpectV2019 : IRevitActionsVerSpec
    {
        private IRevitDocState _docState;

        public IRevitDocState DocState { get { return _docState ?? (_docState = new RevitDocState2019(externalCommandData)); } }

        public UIDocument ActiveUiDoc { get { return externalCommandData.Application.ActiveUIDocument; } }
        public Document ActiveDoc { get { return ActiveUiDoc.Document; } }
        public View ActiveView { get { return ActiveDoc.ActiveView; } }

        private ExternalCommandData externalCommandData { get; set; }

        public RevitActionsVerSpectV2019(ExternalCommandData externalCommandData)
        {
            this.externalCommandData = externalCommandData;
        }

        public string RevitVersionStr { get; set; } = "2019";

        public IRevitTransaction FactoryTransaction(string transactionName)
        {
            IRevitTransaction toReturn = null;

            if (externalCommandData != null)
            {
                toReturn = new Revitv2019Transaction(externalCommandData, transactionName);
            }

            return toReturn;
        }

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

        public EffortResult CreateAssemblyElem()
        {
            EffortResult toReturn = new EffortResult();
            List<ElementId> SelectElemIds = RevitUtilitiesVAll.GetSelectElements(ActiveUiDoc);

            if (SelectElemIds.Any())
            {
                ElementId categoryId = ActiveDoc.GetElement(SelectElemIds.First()).Category.Id;
                //ElementId categoryId = new ElementId( BuiltInCategory.OST_FabricationPipework);

                if (AssemblyInstance.IsValidNamingCategory(ActiveDoc, categoryId, SelectElemIds))
                {
                    var assemblyInstance = AssemblyInstance.Create(ActiveDoc, SelectElemIds, categoryId);
                    toReturn.PayloadId = assemblyInstance.Id.IntegerValue;
                    toReturn.MarkSuccessful();
                }
                else
                {
                    toReturn.MarkFailed("Invalid naming category: " + categoryId.ToString());
                }
            }
            else
            {
                toReturn.MarkFailed("No elements selected");
            }

            return toReturn;
        }

        public EffortResult NameAssembly(string name, int assemblyId)
        {
            var toReturn = new EffortResult();

            AssemblyInstance elem = ActiveDoc.GetElement(new ElementId(assemblyId)) as AssemblyInstance;

            if (elem != null)
            {
                elem.AssemblyTypeName = name;
                toReturn.MarkSuccessful();
            }
            else
            {
                toReturn.MarkFailed("Could not find assembly: " + assemblyId);
            }

            return toReturn;
        }

        private ElementId GetTitleBlockByName(string targetName)
        {
            var found = new FilteredElementCollector(ActiveDoc)
                .OfClass(typeof(FamilySymbol))
                .OfCategory(BuiltInCategory.OST_TitleBlocks)
                .FirstOrDefault(x => x.Name.Equals(targetName, System.StringComparison.OrdinalIgnoreCase));

            return found.Id;
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

        public EffortResult CreateAssemblySheet()
        {
            var toReturn = new EffortResult();

            var selectAssembly = RevitUtilitiesVAll. GetSelectElements(ActiveUiDoc);

            AssemblyInstance assemblyElem = selectAssembly
                .Select(x => ActiveDoc.GetElement(x))
                .Where(x => x.GetType() == typeof(AssemblyInstance))
                .FirstOrDefault() as AssemblyInstance;

            FilteredElementCollector collector = new FilteredElementCollector(ActiveDoc, ActiveView.Id);

            assemblyElem = collector
            .OfClass(typeof(AssemblyInstance))
            .Cast<AssemblyInstance>()
            .FirstOrDefault();

            if (assemblyElem != null)
            {
                //AssemblyType assemblyElem = (AssemblyType)ActiveDoc.GetElement(filteredByType);
                if (assemblyElem != null)
                {
                    var targetTitleBlock = "B 11 x 17 Horizontal";
                    var foundTb = GetTitleBlockByName(targetTitleBlock);
                    if (foundTb != null)
                    {
                        var viewSheet = AssemblyViewUtils.CreateSheet(ActiveDoc, assemblyElem.Id, foundTb);
                        if (viewSheet != null)
                        {
                            toReturn.MarkSuccessful();
                        }
                    }
                    else
                    {
                        toReturn.MarkFailed("Unable to find titleblock: " + targetTitleBlock);
                    }
                }
                else
                {
                    toReturn.MarkFailed("Unable to get assembly from ID");
                }
            }
            else
            {
                toReturn.MarkFailed("No Assembly Selected");
            }

            return toReturn;
        }
    }
}