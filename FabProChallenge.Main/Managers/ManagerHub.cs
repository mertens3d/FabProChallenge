using FabProChallenge.Main.Models;
using FabProChallenge.RevitInterface.vAll.Model;
using mertens3d.FabPro.Shared.Managers;
using mertens3d.FabProChallenge.Shared.Models;

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

        public EffortResult TriggerBigBang()
        {
            EffortResult result = UiMan.ShowMenu();

            return result;
        }

        public void Init()
        {
            RevitMan.Init();
        }
    }
}