using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core.GeneratorModels
{
    public class AssemblyGenInfo
    {
        public string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TypeGenInfo> Types { get; set; }
    }
}
