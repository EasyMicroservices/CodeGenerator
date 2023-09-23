namespace EasyMicroservices.CodeGenerator.Tests.Models
{
    public class PersonClient
    {
        public string Name { get; set; }
        public string Family { get; set; }

        public bool IsAlive()
        {
            return false;
        }
    }
}
