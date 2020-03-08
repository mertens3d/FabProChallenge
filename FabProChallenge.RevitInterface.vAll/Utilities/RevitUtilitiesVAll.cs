using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;

namespace FabProChallenge.RevitInterface.vAll.Utilities
{
    public static class RevitUtilitiesVAll
    {
        public static List<View> GetAllViewsInDoc(Document doc)
        {
            return GetAllInDocOfType<View>(doc);
          
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