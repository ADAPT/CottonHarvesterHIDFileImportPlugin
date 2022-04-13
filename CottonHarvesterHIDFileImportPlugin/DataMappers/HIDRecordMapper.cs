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
            //Create the phenomenon information
            string GMTDate = hidRecord.GMTDate;
            string GMTTime = hidRecord.GMTTime;
            DateTime dt = DateTime.Parse(GMTDate + " " + GMTTime);
            TimeScope phenTime = new TimeScope();
            phenTime.DateContext = DateContextEnum.PhenomenonTime;
            phenTime.TimeStamp1 = dt;
            obsCollection.TimeScopes.Add(phenTime);

            //Create the spacial extent
            AgGateway.ADAPT.ApplicationDataModel.Shapes.Point point = new AgGateway.ADAPT.ApplicationDataModel.Shapes.Point();
            point.X = Convert.ToDouble(hidRecord.Lon);
            point.Y = Convert.ToDouble(hidRecord.Lat);
            obsCollection.SpatialExtent = point;

            //First associate the grower with the ObservationCollection
            bool containsGrower = false;
            Grower grower = null;
            foreach (Grower currentGrower in adm.Catalog.Growers)
            {
                if(hidRecord.Client != null)
                { 
                    if (currentGrower.Name.Trim() == hidRecord.Client.Trim())
                    {
                        containsGrower = true;
                        grower = currentGrower;
                        break;
                    }
                }
            }

            if (containsGrower)
            {
                int? growerID = grower.Id.ReferenceId;
                growerID = growerID ?? default(int);
                obsCollection.GrowerId = growerID;
            }

            ObsCodeComponent crop = new ObsCodeComponent();
            crop.ComponentCode = "CC_FOI_CROP";
            crop.ComponentType = "FEATURE_OF_INTEREST";
            crop.Selector = "CROP";
            if (hidRecord.Variety == "1") { crop.Value = "GOSHI"; } else { crop.Value = "GOSBA"; }
            crop.Value = crop.Value;
            crop.ValueType = OMCodeComponentValueTypeEnum.String;
            crop.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(crop);

            ObsCodeComponent ccvariety = new ObsCodeComponent();
            ccvariety.ComponentCode = "CC_FOI_CROP_VARIETY_NAME";
            ccvariety.ComponentType = "FEATURE_OF_INTEREST";
            ccvariety.Selector = "CROP_VARIETY_NAME";
            ccvariety.Description = "The variety of cotton crop being harvested.";
            ccvariety.Value = hidRecord.Variety;
            ccvariety.ValueType = OMCodeComponentValueTypeEnum.String;
            ccvariety.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(ccvariety);

            ObsCodeComponent client = new ObsCodeComponent();
            client.ComponentCode = "CC_PARAM_GROWER_NAME";
            client.ComponentType = "PARAMETER";
            client.Selector = "GROWER_NAME";
            client.Description = "Client who’s field is being harvested.";
            client.Value = hidRecord.Client;
            client.ValueType = OMCodeComponentValueTypeEnum.String;
            client.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(client);

            ObsCodeComponent farm = new ObsCodeComponent();
            farm.ComponentCode = "CC_FOI_FARM_NAME";
            farm.ComponentType = "FEATURE_OF_INTEREST";
            farm.Selector = "FARM_NAME";
            farm.Description = "Farm being harvested.";
            farm.Value = hidRecord.Farm;
            farm.ValueType = OMCodeComponentValueTypeEnum.String;
            farm.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(farm);

            ObsCodeComponent field = new ObsCodeComponent();
            field.ComponentCode = "CC_FOI_FIELD_NAME";
            field.ComponentType = "FEATURE_OF_INTEREST";
            field.Selector = "FIELD_NAME";
            field.Description = "Farm being harvested.";
            field.Value = hidRecord.Field;
            field.ValueType = OMCodeComponentValueTypeEnum.String;
            field.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(field);

            Obs obsMoisture = new Obs();
            obsMoisture.TimeScopes.Add(phenTime);
            obsMoisture.SpatialExtent = point;
            obsMoisture.OMCode = "A_YLD_MOISTURE";
            obsMoisture.Value = hidRecord.Moisture;
            obsMoisture.UoMCode = "prcnt";
            obsCollection.ObsIds.Add(obsMoisture.Id.ReferenceId);
            _obs.Add(obsMoisture);

            Obs ccdiameter = new Obs();
            ccdiameter.TimeScopes.Add(phenTime);
            ccdiameter.SpatialExtent = point;
            ccdiameter.OMCode = "A_YLD_1GOSG_MODULE_DIAMETER";
            ccdiameter.Value = hidRecord.Diameter;
            ccdiameter.UoMCode = "cm";
            obsCollection.ObsIds.Add(ccdiameter.Id.ReferenceId);
            _obs.Add(ccdiameter);

            Obs ccweight = new Obs();
            ccweight.TimeScopes.Add(phenTime);
            ccweight.SpatialExtent = point;
            ccweight.OMCode = "A_YLD_WMAS_TOTAL";
            ccweight.Value = hidRecord.Weight;
            ccweight.UoMCode = "kg";
            obsCollection.ObsIds.Add(ccweight.Id.ReferenceId);
            _obs.Add(ccweight);

            Obs perBale = new Obs();
            perBale.TimeScopes.Add(phenTime);
            perBale.SpatialExtent = point;
            perBale.OMCode = "A_YLD_AREA_PER_BALE";
            perBale.Value = hidRecord.IncrementalArea;
            perBale.UoMCode = "ha";
            obsCollection.ObsIds.Add(perBale.Id.ReferenceId);
            _obs.Add(perBale);

            Obs dropLocation = new Obs();
            dropLocation.TimeScopes.Add(phenTime);
            dropLocation.SpatialExtent = point;
            dropLocation.OMCode = "M_1GOSG_MODULE_DROP";
            dropLocation.Value = point.ToString();
            dropLocation.UoMCode = "";
            obsCollection.ObsIds.Add(dropLocation.Id.ReferenceId);
            _obs.Add(dropLocation);

            ObsCodeComponent dropLon = new ObsCodeComponent();
            dropLon.ComponentCode = "CC_FOI_DROP_LONGITUDE";
            dropLon.ComponentType = "FEATURE_OF_INTEREST";
            dropLon.Selector = "FOI_DROP_LONGITUDE";
            dropLon.Description = "The longitude position of when the bale was dropped.";
            dropLon.Value = hidRecord.Variety;
            dropLon.ValueType = OMCodeComponentValueTypeEnum.String;
            dropLon.ValueUoMCode = "";
            obsCollection.CodeComponents.Add(dropLon);

            return obsCollection;
        }

        public static AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load MapHIDRecord(PublisherDataModel.HIDRecord hidRecord, AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load load)
        {
            //Transform the native object into the ADAPT object
            ContextItem record = new ContextItem();
            record.Code = "JD_1GOSG_HID";

            ContextItem ModuleID = new ContextItem();
            ModuleID.Code = "M_JD_1GOSG_MODULE_ID";
            ModuleID.Value = hidRecord.ModuleID;
            record.NestedItems.Add(ModuleID);

            ContextItem ModuleSN = new ContextItem();
            ModuleSN.Code = "M_JD_1GOSG_MODULE_SN";
            ModuleSN.Value = hidRecord.ModuleSN;
            record.NestedItems.Add(ModuleSN);

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

            ContextItem FieldArea = new ContextItem();
            FieldArea.Code = "M_1GOSG_MODULE_CUMULATIVE_FIELD_AREA";
            FieldArea.Value = hidRecord.FieldArea;
            record.NestedItems.Add(FieldArea);

            ContextItem SeasonTotalModules = new ContextItem();
            SeasonTotalModules.Code = "M_1GOSG_SEASON_TOTAL_MODULES";
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