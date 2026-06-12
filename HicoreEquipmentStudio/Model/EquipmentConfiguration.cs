using HiCore.EquipmentFramework.Config.Models;
using System.Collections.Generic;

namespace HiCore.EquipmentFramework.Config.Model
{
    public class EquipmentConfiguration
    {
        public EquipmentInfoModel EquipmentInfo { get; set; }

        public List<AlarmModel> Alarms { get; set; }

        public List<VariableModel> Variables { get; set; }

        public List<EventModel> Events { get; set; }

        public List<CommandModel> Commands { get; set; }

        public List<RecipeModel> Recipes { get; set; }

        public EquipmentConfiguration()
        {
            EquipmentInfo = new EquipmentInfoModel();

            Alarms = new List<AlarmModel>();
            Variables = new List<VariableModel>();
            Events = new List<EventModel>();
            Commands = new List<CommandModel>();
            Recipes = new List<RecipeModel>();
        }
    }
}