using System.Collections.Generic;

namespace NbSites.Web.Demo.ClientCredentials
{
    public interface IFooService
    {
        IList<Foo> GetAll();
    }

    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FooService : IFooService
    {
        public IList<Foo> GetAll()
        {
            return new List<Foo> { new Foo() { Id = 1, Name = "Hello" } };
        }
    }
}
