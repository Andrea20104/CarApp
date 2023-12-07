using Api.IoC.Modules;

namespace Api.IoC
{
    using Module = Autofac.Module;
    using Autofac;

    /// <summary>
    /// Container Module.
    /// </summary>
    /// <seealso cref="Module" />
    public class ContainerModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<AutoMapperModule>();
            builder.RegisterModule<CoreApplicationModule>();

            base.Load(builder);
        }
    }
}
