using EasyMicroservices.CodeGenerator.Core.GeneratorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EasyMicroservices.CodeGenerator.DotNetReflection
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeExtractor
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> DoNotFallowAssmebles { get; set; } = new List<string>();
        Dictionary<Type, TypeGenInfo> ExtractedTypes { get; set; } = new Dictionary<Type, TypeGenInfo>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual TypeGenInfo Extract(Type type)
        {
            if (type == null)
                return null;
            if (ExtractedTypes.TryGetValue(type, out TypeGenInfo typeGenInfo))
                return typeGenInfo;
            var assemblyName = type.Assembly.GetName().Name;
            bool haveToSkip = DoNotFallowAssmebles.Contains(assemblyName);
            var result = new TypeGenInfo();
            ExtractedTypes.Add(type, result);

            result.IsClass = type.IsClass;
            result.IsEnum = type.IsEnum;
            result.IsInterface = type.IsInterface;
            result.Name = type.Name;
            result.Namespace = type.Namespace;
            result.BaseType = haveToSkip ? null : Extract(type.BaseType);
            result.AssemblyFileName = assemblyName;
            result.GenericArguments = haveToSkip ? null : ExtractGenerics(type);
            result.Interfaces = haveToSkip ? null : ExtractInterfaces(type);
            result.Methods = haveToSkip ? null : ExtractMethods(type);
            result.Properties = haveToSkip ? null : ExtractProperties(type);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual List<PropertyGenInfo> ExtractProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(x => !x.IsDefined(typeof(CompilerGeneratedAttribute), false))
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
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(x => !x.IsDefined(typeof(CompilerGeneratedAttribute), false))
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
