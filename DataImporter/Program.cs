using System;

namespace DataImporter
{
    /// <summary>
    /// This program acts as a basic driver and test harness for developers to use when testing code changes in
    /// the Cotton Harvester HID File Import Plugin. This is a handy method for stepping through the plugin code
    /// before final testing is performed with the ADAPT Visualizer.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //First, create a new instance of the Cotton Harvester HID plugin below
            CottonHarvesterHIDFileImportPlugin.Plugin plugin = new CottonHarvesterHIDFileImportPlugin.Plugin();

            //Set the path to your test file below
            string dataPath = @"C:\Projects\OAGi\ADAPT\JD";

            //Call the RunPlugin method, passing in the path to your test data file
            plugin.RunPlugin(dataPath);
        }
    }
}