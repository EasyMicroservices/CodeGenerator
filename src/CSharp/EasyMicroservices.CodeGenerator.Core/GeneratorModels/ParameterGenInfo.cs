using System.Runtime.InteropServices.ComTypes;

namespace EasyMicroservices.CodeGenerator.Core.GeneratorModels
{
    public class ParameterGenInfo
    {
        public string Name { get; set; }
        public TypeGenInfo Type { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
