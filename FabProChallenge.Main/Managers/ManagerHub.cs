using FabProChallenge.Main.Models;
using FabProChallenge.RevitInterface.vAll.Model;
using mertens3d.FabPro.Shared.Managers;

namespace FabPro.Shared.Managers
{
    public class ManagerHub
    {
        private UiManager _uiManager;
        private EventsManager _eventManager;
        private RevitManager _revitManager;
        private BindableData _bindabledData;

        public UiManager UiMan { get { return _uiManager ?? (_uiManager = new UiManager(this)); } }
        public EventsManager EventMan { get { return _eventManager ?? (_eventManager = new EventsManager(this)); } }
        public RevitManager RevitMan { get { return _revitManager ?? (_revitManager = new RevitManager(this, Broker)); } }

        private RevitBroker Broker { get; set; }

        public BindableData BindableData { get { return _bindabledData ?? (_bindabledData = new BindableData()); } }

        public ManagerHub(RevitBroker broker)
        {
            this.Broker = broker;
        }

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