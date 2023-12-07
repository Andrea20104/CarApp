namespace Api.IoC.Modules
{
    using Autofac;
    using Mapping;

    /// <summary>
    /// Auto Mapper Module.
    /// </summary>
    /// <seealso cref="Module" />
    public class AutoMapperModule : Module
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
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
        }
    }
}
