using HiCore.EquipmentFramework.Config.Model;
using HiCore.EquipmentFramework.Config.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HiCore.EquipmentFramework.Config.Core
{
    public class EquipmentManager
    {
        private readonly JsonService _jsonService;

        public EquipmentInfoModel EquipmentInfo { get; set; }

        public ObservableCollection<VariableModel> Variables { get; }

        public ObservableCollection<AlarmModel> Alarms { get; }

        public ObservableCollection<EventModel> Events { get; }

        public ObservableCollection<CommandModel> Commands { get; }

        public ObservableCollection<RecipeModel> Recipes { get; }

        public EquipmentManager()
        {
            _jsonService = new JsonService();

            EquipmentInfo = new EquipmentInfoModel();

            Variables = new ObservableCollection<VariableModel>();
            Alarms = new ObservableCollection<AlarmModel>();
            Events = new ObservableCollection<EventModel>();
            Commands = new ObservableCollection<CommandModel>();
            Recipes = new ObservableCollection<RecipeModel>();
        }

        public void Clear()
        {
            EquipmentInfo = new EquipmentInfoModel();

            Variables.Clear();
            Alarms.Clear();
            Events.Clear();
            Commands.Clear();
            Recipes.Clear();
        }

        public EquipmentConfiguration ToConfiguration()
        {
            return new EquipmentConfiguration
            {
                EquipmentInfo = EquipmentInfo,

                Variables =
                    new List<VariableModel>(Variables),

                Alarms =
                    new List<AlarmModel>(Alarms),

                Events =
                    new List<EventModel>(Events),

                Commands =
                    new List<CommandModel>(Commands),

                Recipes =
                    new List<RecipeModel>(Recipes)
            };
        }

        public void FromConfiguration(
            EquipmentConfiguration configuration)
        {
            Clear();

            if (configuration == null)
                return;

            EquipmentInfo =
                configuration.EquipmentInfo ??
                new EquipmentInfoModel();

            foreach (var item in configuration.Variables)
                Variables.Add(item);

            foreach (var item in configuration.Alarms)
                Alarms.Add(item);

            foreach (var item in configuration.Events)
                Events.Add(item);

            foreach (var item in configuration.Commands)
                Commands.Add(item);

            foreach (var item in configuration.Recipes)
                Recipes.Add(item);
        }

        public bool Save(
            string filePath,
            out string error)
        {
            return _jsonService.Save(
                filePath,
                ToConfiguration(),
                out error);
        }

        public bool Load(
            string filePath,
            out string error)
        {
            EquipmentConfiguration config =
                _jsonService.Load<EquipmentConfiguration>(
                    filePath,
                    out error);

            if (!string.IsNullOrEmpty(error))
                return false;

            FromConfiguration(config);

            return true;
        }
    }
}