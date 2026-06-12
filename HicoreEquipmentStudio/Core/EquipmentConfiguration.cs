using HiCore.EquipmentFramework.Config.Model;
using HiCore.EquipmentFramework.Config.Models;
using System.Collections.Generic;

namespace HiCore.EquipmentFramework.Config.Core
{
    public class EquipmentConfiguration
    {
        public EquipmentInfoModel EquipmentInfo { get; set; }

        public List<VariableModel> Variables { get; set; }

        public List<AlarmModel> Alarms { get; set; }

        public List<EventModel> Events { get; set; }

        public List<CommandModel> Commands { get; set; }

        public List<RecipeModel> Recipes { get; set; }

        public EquipmentConfiguration()
        {
            EquipmentInfo = new EquipmentInfoModel();

            Variables = new List<VariableModel>();
            Alarms = new List<AlarmModel>();
            Events = new List<EventModel>();
            Commands = new List<CommandModel>();
            Recipes = new List<RecipeModel>();
        }
    }
}