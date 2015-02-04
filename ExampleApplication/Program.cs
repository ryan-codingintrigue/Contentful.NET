using System;
using System.Threading;
using Contentful.NET;
using Contentful.NET.DataModels;
using Contentful.NET.Search;
using Contentful.NET.Search.Filters;

namespace ExampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ContentfulClient("accessToken", "spaceId");
            var cancellationToken = new CancellationToken();
            var entries = client.SearchAsync<Entry>(cancellationToken, new[]
            {
                new EqualitySearchFilter(BuiltInProperties.SysId, "id")
            }).Result;
            Console.Read();
        }
    }
}
