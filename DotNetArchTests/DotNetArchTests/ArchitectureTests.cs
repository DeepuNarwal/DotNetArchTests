using System;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;

namespace DotNetArchTests
{
    public class ArchitectureTests
    {
        public static void RunTests()
        {
            Console.WriteLine("Running Architecture Tests..");
            Test_ServiceNaminConvention();
            Test_RepositoryNamingConvention();
            Test_ModelPropertyNamingConvention();
        }

        private static void Test_ModelPropertyNamingConvention()
        {
            Console.WriteLine("Running Product Model Naming Convention Test...");
            var result = typeof(DotNetArchTests.Models.ProductModel)
                .GetProperties()
                .Where(p => !IsPascalCase(p.Name))
                .ToList();
            if (result.Any())
            {
                Console.WriteLine("Naming convention test failed!");
                foreach (var prop in result)
                {
                    Console.WriteLine($"   - {prop.Name} does not follow PascalCase.");
                }
            }
            else
            {
                Console.WriteLine("All properties follow PascalCase naming convention!");
            }
        }

        private static bool IsPascalCase(string name)
        {
            return char.IsUpper(name[0]) && !name.Contains("_");
        }

        private static void Test_RepositoryNamingConvention()
        {
            var result = Types.InCurrentDomain()
                .That()
                .ResideInNamespace("DotNetArchTests.Repositories")
                .Should()
                .HaveNameEndingWith("Repository")
                .GetResult();

            if (result.IsSuccessful)
            {
                Console.WriteLine("Repository naming convention test passed.");
            }
            else
            {
                Console.WriteLine("Repository naming convention test failed!");
                foreach (var type in result.FailingTypes)
                {
                    Console.WriteLine($"   - {type.Name} does not follow the 'Repository' naming convention.");
                }
            }
        }

        private static void Test_ServiceNaminConvention()
        {
            var result = Types.InCurrentDomain()
                .That()
                .ResideInNamespace("DotNetArchTests.Services")
                .Should()
                .HaveNameEndingWith("Servic")
                .GetResult();

            if (result.IsSuccessful)
            {
                Console.WriteLine("Service Naming Convention passed.");
            }
            else
            {
                Console.WriteLine("Service Naming Convention test failed");
                foreach (var type in result.FailingTypes)
                {
                    Console.WriteLine($" - {type.Name} does not follow the Service Naming Convetion");
                }
            }
        }
    }
}
