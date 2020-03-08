using FabPro.Shared.Interfaces;
using FabPro.Shared.Managers;
using mertens3d.FabProChallenge.Shared.Interfaces;
using mertens3d.FabProChallenge.Shared.Models;
using System.Collections.Generic;
using System.Windows;

namespace mertens3d.FabPro.Shared.Managers
{
    public class RevitManager : ManagerBase
    {
        private FpDocState _fpDocState;

        public EffortResult LastEffort { get; set; } = new EffortResult();

        private IRevitBroker Broker { get; set; }
        public FpDocState FpDocState { get { return _fpDocState ?? (_fpDocState = Broker.GetFpDocState()); } }

        public RevitManager(ManagerHub hub, IRevitBroker broker) : base(hub)
        {
            Broker = broker;
        }

        internal List<FpView> GetAllViews()
        {
            return FpDocState.Views;
        }

        public void Init()
        {
            SubscribeToMenuEvents();
        }

        public void SubscribeToMenuEvents()
        {
            Hub.EventMan.ActionTriggerPlaceOnSheet -= PlaceOnSheet;
            Hub.EventMan.ActionTriggerPlaceOnSheet += PlaceOnSheet;

            Hub.EventMan.ActionTriggerAddMarks -= AddMarks;
            Hub.EventMan.ActionTriggerAddMarks += AddMarks;

            Hub.EventMan.ActionTriggerCreateAssemblyElem -= Broker.CreateAssemblyElem;
            Hub.EventMan.ActionTriggerCreateAssemblyElem += Broker.CreateAssemblyElem;

            Hub.EventMan.ActionTriggerCreateAssemblySheet -= Broker.CreateAssemblySheet;
            Hub.EventMan.ActionTriggerCreateAssemblySheet += Broker.CreateAssemblySheet;

            Hub.EventMan.ActionTriggerCreateBOM -= CreateBOM;
            Hub.EventMan.ActionTriggerCreateBOM += CreateBOM;

            Hub.EventMan.ActionTriggerCreateFrontView -= CreateFrontView;
            Hub.EventMan.ActionTriggerCreateFrontView += CreateFrontView;

            Hub.EventMan.ActionTriggerCreateTopAndFrontViews -= CreateTopAndFrontViews;
            Hub.EventMan.ActionTriggerCreateTopAndFrontViews += CreateTopAndFrontViews;

            Hub.EventMan.ActionTriggerCreateTopView -= CreateTopView;
            Hub.EventMan.ActionTriggerCreateTopView += CreateTopView;

            Hub.EventMan.ActionTriggerCreate3DView -= Broker.Create3DView;
            Hub.EventMan.ActionTriggerCreate3DView += Broker.Create3DView;
        }

        private void CreateTopView()
        {
            MessageBox.Show("Create Top View - not implemented");
        }

        private void CreateTopAndFrontViews()
        {
            MessageBox.Show("Dim Top and Front - not implemented");
        }

        private void CreateFrontView()
        {
            MessageBox.Show("Create Front View - not implemented");
        }

        private void CreateBOM()
        {
            MessageBox.Show("Create BOM - not implemented");
        }

        private void AddMarks()
        {
            MessageBox.Show("Add Marks - not implemented");
        }

        private void PlaceOnSheet()
        {
            MessageBox.Show("Place On Sheet - not implemented");
        }
    }
}