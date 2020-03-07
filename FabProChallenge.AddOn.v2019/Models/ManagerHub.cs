//using System;
//using FabPro.Shared.Interfaces;
//using FabPro.Shared.Managers;

//namespace mertens3d.FabProAddOn.v2019.Models
//{
//    public class ManagerHub
//    {
//        private object _uiManager;

//        public UiManager UiManager { get {
//                return _uiManager ?? (_uiManager = new UiManager(this));

//            } }


//        public ManagerHub(IVerSpec verSpec)
//        {
//            this.VerSpect = verSpec;
//        }

//        public IVerSpec VerSpect { get; private set; }

//        internal bool TriggerBigBang()
//        {
//            var result = false;






//            return result;
//        }
//    }
//}