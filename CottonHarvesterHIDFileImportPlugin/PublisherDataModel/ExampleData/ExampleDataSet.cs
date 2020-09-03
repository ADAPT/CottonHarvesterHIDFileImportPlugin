using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CottonHarvesterHIDFileImportPlugin.PublisherDataModel.ExampleData
{
    /// <summary>
    /// This class exists simply for the purposes of generating data for the example.
    /// In normal usage, this data would already exist.
    /// In this case, we are serializing the model to JSON
    /// A publisher may wish to serialize to protobuf
    /// or another proprietary format that is not natively decipherable by the data consumers
    /// </summary>
    public static class ExampleDataSet
    {
        //public static Data GenerateExampleData()
        //{
        //    Data data = new Data();

        //    //Generate example A&B Farms
        //    Client abFarms = new Client() { ID = Guid.NewGuid(), Name = "A & B Farms" };
        //    data.Clients.Add(abFarms);
        //    Farm abFarmsHome = new Farm() { ID = Guid.NewGuid(), Name = "Home Farm" };
        //    abFarms.Farms.Add(abFarmsHome);
        //    Field abFarmsHomeQuarter = new Field() { ID = Guid.NewGuid(), Name = "Home Quarter" };
        //    abFarmsHome.Fields.Add(abFarmsHomeQuarter);
        //    Field abFarmsEastField = new Field() { ID = Guid.NewGuid(), Name = "East Field" };
        //    abFarmsHome.Fields.Add(abFarmsEastField);
        //    Farm abFarmsWest = new Farm() { ID = Guid.NewGuid(), Name = "West Farm" };
        //    abFarms.Farms.Add(abFarmsWest);
        //    Field abFarmsWestField = new Field() { ID = Guid.NewGuid(), Name = "West Field" };
        //    abFarmsWest.Fields.Add(abFarmsWestField);
            
        //    //Generate example crops
        //    Crop corn = new Crop() { ID = Guid.NewGuid(), Name = "Corn" };
        //    data.CropData.Crops.Add(corn);
        //    Crop wheat = new Crop() { ID = Guid.NewGuid(), Name = "Wheat" };
        //    data.CropData.Crops.Add(wheat);

        //    //Generate example crop assiignements
        //    data.CropData.CropAssignments.Add(new CropAssignment() { CropID = corn.ID, FieldID = abFarmsEastField.ID , GrowingSeason = 2018});
        //    data.CropData.CropAssignments.Add(new CropAssignment() { CropID = wheat.ID, FieldID = abFarmsHomeQuarter.ID, GrowingSeason = 2018 });
        //    data.CropData.CropAssignments.Add(new CropAssignment() { CropID = corn.ID, FieldID = abFarmsWestField.ID, GrowingSeason = 2018 });

        //    return data;
        //}

        //public static void PublishExampleData()
        //{
        //    Data data = GenerateExampleData();
        //    string json = JsonConvert.SerializeObject(data);

        //    //C# code to identify the well known "My Documents" folder as an export location
        //    string exportPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //    //Serializes the example data to a file (see a copy in this project directory)
        //    string exampleFile = Path.Combine(exportPath, "Data.myjson");
        //    File.WriteAllText(exampleFile, json);
        //}
    }
}
