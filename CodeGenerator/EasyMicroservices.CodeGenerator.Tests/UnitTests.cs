using EasyMicroservices.CodeGenerator.DotNetReflection;
using EasyMicroservices.CodeGenerator.Tests.Models;

namespace EasyMicroservices.CodeGenerator.Tests
{
    public class UnitTests
    {
        [Fact]
        public void GetFromType()
        {
            DotNetToolConverter dotNetToolConverter = new DotNetToolConverter();
            var result = dotNetToolConverter.Convert(typeof(PersonClient));
            Assert.NotNull(result);
            Assert.Contains(result, x => x.Types.Any(t => t.Properties.Any(p => p.Name == nameof(PersonClient.Family))));
            Assert.Contains(result, x => x.Types.Any(t => t.Methods.Any(p => p.Name == nameof(PersonClient.IsAlive))));
        }
    }
}