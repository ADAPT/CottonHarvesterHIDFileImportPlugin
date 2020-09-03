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
        public static string ConvertFlatFileToJSON(string input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"HIDData\": { \"HIDRecords\": [");

            string[] result = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                foreach (string j in result)
                {
                    string[] currentRecord = j.Split(',');
                    if (currentRecord[0].Equals(("Module ID")))
                    {
                        continue;
                    }
                    sb.Append("{");
                    sb.Append("\"ModuleID\": \"" + currentRecord[0]);
                    sb.Append("\"ModuleSN\": \"" + currentRecord[1]);
                    sb.Append("\"Lat\": \"" + currentRecord[2]);
                    sb.Append("\"Lon\": \"" + currentRecord[3]);
                    sb.Append("\"GMT Date\": \"" + currentRecord[4]);
                    sb.Append("\"GMT Time\": \"" + currentRecord[5]);
                    sb.Append("\"Tag Count\": \"" + currentRecord[6]);
                    sb.Append("\"Client\": \"" + currentRecord[7]);
                    sb.Append("\"Farm\": \"" + currentRecord[8]);
                    sb.Append("\"Field\": \"" + currentRecord[9]);
                    sb.Append("\"Variety\": \"" + currentRecord[10]);
                    sb.Append("\"Machine PIN\": \"" + currentRecord[11]);
                    sb.Append("\"Operator\": \"" + currentRecord[12]);
                    sb.Append("\"Gin ID\": \"" + currentRecord[13]);
                    sb.Append("\"Producer ID\": \"" + currentRecord[14]);
                    sb.Append("\"Local Time\": \"" + currentRecord[15]);
                    sb.Append("\"Field Area\": \"" + currentRecord[16]);
                    sb.Append("\"Season Total Modules\": \"" + currentRecord[17]);
                    sb.Append("\"Moisture\": \"" + currentRecord[18]);
                    sb.Append("\"Diameter\": \"" + currentRecord[19]);
                    sb.Append("\"Weight\": \"" + currentRecord[20]);
                    sb.Append("\"Drop Lat\": \"" + currentRecord[21]);
                    sb.Append("\"Drop Lon\": \"" + currentRecord[22]);
                    sb.Append("\"Field Total\": \"" + currentRecord[23]);
                    sb.Append("\"Incremental Area\": \"" + currentRecord[24]);
                    sb.Append("\"Local Date\": \"" + currentRecord[25]);
                    sb.Append("\"Comment\": \"" + currentRecord[26]);
                    sb.Append("}");

                    if (i < result.GetUpperBound(0))
                    {
                        sb.Append(",");
                    }
                }
            }

            sb.Append("]}}");

            return sb.ToString();
        }

        public static HIDData ConvertFlatFileToModel(string input)
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

                hidRecord.ModuleID = currentRecord[0];
                hidRecord.ModuleSN = currentRecord[1];
                hidRecord.Lat = currentRecord[2];
                hidRecord.Lon = currentRecord[3];
                hidRecord.GMTDate = currentRecord[4];
                hidRecord.GMTTime = currentRecord[5];
                hidRecord.TagCount = currentRecord[6];
                hidRecord.Client = currentRecord[7];
                hidRecord.Farm = currentRecord[8];
                hidRecord.Field = currentRecord[9];
                hidRecord.Variety = currentRecord[10];
                hidRecord.MachinePIN = currentRecord[11];
                hidRecord.Operator = currentRecord[12];
                hidRecord.GinID = currentRecord[13];
                hidRecord.ProducerID = currentRecord[14];
                hidRecord.LocalTime = currentRecord[15];
                hidRecord.FieldArea = currentRecord[16];
                hidRecord.SeasonTotalModules = currentRecord[17];
                hidRecord.Moisture = currentRecord[18];
                hidRecord.Diameter = currentRecord[19];
                hidRecord.Weight = currentRecord[20];
                hidRecord.DropLat = currentRecord[21];
                hidRecord.DropLon = currentRecord[22];
                hidRecord.FieldTotal = currentRecord[23];
                hidRecord.IncrementalArea = currentRecord[24];
                hidRecord.LocalDate = currentRecord[25];
                hidRecord.Comment = currentRecord[26];

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