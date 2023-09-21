namespace CodeGenerator.Core.GeneratorModels
{
    public class MethodGenInfo
    {
        public string Name { get; set; }
        public TypeGenInfo ReturnType { get; set; }
        public List<ParameterGenInfo> Parameters { get; set; }
    }
}
