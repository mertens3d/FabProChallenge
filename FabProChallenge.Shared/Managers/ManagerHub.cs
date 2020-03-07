using FabPro.Shared.Interfaces;
using mertens3d.FabPro.Shared.Managers;

namespace FabPro.Shared.Managers
{
    public class ManagerHub
    {
        private UiManager _uiManager;
        private EventsManager _eventManager;

        public UiManager UiManager { get { return _uiManager ?? (_uiManager = new UiManager(this)); } }
        public EventsManager EventManager { get { return _eventManager ?? (_eventManager = new EventsManager(this)); } }

        public ManagerHub(IVerSpec verSpec)
        {
            VerSpect = verSpec;
        }

        public IVerSpec VerSpect { get; private set; }

        public bool TriggerBigBang()
        {
            var result = false;

            UiManager.ShowMenu();

            return result;
        }
    }
}