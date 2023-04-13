#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;

using System.Reflection;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls;

#endregion

namespace RAB_Session06Challenge
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            // Get the assembly name
            string assemblyName = GetAssemblyName();
            string path = System.IO.Path.GetDirectoryName(assemblyName);


            //Create a ribbon tab called "Revit Add-in Bootcamp"

            a.CreateRibbonTab("Revit Add-in Bootcamp");


            //Create a ribbon panel called "Revit Tools"

           RibbonPanel ribbonPanel1 = a.CreateRibbonPanel("Revit Add-in Bootcamp", "Revit Tools");

            //Create push buttons (Tool 1, Tool 2)
            PushButtonData pushButtonData1 = new PushButtonData("ToolN1", "Tool1", assemblyName, "RAB_Session06Challenge.CmdCommand1");
            PushButtonData pushButtonData2 = new PushButtonData("ToolN2", "Tool2", assemblyName, "RAB_Session06Challenge.CmdCommand2");
            PushButtonData pushButtonData3 = new PushButtonData("ToolN3", "Tool3", assemblyName, "RAB_Session06Challenge.CmdCommand3");
            PushButtonData pushButtonData4 = new PushButtonData("ToolN4", "Tool4", assemblyName, "RAB_Session06Challenge.CmdCommand4");
            PushButtonData pushButtonData5 = new PushButtonData("ToolN5", "Tool5", assemblyName, "RAB_Session06Challenge.CmdCommand5");
            PushButtonData pushButtonData6 = new PushButtonData("ToolN6", "Tool6", assemblyName, "RAB_Session06Challenge.CmdCommand6");
            PushButtonData pushButtonData7 = new PushButtonData("ToolN7", "Tool7", assemblyName, "RAB_Session06Challenge.CmdCommand7");
            PushButtonData pushButtonData8 = new PushButtonData("ToolN8", "Tool8", assemblyName, "RAB_Session06Challenge.CmdCommand8");
            PushButtonData pushButtonData9 = new PushButtonData("ToolN9", "Tool9", assemblyName, "RAB_Session06Challenge.CmdCommand9");
            PushButtonData pushButtonData10 = new PushButtonData("ToolN10", "Tool10", assemblyName, "RAB_Session06Challenge.CmdCommand10");
           
            //Add images

            pushButtonData1.LargeImage = new BitmapImage(new Uri(path + @"\Blue_32.png"));
            pushButtonData2.LargeImage = new BitmapImage(new Uri(path + @"\Green_32.png"));
            pushButtonData3.Image = new BitmapImage(new Uri(path + @"\Red_16.png"));
            pushButtonData4.Image = new BitmapImage(new Uri(path + @"\Yellow_16.png"));
            pushButtonData5.Image = new BitmapImage(new Uri(path + @"\Blue_16.png"));
            pushButtonData6.LargeImage = new BitmapImage(new Uri(path + @"\Red_32.png"));
            pushButtonData7.LargeImage = new BitmapImage(new Uri(path + @"\Green_32.png"));
            pushButtonData8.LargeImage = new BitmapImage(new Uri(path + @"\Blue_32.png"));
            pushButtonData9.LargeImage = new BitmapImage(new Uri(path + @"\Green_32.png"));
            pushButtonData10.LargeImage = new BitmapImage(new Uri(path + @"\Red_32.png"));

            //add tooltips
            pushButtonData1.ToolTip = "this is a tool tip for push button1";
            pushButtonData2.ToolTip = "this is a tool tip for push button2";
            pushButtonData3.ToolTip = "this is a tool tip for push button3";
            pushButtonData4.ToolTip = "this is a tool tip for push button4";
            pushButtonData5.ToolTip = "this is a tool tip for push button5";
            pushButtonData6.ToolTip = "this is a tool tip for push button6";
            pushButtonData7.ToolTip = "this is a tool tip for push button7";
            pushButtonData8.ToolTip = "this is a tool tip for push button8";
            pushButtonData9.ToolTip = "this is a tool tip for push button9";
            pushButtonData10.ToolTip = "this is a tool tip for push button10";




            //Add buttons to the ribbon panel
            ribbonPanel1.AddItem(pushButtonData1);
            ribbonPanel1.AddItem(pushButtonData2);

            //Add a separator
            ribbonPanel1.AddSeparator();

            //Create 1 stacked row containing 3 push buttons (Tool 3, Tool 4, Tool 5)

            ribbonPanel1.AddStackedItems(pushButtonData3, pushButtonData4,pushButtonData5);

            //Add a separator
            ribbonPanel1.AddSeparator();

            //Create 1 split button containing 2 push buttons (Tool 6, Tool 7)
            SplitButtonData splitButtonData = new SplitButtonData("Sbd1", "SBD1");
            SplitButton sb1 = ribbonPanel1.AddItem(splitButtonData) as SplitButton;
            sb1.AddPushButton(pushButtonData6);
            sb1.AddPushButton(pushButtonData7);

            //Create 1 pulldown button (called "More Tools) containing 3 push buttons (Tool 8, Tool 9, Tool 10)

            PulldownButtonData pulldownButtonData = new PulldownButtonData("More Tools", "PullDown Button Data");
            PulldownButton pdb1 = ribbonPanel1.AddItem(pulldownButtonData) as PulldownButton;
            pdb1.LargeImage = new BitmapImage(new Uri(path + @"\Yellow_32.png"));
            pdb1.AddPushButton(pushButtonData8);
            pdb1.AddPushButton(pushButtonData9);
            pdb1.AddPushButton(pushButtonData10);




            return Result.Succeeded;
        }



        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        private string GetAssemblyName()
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;
            return assemblyName;
        }
    }
}
