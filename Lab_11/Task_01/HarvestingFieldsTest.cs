namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);

            FieldInfo[] fields = classType.GetFields(
                BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public);

            string command = Console.ReadLine();

            while (command != "HARVEST")
            {
                FieldInfo[] filteredFields;

                if (command == "private")
                {
                    filteredFields = GetPrivateFields(fields);
                }
                else if (command == "protected")
                {
                    filteredFields = GetProtectedFields(fields);
                }
                else if (command == "public")
                {
                    filteredFields = GetPublicFields(fields);
                }
                else if (command == "all")
                {
                    filteredFields = fields;
                }
                else
                {
                    filteredFields = new FieldInfo[0];
                }

                foreach (FieldInfo field in filteredFields)
                {
                    string accessModifier;

                    if (field.IsPublic)
                    {
                        accessModifier = "public";
                    }
                    else if (field.IsFamily)
                    {
                        accessModifier = "protected";
                    }
                    else
                    {
                        accessModifier = "private";
                    }

                    Console.WriteLine(accessModifier + " " + field.FieldType.Name + " " + field.Name);
                }

                command = Console.ReadLine();
            }
        }

        private static FieldInfo[] GetPrivateFields(FieldInfo[] fields)
        {
            var list = new System.Collections.Generic.List<FieldInfo>();

            foreach (FieldInfo f in fields)
            {
                if (f.IsPrivate)
                {
                    list.Add(f);
                }
            }

            return list.ToArray();
        }

        private static FieldInfo[] GetProtectedFields(FieldInfo[] fields)
        {
            var list = new System.Collections.Generic.List<FieldInfo>();

            foreach (FieldInfo f in fields)
            {
                if (f.IsFamily)
                {
                    list.Add(f);
                }
            }

            return list.ToArray();
        }

        private static FieldInfo[] GetPublicFields(FieldInfo[] fields)
        {
            var list = new System.Collections.Generic.List<FieldInfo>();

            foreach (FieldInfo f in fields)
            {
                if (f.IsPublic)
                {
                    list.Add(f);
                }
            }

            return list.ToArray();
        }
    }
}
