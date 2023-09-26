using EasyMicroservices.CodeGenerator.Core.GeneratorModels;
using EasyMicroservices.CodeGenerator.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace EasyMicroservices.CodeGenerator.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerToolConverter : IToolConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<AssemblyGenInfo> Convert<T>(T data)
        {
            throw new NotImplementedException();
        }
    }
}
