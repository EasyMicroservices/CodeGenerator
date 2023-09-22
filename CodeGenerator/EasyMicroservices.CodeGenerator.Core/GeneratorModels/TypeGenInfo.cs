using System.Collections.Generic;

namespace EasyMicroservices.CodeGenerator.Core.GeneratorModels
{
    public class TypeGenInfo
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public bool IsClass { get; set; }
        public bool IsInterface { get; set; }
        public bool IsEnum { get; set; }
        public string AssemblyFileName { get; set; }

        public List<TypeGenInfo> GenericArguments { get; set; }
        public List<TypeGenInfo> Interfaces { get; set; }
        public TypeGenInfo BaseType { get; set; }
        public List<PropertyGenInfo> Properties { get; set; }
        public List<MethodGenInfo> Methods { get; set; }
    }
}
