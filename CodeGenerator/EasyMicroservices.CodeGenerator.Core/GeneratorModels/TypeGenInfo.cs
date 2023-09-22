namespace EasyMicroservices.CodeGenerator.Core.GeneratorModels
{
    public class TypeGenInfo
    {
        public string Name { get; set; }
        public string NameSpace { get; set; }
        public bool IsClass { get; set; }
        public bool IsEnum { get; set; }
        public List<TypeGenInfo> GenericArguments { get; set; }
        public List<PropertyGenInfo> Properties { get; set; }
        public List<MethodGenInfo> Methods { get; set; }
    }
}
