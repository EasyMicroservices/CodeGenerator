using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace EasyMicroservices.CodeGenerator.Core.GeneratorModels
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeGenInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsClass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsInterface { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEnum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AssemblyFileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TypeGenInfo> GenericArguments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TypeGenInfo> Interfaces { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TypeGenInfo BaseType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PropertyGenInfo> Properties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MethodGenInfo> Methods { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Namespace}.{Name}";
        }
    }
}
