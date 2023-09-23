using System.Collections.Generic;

namespace EasyMicroservices.CodeGenerator.Core.GeneratorModels
{
    /// <summary>
    /// 
    /// </summary>
    public class AssemblyGenInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TypeGenInfo> Types { get; set; }

        public override string ToString()
        {
            return FileName;
        }
    }
}
