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

        internal List<FpView> GetAllEligibleViews()
        {
            return FpDocState.ElegibleViews;
        }

        public void Init()
        {
            SubscribeToMenuEvents();
        }

        public void SubscribeToMenuEvents()
        {
            Hub.EventMan.ActionTriggerPlaceSelectViewOnSheet -= AddSelectViewToCurrentSheet;
            Hub.EventMan.ActionTriggerPlaceSelectViewOnSheet += AddSelectViewToCurrentSheet;

            Hub.EventMan.ActionTriggerAddMarks -= AddMarks;
            Hub.EventMan.ActionTriggerAddMarks += AddMarks;

            Hub.EventMan.ActionTriggerCreateAssemblyElem -= Broker.CreateAssemblyElem;
            Hub.EventMan.ActionTriggerCreateAssemblyElem += Broker.CreateAssemblyElem;

            Hub.EventMan.ActionTriggerCreateAssemblySheet -= Broker.CreateAssemblySheet;
            Hub.EventMan.ActionTriggerCreateAssemblySheet += Broker.CreateAssemblySheet;

            Hub.EventMan.ActionTriggerCreateBOM -= Broker.CreateViewBOM;
            Hub.EventMan.ActionTriggerCreateBOM += Broker.CreateViewBOM;

            Hub.EventMan.ActionTriggerCreateFrontView -= Broker.CreateViewFront;
            Hub.EventMan.ActionTriggerCreateFrontView += Broker.CreateViewFront;

            Hub.EventMan.ActionTriggerCreateTopView -= Broker.CreateViewTop;
            Hub.EventMan.ActionTriggerCreateTopView += Broker.CreateViewTop;

            Hub.EventMan.ActionTriggerCreate3DView -= Broker.CreateView3D;
            Hub.EventMan.ActionTriggerCreate3DView += Broker.CreateView3D;
        }

        private void AddSelectViewToCurrentSheet()
        {
            FpView currentlySelectViewId = Hub.UiMan.CurrentSelectViewId();
            if (currentlySelectViewId != null)
            {
                Broker.AddSelectViewToCurrentSheet(currentlySelectViewId.ViewId);
            }
            else
            {
                MessageBox.Show("No currently selected view");
            }
        }

        private void AddMarks()
        {
            MessageBox.Show("Add Marks - not implemented");
        }
    }
}