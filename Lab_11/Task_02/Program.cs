namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type blackBoxType = typeof(BlackBoxInteger);

            
            object blackBoxInstance = Activator.CreateInstance(blackBoxType, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split('_');
                string methodName = parts[0];
                int value = int.Parse(parts[1]);

            
                MethodInfo method = blackBoxType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
                
            
                method.Invoke(blackBoxInstance, new object[] { value });

            
                FieldInfo innerValueField = blackBoxType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
                int currentValue = (int)innerValueField.GetValue(blackBoxInstance);

            
                Console.WriteLine(currentValue);
            }
        }
    }
}