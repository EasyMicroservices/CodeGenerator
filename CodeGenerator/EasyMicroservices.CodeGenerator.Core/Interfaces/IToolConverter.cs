using EasyMicroservices.CodeGenerator.Core.GeneratorModels;
using System.Collections.Generic;

namespace EasyMicroservices.CodeGenerator.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IToolConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        List<AssemblyGenInfo> Convert<T>(T data);
    }
}
