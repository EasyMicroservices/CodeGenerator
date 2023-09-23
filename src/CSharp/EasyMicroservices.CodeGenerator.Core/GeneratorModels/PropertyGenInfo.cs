﻿namespace EasyMicroservices.CodeGenerator.Core.GeneratorModels
{
    public class PropertyGenInfo
    {
        public string Name { get; set; }
        public TypeGenInfo Type { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}