using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.Documents;

namespace CottonHarvesterHIDFileImportPlugin.DataMappers
{
    public class HIDRecordMapper
    {
        public static AgGateway.ADAPT.ApplicationDataModel.Documents.ObsCollection MapHIDRecordObsCollection(PublisherDataModel.HIDRecord hidRecord, List<AgGateway.ADAPT.ApplicationDataModel.Documents.Obs> _obs, int obsCollectionID, AgGateway.ADAPT.ApplicationDataModel.Documents.ObsCollection obsCollection, ObsDataset obsDataset, ApplicationDataModel adm)
        {
            int obsIndex = 1;
            obsCollection.OMSourceId = obsCollectionID;

            //First associate the grower with the ObservationCollection
            bool containsGrower = false;
            Grower grower = null;
            foreach (Grower currentGrower in adm.Catalog.Growers)
            {
                if (currentGrower.Name.Trim() == hidRecord.Client.Trim())
                {
                    containsGrower = true;
                    grower = currentGrower;
                    break;
                }
            }

            if (containsGrower)
            {
                int? growerID = grower.Id.ReferenceId;
                growerID = growerID ?? default(int);
                obsCollection.GrowerId = growerID;
            }

            Obs Lat = new Obs();
            //Lat.OMCode = "JD-COT-HID-Lat";
            Lat.Value = hidRecord.Lat;
            Lat.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(Lat.Id.ReferenceId);
            _obs.Add(Lat);

            Obs Lon = new Obs();
            //Lon.OMCode = "JD-COT-HID-Lon";
            Lon.Value = hidRecord.Lat;
            Lon.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(Lon.Id.ReferenceId);
            _obs.Add(Lon);

            Obs TagCount = new Obs();
            //TagCount.OMCode = "JD-COT-HID-TagCount";
            TagCount.Value = hidRecord.TagCount;
            TagCount.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(TagCount.Id.ReferenceId);
            _obs.Add(TagCount);

            Obs Variety = new Obs();
            //Variety.OMCode = "JD-COT-HID-Variety";
            Variety.Value = hidRecord.Variety;
            Variety.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(Variety.Id.ReferenceId);
            _obs.Add(Variety);

            Obs Moisture = new Obs();
            //Moisture.OMCode = "JD-COT-HID-Moisture";
            Moisture.Value = hidRecord.Moisture;
            Moisture.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(Moisture.Id.ReferenceId);
            _obs.Add(Moisture);

            Obs Diameter = new Obs();
            //Diameter.OMCode = "JD-COT-HID-Diameter";
            Diameter.Value = hidRecord.Diameter;
            Diameter.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(Diameter.Id.ReferenceId);
            _obs.Add(Diameter);

            Obs Weight = new Obs();
            //Weight.OMCode = "JD-COT-HID-Weight";
            Weight.Value = hidRecord.Weight;
            Weight.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(Weight.Id.ReferenceId);
            _obs.Add(Weight);

            Obs DropLat = new Obs();
            //DropLat.OMCode = "JD-COT-HID-DropLat";
            DropLat.Value = hidRecord.DropLat;
            DropLat.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(DropLat.Id.ReferenceId);
            _obs.Add(DropLat);

            Obs DropLon = new Obs();
            //DropLon.OMCode = "JD-COT-HID-DropLon";
            DropLon.Value = hidRecord.DropLon;
            DropLat.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(DropLon.Id.ReferenceId);
            _obs.Add(DropLon);

            Obs FieldTotal = new Obs();
            //FieldTotal.OMCode = "JD-COT-HID-FieldTotal";
            FieldTotal.Value = hidRecord.FieldTotal;
            FieldTotal.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(FieldTotal.Id.ReferenceId);
            _obs.Add(FieldTotal);

            Obs IncrementalArea = new Obs();
            //IncrementalArea.OMCode = "JD-COT-HID-IncrementalArea";
            IncrementalArea.Value = hidRecord.IncrementalArea;
            IncrementalArea.GrowerId = obsCollection.GrowerId;
            obsCollection.ObsIds.Add(IncrementalArea.Id.ReferenceId);
            _obs.Add(IncrementalArea);

            return obsCollection;
        }

        public static AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load MapHIDRecord(PublisherDataModel.HIDRecord hidRecord, AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load load)
        {
            //Transform the native object into the ADAPT object
            ContextItem record = new ContextItem();
            record.Code = "JD-COT-HID";

            ContextItem ModuleID = new ContextItem();
            ModuleID.Code = "JD-COT-HID-ModuleID";
            ModuleID.Value = hidRecord.ModuleID;
            record.NestedItems.Add(ModuleID);

            ContextItem ModuleSN = new ContextItem();
            ModuleSN.Code = "JD-COT-HID-ModuleSN";
            ModuleSN.Value = hidRecord.ModuleSN;
            record.NestedItems.Add(ModuleSN);

            ContextItem GMTDate = new ContextItem();
            GMTDate.Code = "JD-COT-HID-GMTDate";
            GMTDate.Value = hidRecord.GMTDate;
            record.NestedItems.Add(GMTDate);

            ContextItem GMTTime = new ContextItem();
            GMTTime.Code = "JD-COT-HID-GMTTime";
            GMTTime.Value = hidRecord.GMTTime;
            record.NestedItems.Add(GMTTime);

            ContextItem Client = new ContextItem();
            Client.Code = "JD-COT-HID-Client";
            Client.Value = hidRecord.Client;
            record.NestedItems.Add(Client);

            ContextItem Farm = new ContextItem();
            Farm.Code = "JD-COT-HID-Farm";
            Farm.Value = hidRecord.Farm;
            record.NestedItems.Add(Farm);

            ContextItem Field = new ContextItem();
            Field.Code = "JD-COT-HID-Field";
            Field.Value = hidRecord.Field;
            record.NestedItems.Add(Field);

            ContextItem MachinePIN = new ContextItem();
            MachinePIN.Code = "JD-COT-HID-MachinePIN";
            MachinePIN.Value = hidRecord.MachinePIN;
            record.NestedItems.Add(MachinePIN);

            ContextItem Operator = new ContextItem();
            Operator.Code = "JD-COT-HID-Operator";
            Operator.Value = hidRecord.Operator;
            record.NestedItems.Add(Operator);

            ContextItem GinID = new ContextItem();
            GinID.Code = "JD-COT-HID-GinID";
            GinID.Value = hidRecord.GinID;
            record.NestedItems.Add(GinID);

            ContextItem ProducerID = new ContextItem();
            ProducerID.Code = "JD-COT-HID-ProducerID";
            ProducerID.Value = hidRecord.ProducerID;
            record.NestedItems.Add(ProducerID);

            ContextItem LocalTime = new ContextItem();
            LocalTime.Code = "JD-COT-HID-LocalTime";
            LocalTime.Value = hidRecord.LocalTime;
            record.NestedItems.Add(LocalTime);

            ContextItem FieldArea = new ContextItem();
            FieldArea.Code = "JD-COT-HID-FieldArea";
            FieldArea.Value = hidRecord.FieldArea;
            record.NestedItems.Add(FieldArea);

            ContextItem SeasonTotalModules = new ContextItem();
            SeasonTotalModules.Code = "JD-COT-HID-SeasonTotalModules";
            SeasonTotalModules.Value = hidRecord.SeasonTotalModules;
            record.NestedItems.Add(SeasonTotalModules);

            ContextItem LocalDate = new ContextItem();
            LocalDate.Code = "JD-COT-HID-LocalDate";
            LocalDate.Value = hidRecord.LocalDate;
            record.NestedItems.Add(LocalDate);

            ContextItem Comment = new ContextItem();
            Comment.Code = "JD-COT-HID-Comment";
            Comment.Value = hidRecord.Comment;
            record.NestedItems.Add(Comment);

            load.ContextItems.Add(record);

            return load;
        }
    }
}