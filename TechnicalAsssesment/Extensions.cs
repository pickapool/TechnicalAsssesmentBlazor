using Newtonsoft.Json;
using System.ComponentModel;
using System.Reflection;

namespace TechnicalAsssesment
{
    public static class Extensions
    {
        public static T Clone<T>(this T source)
        {
            if (ReferenceEquals(source, null)) return default;
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
        }
        public static string GetEnumDescription(Enum value)
        {
            var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            var descriptionAttribute =
                enumMember == null
                    ? default(DescriptionAttribute)
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return
                descriptionAttribute == null
                    ? value.ToString()
                    : descriptionAttribute.Description;
        }

    }
}
