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

            ObsCodeComponent lat = new ObsCodeComponent();
            lat.ComponentCode = "CC_FOI_LATITUDE";
            lat.ComponentType = "FEATURE_OF_INTEREST";
            lat.Selector = "FOI_LATITUDE";
            lat.Description = "The latitude position of when the bale was created.";
            lat.Value = hidRecord.Variety;
            lat.ValueType = OMCodeComponentValueTypeEnum.String;
            lat.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(lat);

            ObsCodeComponent lon = new ObsCodeComponent();
            lon.ComponentCode = "CC_FOI_LONGITUDE";
            lon.Selector = "FOI_DROP_LATITUDE";
            lon.ComponentType = "FEATURE_OF_INTEREST";
            lon.Selector = "FOI_LONGITUDE";
            lon.Description = "The longitude position of when the bale was created.";
            lon.Value = hidRecord.Variety;
            lon.ValueType = OMCodeComponentValueTypeEnum.String;
            lon.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(lon);

            ObsCodeComponent ccvariety = new ObsCodeComponent();
            ccvariety.ComponentCode = "CC_FOI_CROP_VARIETY_NAME";
            ccvariety.ComponentType = "FEATURE_OF_INTEREST";
            ccvariety.Selector = "CROP_VARIETY_NAME";
            ccvariety.Description = "The variety of cotton crop being harvested.";
            ccvariety.Value = hidRecord.Variety;
            ccvariety.ValueType = OMCodeComponentValueTypeEnum.String;
            ccvariety.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(ccvariety);

            ObsCodeComponent ccmoisture = new ObsCodeComponent();
            ccmoisture.ComponentCode = "A_YLD_MOISTURE";
            ccmoisture.ComponentType = "OBSERVED_PROPERTY";
            ccmoisture.Selector = "YLD_MOISTURE";
            ccmoisture.Description = "The moisture level of cotton crop being harvested.";
            ccmoisture.Value = hidRecord.Moisture;
            ccmoisture.ValueType = OMCodeComponentValueTypeEnum.Double;
            ccmoisture.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(ccmoisture);

            ObsCodeComponent ccdiameter = new ObsCodeComponent();
            ccdiameter.ComponentCode = "A_YLD_MODULE_DIAMETER";
            ccdiameter.ComponentType = "OBSERVED_PROPERTY";
            ccdiameter.Selector = "YLD_MODULE_DIAMETER";
            ccdiameter.Description = "The diameter of the module of cotton crop being harvested.";
            ccdiameter.Value = hidRecord.Diameter;
            ccdiameter.ValueType = OMCodeComponentValueTypeEnum.Double;
            ccdiameter.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(ccdiameter);

            ObsCodeComponent ccweight = new ObsCodeComponent();
            ccweight.ComponentCode = "A_YLD_WMAS_TOTAL";
            ccweight.ComponentType = "OBSERVED_PROPERTY";
            ccweight.Selector = "YLD_WMAS_TOTAL";
            ccweight.Description = "The weight of the module of cotton crop being harvested.";
            ccweight.Value = hidRecord.Weight;
            ccweight.ValueType = OMCodeComponentValueTypeEnum.Double;
            ccweight.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(ccweight);

            ObsCodeComponent dropLat = new ObsCodeComponent();
            dropLat.ComponentCode = "CC_FOI_DROP_LATITUDE";
            dropLat.ComponentType = "FEATURE_OF_INTEREST";
            dropLat.Selector = "FOI_DROP_LATITUDE";
            dropLat.Description = "The latitude position of when the bale was dropped.";
            dropLat.Value = hidRecord.Variety;
            dropLat.ValueType = OMCodeComponentValueTypeEnum.String;
            dropLat.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(dropLat);

            ObsCodeComponent dropLon = new ObsCodeComponent();
            dropLon.ComponentCode = "CC_FOI_DROP_LONGITUDE";
            dropLon.ComponentType = "FEATURE_OF_INTEREST";
            dropLon.Selector = "FOI_DROP_LONGITUDE";
            dropLon.Description = "The longitude position of when the bale was dropped.";
            dropLon.Value = hidRecord.Variety;
            dropLon.ValueType = OMCodeComponentValueTypeEnum.String;
            dropLon.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(dropLon);

            ObsCodeComponent cctotal = new ObsCodeComponent();
            cctotal.ComponentCode = "A_YLD_FieldTotal";
            cctotal.ComponentType = "OBSERVED_PROPERTY";
            cctotal.Selector = "YLD_FieldTotal";
            cctotal.Description = "The field total of the modules of cotton crop being harvested.";
            cctotal.Value = hidRecord.FieldTotal;
            cctotal.ValueType = OMCodeComponentValueTypeEnum.Double;
            cctotal.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(cctotal);

            ObsCodeComponent ccincrementalarea = new ObsCodeComponent();
            ccincrementalarea.ComponentCode = "A_YLD_AREA_PER_BALE";
            ccincrementalarea.ComponentType = "OBSERVED_PROPERTY"; //???
            ccincrementalarea.Selector = "YLD_IncrementalArea";
            ccincrementalarea.Description = "The incremental area of the cotton crop being harvested.";
            ccincrementalarea.Value = hidRecord.IncrementalArea;
            ccincrementalarea.ValueType = OMCodeComponentValueTypeEnum.Double;
            ccincrementalarea.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(ccincrementalarea);

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