using Starwars.Data.Models.Character;
using System.Linq;

namespace Starwars.Data.Extensions.Character
{
    public static class PopulateCharacter
    {
        //Written 4fun, in normal situation probably i would use automapper
        public static void PopulateOnModel(this CharacterModel characterModel, CharacterModel changedModel)
        {
            foreach (var property in characterModel.GetType().GetProperties())
            {
                if (property.GetCustomAttributes(false).Any(attribute => attribute.GetType().Name.Equals("NotPopulate")))
                {
                    continue;
                }

                var changedModelProperties = changedModel.GetType().GetProperties();

                var changedProperty = changedModelProperties.FirstOrDefault(x => x.Name.Equals(property.Name) && x.PropertyType == property.PropertyType);

                if (changedProperty == null) continue;

                var changedPropertyValue = changedProperty.GetValue(changedModel);

                property.SetValue(characterModel, changedPropertyValue);
            }
        }
    }
}
