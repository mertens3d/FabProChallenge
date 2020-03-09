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

        internal FpDocState GetFabProDocState()
        {
            return RevitUtilitiesVAll.GetFabProDocState(ActiveDoc, ActiveView);
        }
    }
}