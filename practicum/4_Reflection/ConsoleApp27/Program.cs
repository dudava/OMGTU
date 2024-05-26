using System;
using System.Reflection;


class Program
{
    static string GetParametersString(MethodBase method)
    {
        var parameters = method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}");
        return String.Join( ", ", parameters );
    }

    static Object CustomFunc(String str, Object[] obj)
    {
        return true;
    }

    static void Main(string[] args)
    {
        Assembly a = Assembly.Load("core");
        foreach(var type in a.GetTypes())
        {
            string class_or_interface = type.IsInterface ? "interface " : "class ";
            Console.WriteLine($"{class_or_interface}{type.FullName} {{");
            Console.WriteLine("Fields:");
            foreach(var field in type.GetFields())
            {
                string public_or_not = field.IsPublic ? "public" : "";
                Console.WriteLine($"\t {public_or_not} {field.FieldType.Name} {field.Name}");
            }
            Console.WriteLine("Constructors: ");
            foreach (var constructor in type.GetConstructors())
            {
                
                Console.WriteLine($"\t {constructor}");
            }
            Console.WriteLine("Methods: ");
            foreach (var method in type.GetMethods())
            {
                string public_or_not = method.IsPublic ? "public " : "";
                string static_or_not = method.IsStatic ? "static " : "";
                var parameters = method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}");
                Console.WriteLine($"\t {public_or_not}{static_or_not}{method.ReturnParameter} {method.Name} ({String.Join(", ", parameters)}) {{}}");
            }
            Console.WriteLine("}");
        }
        var setupType = a.GetType("HWdTech.IoC+SetupCommand");
        var setupConstructor = setupType.GetConstructors()[0];
        var setupInstanse = setupConstructor.Invoke(new Object[] { CustomFunc });

        var executeMethod = setupType.GetMethod("Execute");
        var getHashCodeMethod = setupType.GetMethod("GetHashCode");
        var equalsMethod = setupType.GetMethod("Equals");
        var toStringMethod = setupType.GetMethod("ToString");

        executeMethod.Invoke(setupInstanse, null); // some must be going on
        
        Console.WriteLine(getHashCodeMethod.Invoke(setupInstanse, null)); // some hash code
        Console.WriteLine(equalsMethod.Invoke(setupInstanse, new object[] { setupInstanse })); // True
        Console.WriteLine(toStringMethod.Invoke(setupInstanse, null)); // HWdTech.IoC+SetupCommand

        var nullableAttributeType = a.GetType("System.Runtime.CompilerServices.NullableAttribute");
        var nulConstructor = nullableAttributeType.GetConstructor(
            new Type[] { typeof(Byte[]) }
        );
        var nulAttrs = nulConstructor.Invoke(new object[] { new Byte[] {123, 255, 0} });
        var nulFlagsField = nullableAttributeType.GetField("NullableFlags");
        foreach(Byte b in (Byte[])nulFlagsField.GetValue(nulAttrs))
        {
            Console.WriteLine(b.ToString());
        }
    }
}