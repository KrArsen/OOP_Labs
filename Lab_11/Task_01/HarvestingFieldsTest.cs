namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                FieldInfo[] filteredFields = command switch
                {
                    "private" => fields.Where(f => f.IsPrivate).ToArray(),
                    "protected" => fields.Where(f => f.IsFamily).ToArray(),
                    "public" => fields.Where(f => f.IsPublic).ToArray(),
                    "all" => fields,
                    _ => Array.Empty<FieldInfo>()
                };

                foreach (var field in filteredFields)
                {
                    string accessModifier = field.IsPublic
                        ? "public"
                        : field.IsFamily
                            ? "protected"
                            : "private";

                    Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}