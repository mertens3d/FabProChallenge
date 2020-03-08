using FabPro.Shared.Interfaces;
using mertens3d.FabPro.Shared.Managers;
using System;

namespace FabPro.Shared.Managers
{
    public class ManagerHub
    {
        private UiManager _uiManager;
        private EventsManager _eventManager;
        private RevitManager _revitManager;

        public UiManager UiMan { get { return _uiManager ?? (_uiManager = new UiManager(this)); } }
        public EventsManager EventMan { get { return _eventManager ?? (_eventManager = new EventsManager(this)); } }
        public RevitManager RevitMan { get { return _revitManager ?? (_revitManager = new RevitManager(this)); } }

        public ManagerHub(IRevitActionsVerSpec verSpec)
        {
            VerSpec = verSpec;
        }

        public IRevitActionsVerSpec VerSpec { get; private set; }

        public bool TriggerBigBang()
        {
            var result = false;

            UiMan.ShowMenu();

            return true;
        }

        public void Init()
        {
            RevitMan.Init();
        }
    }
}