using HicoreEquipmentStudio.Model;
using HicoreEquipmentStudio.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace HicoreEquipmentStudio.Repository
{
    public class ConfigurationRepository
    {
        public ObservableCollection<AlarmModel> Alarms { get; private set; }

        public ObservableCollection<VariableModel> Variables { get; private set; }

        public ObservableCollection<EventModel> Events { get; private set; }

        public ObservableCollection<CommandModel> Commands { get; private set; }

        public ObservableCollection<RecipeModel> Recipes { get; private set; }

        public ConfigurationRepository()
        {
            Alarms = new ObservableCollection<AlarmModel>();
            Variables = new ObservableCollection<VariableModel>();
            Events = new ObservableCollection<EventModel>();
            Commands = new ObservableCollection<CommandModel>();
            Recipes = new ObservableCollection<RecipeModel>();
        }

        public EquipmentConfiguration ToConfiguration()
        {
            return new EquipmentConfiguration
            {
                Alarms = Alarms.ToList(),
                Variables = Variables.ToList(),
                Events = Events.ToList(),
                Commands = Commands.ToList(),
                Recipes = Recipes.ToList()
            };
        }

        public void LoadConfiguration(EquipmentConfiguration configuration)
        {
            Clear();

            if (configuration == null)
                return;

            if (configuration.Alarms != null)
            {
                foreach (var item in configuration.Alarms)
                {
                    Alarms.Add(item);
                }
            }

            if (configuration.Variables != null)
            {
                foreach (var item in configuration.Variables)
                {
                    Variables.Add(item);
                }
            }

            if (configuration.Events != null)
            {
                foreach (var item in configuration.Events)
                {
                    Events.Add(item);
                }
            }

            if (configuration.Commands != null)
            {
                foreach (var item in configuration.Commands)
                {
                    Commands.Add(item);
                }
            }

            if (configuration.Recipes != null)
            {
                foreach (var item in configuration.Recipes)
                {
                    Recipes.Add(item);
                }
            }
        }

        public void Clear()
        {
            Alarms.Clear();
            Variables.Clear();
            Events.Clear();
            Commands.Clear();
            Recipes.Clear();
        }
    }
}