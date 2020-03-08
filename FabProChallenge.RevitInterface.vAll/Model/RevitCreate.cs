using Autodesk.Revit.DB;
using FabProChallenge.RevitInterface.vAll.Interfaces;
using FabProChallenge.RevitInterface.vAll.Utilities;
using mertens3d.FabProChallenge.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FabProChallenge.RevitInterface.vAll.Model
{
    internal class RevitCreate : RevitCrudBase
    {
      

        public EffortResult Create3DView(string viewName)
        {
            var toReturn = new EffortResult();

            return toReturn;
        }

        public EffortResult CreateAssemblyElemTransaction()
        {
            var toReturn = new EffortResult();

            using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction("Create Assembly Element"))
            {
                try
                {
                    transaction.Start();
                    toReturn = CrudHub.RevitCreate.CreateAssemblyElem();
                    transaction.CommitIfSuccess(toReturn);
                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    toReturn.MarkFailed(ex.ToString());
                    MessageBox.Show(toReturn.ErrorMessagesBigString().ToString());
                }
            }

            if (toReturn.WasSuccessful())
            {
                var lastElemId = toReturn.PayloadId;

                toReturn = new EffortResult();

                using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction("Name Assembly"))
                {
                    try
                    {
                        transaction.Start();
                        toReturn = CrudHub.RevitUpdate.NameAssembly("mertens.gregory " + Guid.NewGuid().ToString(), lastElemId);
                        transaction.CommitIfSuccess(toReturn);
                    }
                    catch (Exception ex)
                    {
                        transaction.RollBack();
                        toReturn.MarkFailed(ex.ToString());
                        MessageBox.Show(toReturn.ErrorMessagesBigString().ToString());
                    }
                }
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

        private EffortResult CreateAssemblySheet()
        {
            var toReturn = new EffortResult();

            var selectAssembly = RevitUtilitiesVAll.GetSelectElements(ActiveUiDoc);

            AssemblyInstance assemblyElem = RevitUtilitiesVAll.GetSelectElementsOfType<AssemblyInstance>(ActiveUiDoc).FirstOrDefault();

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
                    var foundTb = RevitUtilitiesVAll.GetTitleBlockByName(Constants.TargetTitleBlockName, ActiveDoc);
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
                        toReturn.MarkFailed("Unable to find titleblock: " + Constants.TargetTitleBlockName);
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

        internal EffortResult CreateAssemblySheetWithTransaction()
        {
            EffortResult LastEffort = new EffortResult();

            using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction("Create Assembly Sheet"))
            {
                try
                {
                    transaction.Start();
                    LastEffort = this.CreateAssemblySheet();
                    transaction.CommitIfSuccess(LastEffort);
                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    LastEffort.MarkFailed(ex.ToString());
                    MessageBox.Show(LastEffort.ErrorMessagesBigString().ToString());
                }
            }

            return LastEffort;
        }

        public RevitCreate(RevitCrudHub crudHub) : base(crudHub)
        {
        }

        public void Create3DView()
        {
            MessageBox.Show("Create 3D View");

            using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction("make 3d View"))
            {
                try
                {
                    transaction.Start();
                    var result = CrudHub.RevitCreate.Create3DView("mertens.gregory " + Guid.NewGuid().ToString());
                    transaction.CommitIfSuccess(result);
                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}