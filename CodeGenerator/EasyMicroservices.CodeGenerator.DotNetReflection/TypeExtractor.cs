using EasyMicroservices.CodeGenerator.Core.GeneratorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EasyMicroservices.CodeGenerator.DotNetReflection
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeExtractor
    {
        Dictionary<Type, TypeGenInfo> ExtractedTypes { get; set; } = new Dictionary<Type, TypeGenInfo>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual TypeGenInfo Extract(Type type)
        {
            if (ExtractedTypes.TryGetValue(type, out TypeGenInfo typeGenInfo))
                return typeGenInfo;
            var result = new TypeGenInfo()
            {
                IsClass = type.IsClass,
                IsEnum = type.IsEnum,
                IsInterface = type.IsInterface,
                Name = type.Name,
                Namespace = type.Namespace,
                BaseType = Extract(type.BaseType),
                AssemblyFileName = type.Assembly.GetName().Name,
                GenericArguments = ExtractGenerics(type),
                Interfaces = ExtractInterfaces(type),
                Methods = ExtractMethods(type),
                Properties = ExtractProperties(type)
            };
            ExtractedTypes.Add(type, result);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual List<PropertyGenInfo> ExtractProperties(Type type)
        {
            return type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
            .Select(x => new PropertyGenInfo()
            {
                Name = x.Name,
                Type = Extract(x.PropertyType)
            }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual List<MethodGenInfo> ExtractMethods(Type type)
        {
            return type.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Select(x => new MethodGenInfo()
                {
                    Name = x.Name,
                    Parameters = ExtractParameters(x),
                    ReturnType = Extract(x.ReturnType)
                }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public virtual List<ParameterGenInfo> ExtractParameters(MethodInfo method)
        {
            return method.GetParameters()
                .Select(x => new ParameterGenInfo()
                {
                    Name = x.Name,
                    Type = Extract(x.ParameterType)
                }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual List<TypeGenInfo> ExtractGenerics(Type type)
        {
            return type.GetGenericArguments().Select(x => Extract(x)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual List<TypeGenInfo> ExtractInterfaces(Type type)
        {
            return type.GetInterfaces().Select(x => Extract(x)).ToList();
        }
    }
}
