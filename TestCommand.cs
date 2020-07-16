using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace BimExperts
{
    [Transaction(TransactionMode.Manual)]
    internal class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Test Command Window", "Greeting from the other side");
            return Result.Succeeded;
        }
    }
}