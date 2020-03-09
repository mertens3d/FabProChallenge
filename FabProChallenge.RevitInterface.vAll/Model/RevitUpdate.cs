using Autodesk.Revit.DB;
using FabProChallenge.RevitInterface.vAll.Interfaces;
using mertens3d.FabProChallenge.Shared.Models;
using System;
using System.Windows;

namespace FabProChallenge.RevitInterface.vAll.Model
{
    internal class RevitUpdate : RevitCrudBase
    {
        public RevitUpdate(RevitCrudHub crudHub) : base(crudHub)
        {
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

        private EffortResult AddViewToActiveSheet(int viewToPlaceInt)
        {
            EffortResult LastEffort = new EffortResult();

            var asViewSheet = ActiveView as ViewSheet;

            var viewToPlaceId = new ElementId(viewToPlaceInt);

            if (asViewSheet != null)
            {
                if (viewToPlaceId != null)
                {
                    if (Viewport.CanAddViewToSheet(ActiveDoc, asViewSheet.Id, viewToPlaceId))
                    {
                        Viewport.Create(ActiveDoc, asViewSheet.Id, viewToPlaceId, XYZ.Zero);
                        LastEffort.MarkSuccessful();
                    }
                    else
                    {
                        LastEffort.MarkFailed("View cannot be added to sheet");
                    }
                }
                else
                {
                    LastEffort.MarkFailed("View not found: " + viewToPlaceInt);
                }
            }
            else
            {
                LastEffort.MarkFailed("Current view is not valid");
            }

            return LastEffort;
        }

        internal EffortResult AddVioewToCurrentSheetTransaction(int viewToPlaceId)
        {
            EffortResult LastEffort = new EffortResult();

            using (IRevitTransaction transaction = CrudHub.RevitCrudVerSpec.FactoryTransaction(Constants.Transactions.Prefix.PlaceSelectViewOnSheet))
            {
                try
                {
                    transaction.Start();
                    LastEffort = this.AddViewToActiveSheet(viewToPlaceId);
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
    }
}