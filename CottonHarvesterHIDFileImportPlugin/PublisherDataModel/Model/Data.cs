using System;
using System.Collections.Generic;
using System.Text;

namespace CottonHarvesterHIDFileImportPlugin.PublisherDataModel
{
    /// <summary>
    /// A top level data container for the publishers data.
    /// This classes in this folder represent an existing data model 
    /// that a publishing company may already have and wish to expose
    /// through the ADAPT Framework.
    /// </summary>
    public class Data
    {
        public HIDData HIDData { get; set; }
        public List<Client> Clients { get; set; }

        public Data()
        {
            HIDData = new HIDData();
            Clients = new List<Client>();
        }
    }

    public class BaseObject
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
