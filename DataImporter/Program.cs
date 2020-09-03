using System;
using CottonHarvesterHIDFileImportPlugin.PublisherDataModel.ExampleData;

namespace DataExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Publishes example data to my documents
            CottonHarvesterHIDFileImportPlugin.Plugin plugin = new CottonHarvesterHIDFileImportPlugin.Plugin();
            plugin.RunPlugin();
        }
    }
}
