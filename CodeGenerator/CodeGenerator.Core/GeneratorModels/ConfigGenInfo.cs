﻿namespace CodeGenerator.Core.GeneratorModels
{
    public class ConfigGenInfo
    {
        /// <summary>
        /// replace namespaces from your code to another one
        /// </summary>
        public List<ReplaceGenInfo> ReplaceNameSpaces { get; set; }
        /// <summary>
        /// add this prefix to all your namespaces
        /// </summary>
        public string GlobalPrefixNamespace { get; set; }
        /// <summary>
        /// skip any types from these assemblies to generate
        /// </summary>
        public List<string> SkipAssemblies { get; set; }
    }
}
