using Autodesk.Revit.DB;
using mertens3d.FabProChallenge.Shared.Models;
using System;

namespace FabProChallenge.RevitInterface.vAll.Model
{
    internal class RevitUpdate : RevitCrudBase
    {
        public RevitUpdate(RevitCrudHub crudHub) : base(crudHub)
        {
        }

        public EffortResult NameAssembly(string name, int assemblyId)
        {
            var toReturn = new EffortResult();

            AssemblyInstance elem = ActiveDoc.GetElement(new ElementId(assemblyId)) as AssemblyInstance;

            if (elem != null)
            {
                elem.AssemblyTypeName = name;
                toReturn.MarkSuccessful();
            }
            else
            {
                toReturn.MarkFailed("Could not find assembly: " + assemblyId);
            }

            return toReturn;
        }
    }
}