using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace BimExperts
{
    public class ExternalApp : IExternalApplication

    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            System.Diagnostics.Debugger.Launch();
            //add images
            Uri InfoImagePath = new Uri("pack://application:,,,/BimExperts;component/Resources/bim32x32.png");
            Uri MeasureAndCountImagePath = new Uri("pack://application:,,,/BimExperts;component/Resources/bim32x32_1.png");
            Uri TransitionImagePath = new Uri("pack://application:,,,/BimExperts;component/Resources/bim32x32_2.png");
            Uri ChangeHosteLevelImagePath = new Uri("pack://application:,,,/BimExperts;component/Resources/bim32x32_3.png");
            //Create Bitmap image
            BitmapImage InfoImage = new BitmapImage(InfoImagePath);
            BitmapImage MeasureAndCountImage = new BitmapImage(MeasureAndCountImagePath);
            BitmapImage ChangeHostedLevelImage = new BitmapImage(ChangeHosteLevelImagePath);
            BitmapImage TransitionImage = new BitmapImage(TransitionImagePath);
            //Create ribbon element

            //create ribbon
            string AssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData InfoData = new PushButtonData("Info", "Hello", AssemblyPath, "BimExperts.TestCommand");
            PushButtonData MeasureAndCountData = new PushButtonData("Measure and Count", "Hello", AssemblyPath, "BimExperts.TestCommand");
            PushButtonData TransitionData = new PushButtonData("Magic Transition", "Magic Transition", AssemblyPath, "BimExperts.CreateTransition");
            PushButtonData ChangeHosteLevelData = new PushButtonData("Change Hosted Level", "Hello", AssemblyPath, "BimExperts.TestCommand");

            InfoData.LargeImage = InfoImage;
            MeasureAndCountData.LargeImage = MeasureAndCountImage;
            TransitionData.LargeImage = TransitionImage;
            ChangeHosteLevelData.LargeImage = ChangeHostedLevelImage;

            //Add buttons to ribbon
            application.CreateRibbonTab("BimExperts");
            RibbonPanel panel = application.CreateRibbonPanel("BimExperts", "Commands");
            panel.AddItem(InfoData);
            panel.AddItem(MeasureAndCountData);
            panel.AddItem(TransitionData);
            panel.AddItem(ChangeHosteLevelData);

            return Result.Succeeded;
        }
    }
}