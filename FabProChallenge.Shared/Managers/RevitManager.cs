using FabPro.Shared.Managers;
using mertens3d.FabProChallenge.Shared.Interfaces;
using mertens3d.FabProChallenge.Shared.Models;
using System;
using System.Windows;

namespace mertens3d.FabPro.Shared.Managers
{
    public class RevitManager : ManagerBase
    {
        public EffortResult LastEffort { get; set; } = new EffortResult();

        public RevitManager(ManagerHub hub) : base(hub)
        {
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

            Hub.EventMan.ActionTriggerCreateAssembly -= CreateAssemblyElem;
            Hub.EventMan.ActionTriggerCreateAssembly += CreateAssemblyElem;

            Hub.EventMan.ActionTriggerCreateAssemblySheet -= CreateAssemblySheet;
            Hub.EventMan.ActionTriggerCreateAssemblySheet += CreateAssemblySheet;

            Hub.EventMan.ActionTriggerCreateBOM -= CreateBOM;
            Hub.EventMan.ActionTriggerCreateBOM += CreateBOM;

            Hub.EventMan.ActionTriggerCreateFrontView -= CreateFrontView;
            Hub.EventMan.ActionTriggerCreateFrontView += CreateFrontView;

            Hub.EventMan.ActionTriggerCreateTopAndFrontViews -= CreateTopAndFrontViews;
            Hub.EventMan.ActionTriggerCreateTopAndFrontViews += CreateTopAndFrontViews;

            Hub.EventMan.ActionTriggerCreateTopView -= CreateTopView;
            Hub.EventMan.ActionTriggerCreateTopView += CreateTopView;

            Hub.EventMan.ActionTriggerCreate3DView -= Create3DView;
            Hub.EventMan.ActionTriggerCreate3DView += Create3DView;
        }

        private void Create3DView()
        {
            MessageBox.Show("Create 3D View");

            using (IRevitTransaction transaction = Hub.VerSpec.FactoryTransaction("make 3d View"))
            {
                try
                {
                    transaction.Start();
                    var result = Hub.VerSpec.Create3DView("mertens.gregory " + Guid.NewGuid().ToString());
                    transaction.CommitIfSuccess(result);
                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void CreateTopView()
        {
            MessageBox.Show("Create Top View");
        }

        private void CreateTopAndFrontViews()
        {
            MessageBox.Show("Dim Top and Front");
        }

        private void CreateFrontView()
        {
            MessageBox.Show("Create Front View");
        }

        private void CreateBOM()
        {
            MessageBox.Show("Create BOM");
        }

        private void CreateAssemblySheet()
        {

            LastEffort = new EffortResult();

            using (IRevitTransaction transaction = Hub.VerSpec.FactoryTransaction("Create Assembly Sheet"))
            {
                try
                {
                    transaction.Start();
                    LastEffort = Hub.VerSpec.CreateAssemblySheet();
                    transaction.CommitIfSuccess(LastEffort);

                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    LastEffort.MarkFailed(ex.ToString());
                    MessageBox.Show(LastEffort.ErrorMessagesBigString().ToString());
                }
            }
        }

        private void CreateAssemblyElem()
        {
            LastEffort = new EffortResult();

            using (IRevitTransaction transaction = Hub.VerSpec.FactoryTransaction("Create Assembly Element"))
            {
                try
                {
                    transaction.Start();
                    LastEffort = Hub.VerSpec.CreateAssemblyElem();
                    transaction.CommitIfSuccess(LastEffort);

                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    LastEffort.MarkFailed(ex.ToString());
                    MessageBox.Show(LastEffort.ErrorMessagesBigString().ToString());
                }
            }

            if (LastEffort.WasSuccessful())
            {
                var lastElemId = LastEffort.PayloadId;

                LastEffort = new EffortResult();
                
                using (IRevitTransaction transaction = Hub.VerSpec.FactoryTransaction("Name Assembly"))
                {
                    try
                    {
                        transaction.Start();
                        LastEffort = Hub.VerSpec.NameAssembly("mertens.gregory " + Guid.NewGuid().ToString(), lastElemId);
                        transaction.CommitIfSuccess(LastEffort);

                    }
                    catch (Exception ex)
                    {
                        transaction.RollBack();
                        LastEffort.MarkFailed(ex.ToString());
                        MessageBox.Show(LastEffort.ErrorMessagesBigString().ToString());
                    }
                }
            }



        }

        private void AddMarks()
        {
            MessageBox.Show("Add Marks");
        }

        private void PlaceOnSheet()
        {
            MessageBox.Show("Place On Sheet");
        }
    }
}