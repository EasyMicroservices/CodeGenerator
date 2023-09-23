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
    public class AssemblyExtractor
    {
        /// <summary>
        /// These assembly will skip to generate everything from types
        /// </summary>
        public List<string> DoNotFallowAssmebles { get; set; } = new List<string>()
        {
            "System.Private.CoreLib"
        };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public virtual AssemblyGenInfo Extract(Assembly assembly)
        {
            var typeExtractor = new TypeExtractor()
            {
                DoNotFallowAssmebles = DoNotFallowAssmebles
            };
            var result = new AssemblyGenInfo()
            {
                FileName = assembly.GetName().Name,
                Types = assembly.GetTypes().Select(x => typeExtractor.Extract(x)).ToList()
            };

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual AssemblyGenInfo ExtractSingleType(Type type)
        {
            var assembly = type.Assembly;
            var typeExtractor = new TypeExtractor()
            {
                DoNotFallowAssmebles = DoNotFallowAssmebles
            };
            var result = new AssemblyGenInfo()
            {
                FileName = assembly.GetName().Name,
                Types = new List<TypeGenInfo>()
                {
                    typeExtractor.Extract(type)
                }
            };

            return result;
        }
    }
}
