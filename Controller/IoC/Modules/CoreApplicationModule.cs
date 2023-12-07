using Autofac;
using Autofac.Core;
using Business.Interfaces.Services;
using System.Diagnostics;
using System.Reflection;

namespace Api.IoC.Modules
{

    /// <summary>
    /// Core Application Module.
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class CoreApplicationModule : Autofac.Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = GetAssembliesInBasePath().ToArray();

            // Register all types implementing IService
            builder.RegisterAssemblyTypes(assemblies)
                .AssignableTo<IService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        private static IEnumerable<Assembly> GetAssembliesInBasePath()
        {
            var basePath = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            var basePathAssemblies = new List<Assembly>();

            var files = Directory.GetFiles(basePath, "Business*.dll").ToList();
            files.AddRange(Directory.GetFiles(basePath, "Business*.exe").ToList());
            foreach (var dll in files)
            {
                try
                {
                    var assemblyName = AssemblyName.GetAssemblyName(dll);
                    basePathAssemblies.Add(Assembly.Load(assemblyName.FullName));
                }
                catch (Exception ex)
                {
                    // Ignore the error
                    Debug.WriteLine(ex);
                }
            }

            return basePathAssemblies;
        }
    }
}
