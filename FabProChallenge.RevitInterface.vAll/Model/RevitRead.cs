using FabProChallenge.RevitInterface.vAll;
using FabProChallenge.RevitInterface.vAll.Model;
using FabProChallenge.RevitInterface.vAll.Utilities;
using mertens3d.FabProChallenge.Shared.Models;

namespace FabPro.Shared.Interfaces
{
    internal class RevitRead : RevitCrudBase
    {
        public RevitRead(RevitCrudHub crudHub) : base(crudHub)
        {
        }

        //FpDocState DocState { get; }
        //string RevitVersionStr { get; set; }

        //internal List<View> GetAllViewData()
        //{
        //  return  RevitUtilitiesVAll.GetAllViewsInDoc(ActiveDoc);
        //}

        internal FpDocState GetFabProDocState()
        {
            return RevitUtilitiesVAll.GetFabProDocState(ActiveDoc, ActiveView);
        }
    }
}