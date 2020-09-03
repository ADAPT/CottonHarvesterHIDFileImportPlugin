using AgGateway.ADAPT.ApplicationDataModel.ADM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace CottonHarvesterHIDFileImportPlugin
{
    public class Plugin : IPlugin
    {
        string IPlugin.Name => "John Deere HID ADAPT Plugin";
        string IPlugin.Version => "1.0";
        string IPlugin.Owner => "AgGateway";
        public IList<IError> Errors => throw new NotImplementedException();

        public IList<ApplicationDataModel> RunPlugin()
        {
            //A plugin publisher can choose to create one or multiple application data models as appropriate for the data
            IList<ApplicationDataModel> admList = new List<ApplicationDataModel>();
            ApplicationDataModel adm = new ApplicationDataModel();            
            string dataPath = @"C:\Projects\OAGi\ADAPT\JD";

            //Find any data files in the defined path
            string[] myDataFiles = Directory.GetFiles(dataPath, "HIDC2117998B - Customized.csv", SearchOption.AllDirectories);
            if (myDataFiles.Any())
            {
                adm.Catalog = new Catalog() { Description = $"ADAPT data transformation of Publisher data {DateTime.Now.ToShortDateString()} {dataPath}" };

                foreach (string myDataFile in myDataFiles)
                {
                    //Import each file
                    PublisherDataModel.Data data = new PublisherDataModel.Data();
                    data.HIDData = PublisherDataModel.FlatFileHelper.ConvertFlatFileToModel(File.ReadAllText(myDataFile, System.Text.Encoding.Default));
                    PublisherDataModel.FlatFileHelper.ConvertFlatFileToCustomModel(File.ReadAllText(myDataFile, System.Text.Encoding.Default), data);
                    DataMappers.DataMapper.MapData(data, adm);
                }

                admList.Add(adm);
            }

            return admList;
        }

        IList<ApplicationDataModel> IPlugin.Import(string dataPath, Properties properties)
        {
            IList<ApplicationDataModel> models = new List<ApplicationDataModel>();

            //Find any data files in the defined path
            string[] myDataFiles = Directory.GetFiles(dataPath, "HIDC2117998B - Customized.csv", SearchOption.AllDirectories);
            if (myDataFiles.Any())
            {
                //A plugin publisher can choose to create one or multiple application data models as appropriate for the data
                ApplicationDataModel adm = new ApplicationDataModel();
                adm.Catalog = new Catalog() { Description = $"ADAPT data transformation of Publisher data {DateTime.Now.ToShortDateString()} {dataPath}" };
                //var loads = new List<AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load>();
                //models.Add(adm);

                foreach (string myDataFile in myDataFiles)
                {
                    //Import each file
                    PublisherDataModel.Data data = new PublisherDataModel.Data();
                    data.HIDData = PublisherDataModel.FlatFileHelper.ConvertFlatFileToModel(File.ReadAllText(myDataFile, System.Text.Encoding.Default));
                    DataMappers.DataMapper.MapData(data, adm);
                }

                models.Add(adm);
            }

            return models;           
        }

        /// <summary>
        /// Export works just like import, except the Mappers should work in the reverse direction
        /// </summary>
        /// <param name="dataModel">The ADAPT adm to export to the plugin's format</param>
        /// <param name="exportPath">Path to publish to</param>
        /// <param name="properties">Any proprietary values the user may pass in customizing the export</param>
        void IPlugin.Export(ApplicationDataModel dataModel, string exportPath, Properties properties)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// GetProperties is an optional feature to return 
        /// basic key/value information about a data set without
        /// completing the complete transformation
        /// </summary>
        /// <param name="dataPath"></param>
        /// <returns></returns>
        Properties IPlugin.GetProperties(string dataPath)
        {
            
            throw new NotImplementedException();
        }


        /// <summary>
        ///Initialize is an optional feature if a publisher wishes
        ///to secure use of the plugin with specific arguments  
        ///or otherwise customize the behavior with a particular set of parameters
        /// <param name="args"></param>
        void IPlugin.Initialize(string args)
        {

        }

        /// <summary>
        /// Determines whether the folder contains data that this plugin can import
        /// </summary>
        /// <param name="dataPath"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        bool IPlugin.IsDataCardSupported(string dataPath, Properties properties)
        {
            //In this simple example, we are simply looking for the myjson extension to identify data in our format
            if (Directory.GetFiles(dataPath, "*.csv", SearchOption.AllDirectories).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Examines the contents of a data file for formatting errors
        /// </summary>
        /// <param name="dataPath"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        IList<IError> IPlugin.ValidateDataOnCard(string dataPath, Properties properties)
        {
            throw new NotImplementedException();
        }
    }
}