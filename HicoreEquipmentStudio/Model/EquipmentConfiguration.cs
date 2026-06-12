using HicoreEquipmentStudio.Models;
using System.Collections.Generic;

namespace HicoreEquipmentStudio.Model
{
    public class EquipmentConfiguration
    {
        public List<AlarmModel> Alarms { get; set; }

        public List<VariableModel> Variables { get; set; }

        public List<EventModel> Events { get; set; }

        public List<CommandModel> Commands { get; set; }

        public List<RecipeModel> Recipes { get; set; }

        public EquipmentConfiguration()
        {
            Alarms = new List<AlarmModel>();
            Variables = new List<VariableModel>();
            Events = new List<EventModel>();
            Commands = new List<CommandModel>();
            Recipes = new List<RecipeModel>();
        }
    }
}