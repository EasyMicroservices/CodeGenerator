using EasyMicroservices.CodeGenerator.Core.GeneratorModels;
using EasyMicroservices.CodeGenerator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyMicroservices.CodeGenerator.DotNetReflection
{
    /// <summary>
    /// 
    /// </summary>
    public class DotNetToolConverter : IToolConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public List<AssemblyGenInfo> Convert<T>(T data)
        {
            if (data is Type type)
            {
                return new List<AssemblyGenInfo>()
                {
                    new AssemblyExtractor().ExtractSingleType(type)
                };
            }
            else if (data is Assembly assembly)
            {
                return new List<AssemblyGenInfo>()
                {
                    new AssemblyExtractor().Extract(assembly)
                };
            }
            throw new NotSupportedException($"Type {data.GetType().FullName} not supported, Please send me Type or Assembly!");
        }
    }
}
