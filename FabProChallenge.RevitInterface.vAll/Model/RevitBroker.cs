﻿using Autodesk.Revit.DB;
using FabPro.Shared.Interfaces;
using mertens3d.FabProChallenge.Shared.Models;

namespace FabProChallenge.RevitInterface.vAll.Model
{
    public class RevitBroker : IRevitBroker
    {
        private RevitCrudHub CrudHub { get; set; }
        private EffortResult LastEffortResult { get; set; } = new EffortResult();

        public RevitBroker(RevitCrudHub crudHub)
        {
            this.CrudHub = crudHub;
        }

        public void Create3DView()
        {
            CrudHub.RevitCreate.Create3DViewWithTransaction();
        }
        public void CreateTopView()
        {
            CrudHub.RevitCreate.CreateDetailViewWithTransaction(AssemblyDetailViewOrientation.ElevationTop);
        } 
        public void CreateFrontView()
        {
            CrudHub.RevitCreate.CreateDetailViewWithTransaction(AssemblyDetailViewOrientation.ElevationFront);
        }
        public void CreateAssemblyElem()
        {
            CrudHub.RevitCreate.CreateAssemblyElemTransaction();
        }

        public void AddSelectViewToCurrentSheet(int viewToPlaceId)
        {
            CrudHub.RevitUpdate.AddVioewToCurrentSheetTransaction(viewToPlaceId);
        }

        public void CreateAssemblySheet()
        {
            CrudHub.RevitCreate.CreateAssemblySheetWithTransaction();
        }

        public FpDocState GetFpDocState()
        {
            return CrudHub.RevitRead.GetFabProDocState();
        }

        //    public List<FpView> GetAllViews()
        //    {
        //       //return  CrudHub.RevitRead.GetAllViews();// .Read.GetFpDocState().FpDocState.Views.Select(x => x.ViewFriendly).ToList();

        //            List<FpView> toReturn = new List<FpView>();

        //        var allViews = CrudHub.RevitRead.GetAllViewData();

        //            return toReturn;

        //}

        //public void CreateAssemblySheetWTransaction()
        //{
        //    LastEffort = new EffortResult();

        //    using (IRevitTransaction transaction = Broker..CreateAssemblySheet.FactoryTransaction("Create Assembly Sheet"))
        //    {
        //        try
        //        {
        //            transaction.Start();
        //            LastEffort = Broker.CreateAssemblySheet();
        //            transaction.CommitIfSuccess(LastEffort);

        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.RollBack();
        //            LastEffort.MarkFailed(ex.ToString());
        //            MessageBox.Show(LastEffort.ErrorMessagesBigString().ToString());
        //        }
        //    }
        //}
    }
}