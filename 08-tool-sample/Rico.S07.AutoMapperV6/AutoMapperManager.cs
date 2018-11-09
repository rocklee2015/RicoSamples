using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Rico.S07.AutoMapperV6
{
    public class AutoMapperManager
    {
        private static readonly IDictionary<string, Assembly[]> AssembliesesDict = new Dictionary<string, Assembly[]>();
        public static void CreateMap()
        {
            Type[] sourceTypes = FindTypes();

            if (sourceTypes.Length == 0)
            {
                return;
            }
            Mapper.Initialize(config =>
            {
                foreach (Type sourceType in sourceTypes)
                {
                    foreach (Type targetType in sourceTypes)
                    {
                        if (sourceType.Name == targetType.Name + "InputDto")
                        {
                            config.CreateMap(sourceType, targetType);
                            break;
                        }
                        if (sourceType.Name + "OutputDto" == targetType.Name)
                        {
                            config.CreateMap(sourceType, targetType);
                            break;
                        }
                    }
                }
            });


        }


        public static void Reset()
        {
            Mapper.Reset();
        }

        private static Assembly[] FindAllAssembly()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (AssembliesesDict.ContainsKey(path))
            {
                return AssembliesesDict[path];
            }
            string[] files = Directory.GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly)
                .Concat(Directory.GetFiles(path, "*.exe", SearchOption.TopDirectoryOnly))
                .ToArray();
            Assembly[] assemblies = files.Select(Assembly.LoadFrom).Distinct().ToArray();
            AssembliesesDict.Add(path, assemblies);
            return assemblies;
        }



        private static Type[] FindTypes()
        {
            Assembly[] assemblies = FindAllAssembly();
            return assemblies.SelectMany(assembly =>
                assembly.GetTypes().Where(type =>
                    (typeof(IInputDto).IsAssignableFrom(type) && !type.IsAbstract) ||
                    (typeof(IOutputDto).IsAssignableFrom(type) && !type.IsAbstract)
                    ))
                .Distinct().ToArray();
        }
    }
}
