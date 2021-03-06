using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fields)
    {
        var classType = Type.GetType(className);
        var fieldsInfo = classType
                        .GetFields(BindingFlags.Instance |
                                   BindingFlags.Static |
                                   BindingFlags.Public |
                                   BindingFlags.NonPublic)
                        .Where(f => fields.Contains(f.Name));
        var classInstance = Activator.CreateInstance(classType, new object[] { });

        var builder = new StringBuilder();
        builder.AppendLine($"Class under investigation: {classType}");

        foreach (var field in fieldsInfo)
        {
            builder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return builder.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var classType = Type.GetType(className);

        var builder = new StringBuilder();
        // fields
        classType
             .GetFields(BindingFlags.Public | BindingFlags.Instance)
             .ToList()
             .ForEach(f => builder.AppendLine($"{f.Name} must be private!"));

        var methods = classType
            .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        // getters
        methods
            .Where(m => m.Name.StartsWith("get") && !m.IsPublic)
            .ToList()
            .ForEach(m => builder.AppendLine($"{m.Name} have to be public!"));
        // setters
        methods
            .Where(m => m.Name.StartsWith("set") && !m.IsPrivate)
            .ToList()
            .ForEach(m => builder.AppendLine($"{m.Name} have to be private!"));

        return builder.ToString().Trim();
    }
}