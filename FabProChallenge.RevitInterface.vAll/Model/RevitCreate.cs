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
            EffortResult toReturn = new EffortResult();

            //var viewType = RevitUtilitiesVAll.GetAllInDocOfType<ViewFamilyType>(ActiveDoc)
            //     .FirstOrDefault(x => x.ViewFamily == ViewFamily.ThreeDimensional);
            
            AssemblyInstance selectAssembly = GetSelectAssembly();

            if (selectAssembly != null)
            {

                var newView = AssemblyViewUtils.Create3DOrthographic(ActiveDoc, selectAssembly.Id);

                //View3D view3D = View3D.CrkeateIsometric(ActiveDoc, viewType.Id);

                newView.Name = viewName;

                toReturn.MarkSuccessful();
            }

            return toReturn;
        }

        private AssemblyInstance GetSelectAssembly()
        {
           return RevitUtilitiesVAll.GetSelectElementsOfType<AssemblyInstance>(ActiveUiDoc).FirstOrDefault();
        }

        private EffortResult CreateBOMView(string viewName)
        {
            EffortResult toReturn = new EffortResult();

            AssemblyInstance selectAssembly = GetSelectAssembly();

            if (selectAssembly != null)
            {
                var newView = AssemblyViewUtils.CreatePartList(ActiveDoc, selectAssembly.Id);
                newView.Name = viewName;
                toReturn.MarkSuccessful();
            }
            else
            {
                toReturn.MarkFailed("No assembly selected");
            }

            return toReturn;
        }

        private EffortResult CreateDetailView(string viewName, AssemblyDetailViewOrientation orientation)
        {
            EffortResult toReturn = new EffortResult();

            AssemblyInstance selectAssembly = GetSelectAssembly();

            if (selectAssembly != null)
            {
                var newView = AssemblyViewUtils.CreateDetailSection(ActiveDoc, selectAssembly.Id, orientation);
                newView.Name = viewName;
                toReturn.MarkSuccessful();
            }
            else
            {
                toReturn.MarkFailed("No assembly selected");
            }

            return toReturn;
        }


        public EffortResult CreateBOMTransaction()
        {
            var toReturn = new EffortResult();

            using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction(Constants.Transactions.Prefix.CreateBOMView))
            {
                try
                {
                    transaction.Start();
                    toReturn = this.CreateBOMView(Constants.Views.Prefix.BOMViewNamePrefix +  Guid.NewGuid().ToString());
                    transaction.CommitIfSuccess(toReturn);
                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    toReturn.MarkFailed(ex.ToString());
                    MessageBox.Show(toReturn.ErrorMessagesBigString().ToString());
                }
            }

            return toReturn;
        }


        public EffortResult CreateDetailViewWithTransaction(AssemblyDetailViewOrientation orientation)
        {
            var toReturn = new EffortResult();

            using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction(Constants.Transactions.Prefix.CreateDetailView))
            {
                try
                {
                    transaction.Start();
                    toReturn = this.CreateDetailView(Constants.Views.Prefix.DetailViewNamePrefix + "." + orientation.ToString() + "." + Guid.NewGuid().ToString(), orientation);
                    transaction.CommitIfSuccess(toReturn);
                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    toReturn.MarkFailed(ex.ToString());
                    MessageBox.Show(toReturn.ErrorMessagesBigString().ToString());
                }
            }

            return toReturn;
        }

        public EffortResult CreateAssemblyElemTransaction()
        {
            var toReturn = new EffortResult();

            using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction(Constants.Transactions.Prefix.CreateAssemblyElement))
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

                using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction(Constants.Transactions.Prefix.NameAssembly))
                {
                    try
                    {
                        transaction.Start();
                        toReturn = CrudHub.RevitUpdate.NameAssembly(Constants.AssemblyNamePrefix + Guid.NewGuid().ToString(), lastElemId);
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

            //var selectAssembly = RevitUtilitiesVAll.GetSelectElements(ActiveUiDoc);

            AssemblyInstance assemblyElem = RevitUtilitiesVAll.GetSelectElementsOfType<AssemblyInstance>(ActiveUiDoc).FirstOrDefault();

            //FilteredElementCollector collector = new FilteredElementCollector(ActiveDoc, ActiveView.Id);

            //assemblyElem = collector
            //.OfClass(typeof(AssemblyInstance))
            //.Cast<AssemblyInstance>()
            //.FirstOrDefault();

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

            using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction(Constants.Transactions.Prefix.CreateAssemblySheet))
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

        public EffortResult Create3DViewWithTransaction()
        {
            var effortResult = new EffortResult();

            using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction(Constants.Transactions.Prefix.CreateThreeDimensionalView))
            {
                try
                {
                    transaction.Start();
                    effortResult = CrudHub.RevitCreate.Create3DView(Constants.Views.Prefix.ThreeDimensionalNamePrefix + Guid.NewGuid().ToString());
                    transaction.CommitIfSuccess(effortResult);
                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    effortResult.MarkFailed(ex.ToString());
                }
            }

            return effortResult;
        }
    }
}