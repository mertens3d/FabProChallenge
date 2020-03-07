using FabPro.Shared.Managers;
using mertens3d.FabProChallenge.Shared.Interfaces;
using System;
using System.Windows;

namespace mertens3d.FabPro.Shared.Managers
{
    public class RevitManager : ManagerBase
    {
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

            using(IRevitTransaction transaction = Hub.VerSpec.FactoryTransaction("make 3d View", true))
            {
                try
                {
                    transaction.Start();
                    var result = Hub.VerSpec.Create3DView("mertens.gregory " + Guid.NewGuid().ToString());
                    transaction.Commit();

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
            MessageBox.Show("Create Assembly Sheet");
        }

        private void CreateAssemblyElem()
        {
            MessageBox.Show("Create Assembly Elem");
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