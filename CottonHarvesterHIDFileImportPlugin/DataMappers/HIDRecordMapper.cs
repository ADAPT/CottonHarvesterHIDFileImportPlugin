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

            //Obs Lat = new Obs();
            //Lat.OMCode = "JD-COT-HID-Lat";
            //Lat.Value = hidRecord.Lat;
            //Lat.GrowerId = obsCollection.GrowerId;
            //obsCollection.ObsIds.Add(Lat.Id.ReferenceId);
            //_obs.Add(Lat);

            //Obs Lon = new Obs();
            //Lon.OMCode = "JD-COT-HID-Lon";
            //Lon.Value = hidRecord.Lat;
            //Lon.GrowerId = obsCollection.GrowerId;
            //obsCollection.ObsIds.Add(Lon.Id.ReferenceId);
            //_obs.Add(Lon);

            //Obs Variety = new Obs();
            //Variety.OMCode = "CC_FOI_CROP_VARIETY_NAME";
            //Variety.Value = hidRecord.Variety;
            //Variety.GrowerId = obsCollection.GrowerId;
            //obsCollection.ObsIds.Add(Variety.Id.ReferenceId);
            //_obs.Add(Variety);

            //Obs Moisture = new Obs();
            //Moisture.OMCode = "A_YLD_MOISTURE";
            //Moisture.Value = hidRecord.Moisture;
            //Moisture.GrowerId = obsCollection.GrowerId;
            //obsCollection.ObsIds.Add(Moisture.Id.ReferenceId);
            //_obs.Add(Moisture);

            //Obs Diameter = new Obs();
            //Diameter.OMCode = "A_YLD_MODULE_DIAMETER";
            //Diameter.Value = hidRecord.Diameter;
            //Diameter.GrowerId = obsCollection.GrowerId;
            //obsCollection.ObsIds.Add(Diameter.Id.ReferenceId);
            //_obs.Add(Diameter);

            //Obs Weight = new Obs();
            //Weight.OMCode = "A_YLD_WMAS_TOTAL";
            //Weight.Value = hidRecord.Weight;
            //Weight.GrowerId = obsCollection.GrowerId;
            //obsCollection.ObsIds.Add(Weight.Id.ReferenceId);
            //_obs.Add(Weight);

            //Obs DropLat = new Obs();
            //DropLat.OMCode = "JD-COT-HID-DropLat";
            //DropLat.Value = hidRecord.DropLat;
            //DropLat.GrowerId = obsCollection.GrowerId;
            //obsCollection.ObsIds.Add(DropLat.Id.ReferenceId);
            //_obs.Add(DropLat);

            //Obs DropLon = new Obs();
            //DropLon.OMCode = "JD-COT-HID-DropLon";
            //DropLon.Value = hidRecord.DropLon;
            //DropLat.GrowerId = obsCollection.GrowerId;
            //obsCollection.ObsIds.Add(DropLon.Id.ReferenceId);
            //_obs.Add(DropLon);

            //Obs FieldTotal = new Obs();
            //FieldTotal.OMCode = "JD-COT-HID-FieldTotal";
            //FieldTotal.Value = hidRecord.FieldTotal;
            //FieldTotal.GrowerId = obsCollection.GrowerId;
            //obsCollection.ObsIds.Add(FieldTotal.Id.ReferenceId);
            //_obs.Add(FieldTotal);

            //Obs IncrementalArea = new Obs();
            //IncrementalArea.OMCode = "JD-COT-HID-IncrementalArea";
            //IncrementalArea.Value = hidRecord.IncrementalArea;
            //IncrementalArea.GrowerId = obsCollection.GrowerId;
            //obsCollection.ObsIds.Add(IncrementalArea.Id.ReferenceId);
            //_obs.Add(IncrementalArea);

            return obsCollection;
        }

        public static AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load MapHIDRecord(PublisherDataModel.HIDRecord hidRecord, AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load load)
        {
            //Transform the native object into the ADAPT object
            ContextItem record = new ContextItem();
            record.Code = "JD_1GOSG_HID";

            ContextItem ModuleID = new ContextItem();
            ModuleID.Code = "M_JD_1GOSG_HID_MODULE_ID";
            ModuleID.Value = hidRecord.ModuleID;
            record.NestedItems.Add(ModuleID);

            ContextItem ModuleSN = new ContextItem();
            ModuleSN.Code = "M_JD_1GOSG_HID_MODULE_SN";
            ModuleSN.Value = hidRecord.ModuleSN;
            record.NestedItems.Add(ModuleSN);

            ContextItem GMTDate = new ContextItem();
            GMTDate.Code = "M_JD_1GOSG_HID_GMT_DATE";
            GMTDate.Value = hidRecord.GMTDate;
            record.NestedItems.Add(GMTDate);

            ContextItem GMTTime = new ContextItem();
            GMTTime.Code = "M_JD_1GOSG_HID_GMT_TIME";
            GMTTime.Value = hidRecord.GMTTime;
            record.NestedItems.Add(GMTTime);

            //ContextItem Client = new ContextItem();
            //Client.Code = "M_JD_1GOSG_HID_CLIENT";
            //Client.Value = hidRecord.Client;
            //record.NestedItems.Add(Client);

            //ContextItem Farm = new ContextItem();
            //Farm.Code = "M_JD_1GOSG_HID_FARM";
            //Farm.Value = hidRecord.Farm;
            //record.NestedItems.Add(Farm);

            //ContextItem Field = new ContextItem();
            //Field.Code = "M_JD_1GOSG_HID_FIELD";
            //Field.Value = hidRecord.Field;
            //record.NestedItems.Add(Field);

            ContextItem MachinePIN = new ContextItem();
            MachinePIN.Code = "M_JD_1GOSG_HID_MACHINE_PIN";
            MachinePIN.Value = hidRecord.MachinePIN;
            record.NestedItems.Add(MachinePIN);

            ContextItem Operator = new ContextItem();
            Operator.Code = "M_JD_1GOSG_HID_OPERATOR";
            Operator.Value = hidRecord.Operator;
            record.NestedItems.Add(Operator);

            ContextItem GinID = new ContextItem();
            GinID.Code = "M_JD_1GOSG_HID_GIN_ID";
            GinID.Value = hidRecord.GinID;
            record.NestedItems.Add(GinID);

            ContextItem ProducerID = new ContextItem();
            ProducerID.Code = "M_JD_1GOSG_HID_PRODUCER_ID";
            ProducerID.Value = hidRecord.ProducerID;
            record.NestedItems.Add(ProducerID);

            ContextItem LocalTime = new ContextItem();
            LocalTime.Code = "M_JD_1GOSG_HID_LOCAL_TIME";
            LocalTime.Value = hidRecord.LocalTime;
            record.NestedItems.Add(LocalTime);

            ContextItem FieldArea = new ContextItem();
            FieldArea.Code = "M_JD_1GOSG_HID_FIELD_AREA";
            FieldArea.Value = hidRecord.FieldArea;
            record.NestedItems.Add(FieldArea);

            ContextItem SeasonTotalModules = new ContextItem();
            SeasonTotalModules.Code = "M_JD_1GOSG_HID_SEASON_TOTAL_MODULES";
            SeasonTotalModules.Value = hidRecord.SeasonTotalModules;
            record.NestedItems.Add(SeasonTotalModules);

            ContextItem LocalDate = new ContextItem();
            LocalDate.Code = "M_JD_1GOSG_HID_LOCAL_DATE";
            LocalDate.Value = hidRecord.LocalDate;
            record.NestedItems.Add(LocalDate);

            ContextItem Comment = new ContextItem();
            Comment.Code = "M_JD_1GOSG_HID_COMMENT";
            Comment.Value = hidRecord.Comment;
            record.NestedItems.Add(Comment);

            ContextItem TagCount = new ContextItem();
            TagCount.Code = "M_JD_1GOSG_HID_TAG_COUNT";
            TagCount.Value = hidRecord.TagCount;
            record.NestedItems.Add(TagCount);

            load.ContextItems.Add(record);

            return load;
        }
    }
}