using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CottonHarvesterHIDFileImportPlugin.PublisherDataModel
{
    public class Link
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

    public class Link2
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

    public class WrapLocation
    {
        [JsonProperty("@Type")]
        public string Type { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class Moisture
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public int value { get; set; }
        public string unitId { get; set; }
    }

    public class Diameter
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public int value { get; set; }
        public string unitId { get; set; }
    }

    public class Weight
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public int value { get; set; }
        public string unitId { get; set; }
    }

    public class DropLocation
    {
        [JsonProperty("@Type")]
        public string Type { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class IncrementalArea
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public int value { get; set; }
        public string unitId { get; set; }
    }

    public class Value
    {
        public List<Link2> links { get; set; }
        public long moduleSerialNumber { get; set; }
        public string moduleId { get; set; }
        public WrapLocation wrapLocation { get; set; }
        public DateTime wrapDateTime { get; set; }
        public DateTime localWrapDateTime { get; set; }
        public DateTime dataIngestionDate { get; set; }
        public int tagCount { get; set; }
        public string varietyName { get; set; }
        public string machinePin { get; set; }
        public string @operator { get; set; }
        public string ginId { get; set; }
        public string producerId { get; set; }
        public Moisture moisture { get; set; }
        public Diameter diameter { get; set; }
        public Weight weight { get; set; }
        public DropLocation dropLocation { get; set; }
        public IncrementalArea incrementalArea { get; set; }
        public string comment { get; set; }
    }

    public class Root
    {
        public List<Link> links { get; set; }
        public int total { get; set; }
        public List<Value> values { get; set; }
    }
}