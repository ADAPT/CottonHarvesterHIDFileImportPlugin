using System;
using System.Collections.Generic;
using System.Text;

namespace CottonHarvesterHIDFileImportPlugin.PublisherDataModel
{
    public class HIDData : BaseObject
    {
        public List<HIDRecord> HIDRecords { get; set; }

        public HIDData()
        {
            HIDRecords = new List<HIDRecord>();
        }
    }

    public class HIDRecord
    {
        public string ModuleID { get; set; }
        public string ModuleSN { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string GMTDate { get; set; }
        public string GMTTime { get; set; }
        public string TagCount { get; set; }
        public string Client { get; set; }
        public string Farm { get; set; }
        public string Field { get; set; }
        public string Variety { get; set; }
        public string MachinePIN { get; set; }
        public string Operator { get; set; }
        public string GinID { get; set; }
        public string ProducerID { get; set; }
        public string LocalTime { get; set; }
        public string FieldArea { get; set; }
        public string SeasonTotalModules { get; set; }
        public string Moisture { get; set; }
        public string Diameter { get; set; }
        public string Weight { get; set; }
        public string DropLat { get; set; }
        public string DropLon { get; set; }
        public string FieldTotal { get; set; }
        public string IncrementalArea { get; set; }
        public string LocalDate { get; set; }
        public string Comment { get; set; }
    }

    public class FlatFileHelper
    {
        public static HIDData ConvertFlatFileToJDHIDModel(string input)
        {
            HIDData hidData = new HIDData();
            HIDRecord hidRecord = new HIDRecord();

            string[] result = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                string j = result[i].ToString();
                string[] currentRecord = j.Split(',');
                if (result[0].Equals(("Module ID")))
                {
                    continue;
                }

                hidRecord.ModuleID = "";
                if (currentRecord[0].Length > 0) { hidRecord.ModuleID = currentRecord[0]; }

                hidRecord.ModuleID = "";
                if (currentRecord[1].Length > 0) { hidRecord.ModuleID = currentRecord[1]; }

                hidRecord.Lat = "";
                if (currentRecord[2].Length > 0) { hidRecord.Lat = currentRecord[2]; }

                hidRecord.Lon = "";
                if (currentRecord[3].Length > 0) { hidRecord.Lon = currentRecord[3]; }

                hidRecord.GMTDate = "";
                if (currentRecord[4].Length > 0) { hidRecord.GMTDate = currentRecord[4]; }

                hidRecord.GMTTime = "";
                if (currentRecord[5].Length > 0) { hidRecord.GMTTime = currentRecord[5]; }

                hidRecord.TagCount = "";
                if (currentRecord[6].Length > 0) { hidRecord.TagCount = currentRecord[6]; }

                hidRecord.Client = "";
                if (currentRecord[7].Length > 0) { hidRecord.Client = currentRecord[7]; }

                hidRecord.Farm = "";
                if (currentRecord[8].Length > 0) { hidRecord.Farm = currentRecord[8]; }

                hidRecord.Field = "";
                if (currentRecord[9].Length > 0) { hidRecord.Field = currentRecord[9]; }

                hidRecord.Variety = "";
                if (currentRecord[10].Length > 0) { hidRecord.Variety = currentRecord[10]; }

                hidRecord.MachinePIN = "";
                if (currentRecord[11].Length > 0) { hidRecord.MachinePIN = currentRecord[11]; }

                hidRecord.Operator = "";
                if (currentRecord[12].Length > 0) { hidRecord.Operator = currentRecord[12]; }

                hidRecord.GinID = "";
                if (currentRecord[13].Length > 0) { hidRecord.GinID = currentRecord[13]; }

                hidRecord.ProducerID = "";
                if (currentRecord[14].Length > 0) { hidRecord.ProducerID = currentRecord[14]; }

                hidRecord.LocalTime = "";
                if (currentRecord[15].Length > 0) { hidRecord.LocalTime = currentRecord[15]; }

                hidRecord.FieldArea = "";
                if (currentRecord[16].Length > 0) { hidRecord.FieldArea = currentRecord[16]; }

                hidRecord.SeasonTotalModules = "";
                if (currentRecord[17].Length > 0) { hidRecord.SeasonTotalModules = currentRecord[17]; }

                hidRecord.Moisture = "";
                if (currentRecord[18].Length > 0) { hidRecord.Moisture = currentRecord[18]; }

                hidRecord.Diameter = "";
                if (currentRecord[19].Length > 0) { hidRecord.Diameter = currentRecord[19]; }

                hidRecord.Weight = "";
                if (currentRecord[20].Length > 0) { hidRecord.Weight = currentRecord[20]; }

                hidRecord.DropLat = "";
                if (currentRecord[21].Length > 0) { hidRecord.DropLat = currentRecord[21]; }

                hidRecord.DropLon = "";
                if (currentRecord[22].Length > 0) { hidRecord.DropLon = currentRecord[22]; }

                hidRecord.FieldTotal = "";
                if (currentRecord[23].Length > 0) { hidRecord.FieldTotal = currentRecord[23]; }

                hidRecord.IncrementalArea = "";
                if (currentRecord[24].Length > 0) { hidRecord.IncrementalArea = currentRecord[24]; }

                hidRecord.LocalDate = "";
                if (currentRecord[25].Length > 0) { hidRecord.LocalDate = currentRecord[25]; }

                hidRecord.Comment = "";
                if (currentRecord[26].Length > 0) { hidRecord.Comment = currentRecord[26]; }

                hidData.HIDRecords.Add(hidRecord);
            }

            return hidData;
        }

        public static void ConvertFlatFileToCustomModel(string input, Data data)
        {
            string[] result = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                string j = result[i].ToString();
                string[] currentRecord = j.Split(',');
                    
                if (currentRecord[0].Equals(("Module ID")))
                {
                    continue;
                }

                //Load client if it doesn't yet exist.
                bool containsClient = false;
                foreach(Client currentClient in data.Clients)
                {
                    if (currentClient.Name == currentRecord[7])
                    {
                        containsClient = true;
                        break;
                    }
                }

                if (!containsClient)
                {
                    Client client = new Client();
                    client.Name = currentRecord[7];
                    data.Clients.Add(client);
                }

                //Load the farm for the current client
                bool containsFarm = false;
                foreach(Client currentClient in data.Clients)
                {
                    if(currentClient.Name == currentRecord[7])
                    {
                        foreach(Farm currentFarm in currentClient.Farms)
                        {
                            if(currentFarm.Name == currentRecord[8])
                            {
                                containsFarm = true;
                                break;
                            }
                        }

                        if (!containsFarm)
                        {
                            Farm farm = new Farm();
                            farm.Name = currentRecord[8];
                            currentClient.Farms.Add(farm);
                        }
                    }
                }

                //Load the field for the current farm
                bool containsField = false;
                foreach (Client currentClient in data.Clients)
                {
                    if (currentClient.Name == currentRecord[7])
                    {
                        foreach (Farm currentFarm in currentClient.Farms)
                        {
                            if (currentFarm.Name == currentRecord[8])
                            {
                                foreach(Field currentField in currentFarm.Fields)
                                {
                                    if(currentField.Name == currentRecord[9])
                                    {
                                        containsField = true;
                                        break;
                                    }
                                }

                                if (!containsField)
                                {
                                    Field field = new Field();
                                    field.Name = currentRecord[9];
                                    currentFarm.Fields.Add(field);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}