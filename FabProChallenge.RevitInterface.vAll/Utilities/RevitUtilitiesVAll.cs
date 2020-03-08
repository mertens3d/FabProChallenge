using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using mertens3d.FabProChallenge.Shared.Enums;
using mertens3d.FabProChallenge.Shared.Interfaces;
using mertens3d.FabProChallenge.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace FabProChallenge.RevitInterface.vAll.Utilities
{
    public static class RevitUtilitiesVAll
    {
        public static FpDocState GetFabProDocState(Document doc)
        {
            var toReturn = new FpDocState();
            
            RevitUtilitiesVAll.GetAllViewsInDoc(doc)
                .ForEach(x => toReturn.Views.Add(new FpView(x.Id.IntegerValue, x.Name, (FpViewTypes)x.ViewType)));

            return toReturn;
        }

        public static ElementId GetTitleBlockByName(string targetName, Document doc)
        {
            var found = new FilteredElementCollector(doc)
                .OfClass(typeof(FamilySymbol))
                .OfCategory(BuiltInCategory.OST_TitleBlocks)
                .FirstOrDefault(x => x.Name.Equals(targetName, System.StringComparison.OrdinalIgnoreCase));

            return found.Id;
        }

        public static List<View> GetAllViewsInDoc(Document doc)
        {
            return GetAllInDocOfType<View>(doc);
        }

        public static List<T> GetSelectElementsOfType<T>(UIDocument doc)
        {
            List<T> toReturn =
              RevitUtilitiesVAll.GetSelectElements(doc)
              .Select(x => doc.Application.ActiveUIDocument.Document.GetElement(x))
              .Where(x => x.GetType() == typeof(T))
              .Cast<T>() 
              .ToList();

            return toReturn;
        }

        public static List<ElementId> GetSelectElements(UIDocument doc)
        {
            var toReturn = doc
                .Selection
                .GetElementIds()
                .ToList();

            return toReturn;
        }

        public static List<T> GetAllInDocOfType<T>(Document doc)
        {
            List<T> toReturn = new FilteredElementCollector(doc)
                 .OfClass(typeof(T))
                 .Cast<T>()
                 .ToList();

            return toReturn;
        }
    }
}