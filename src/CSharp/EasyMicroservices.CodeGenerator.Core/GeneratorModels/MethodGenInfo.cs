using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace EasyMicroservices.CodeGenerator.Core.GeneratorModels
{
    /// <summary>
    /// 
    /// </summary>
    public class MethodGenInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TypeGenInfo ReturnType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ParameterGenInfo> Parameters { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
