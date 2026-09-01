namespace Summary.Liyam
{
    using Core.DisplayManagement.Handlers;
    using Core.Modules;
    using Core.Navigation;
    using Core.Security.Permissions;
    using Core.Settings;
    using Core.Workflows.Helpers;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Summary.Liyam.Workflows.Event.Identity.Create;
    using Summary.Liyam.Workflows.Event.Identity.Update;
    using Summary.Liyam.Workflows.Event.Product.Create;
    using Summary.Liyam.Workflows.Event.Product.Update;
    using Summary.Liyam.Workflows.Task.Person.Create;
    using Summary.Liyam.Services;

    [Feature(Liyam.Features.Liyam)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INavigationProvider, Menu>();
            services.AddScoped<IPermissionProvider, Permissions>();
            services.AddScoped<IPersonService, PersonService>();
            
            services.AddScoped<IDisplayDriver<ISite>, LiyamSettingsDisplayDriver>();
            services.AddTransient<IConfigureOptions<LiyamSettings>, LiyamSettingsConfiguration>();

            services.AddActivity<CreateProductInLiyamEvent, CreateProductInLiyamDisplay>();
            services.AddActivity<UpdateProductInLiyamEvent, UpdateProductInLiyamDisplay>();

            services.AddActivity<CreateIdentityInLiyamEvent, CreateIdentityInLiyamDisplay>();
            services.AddActivity<UpdateIdentityInLiyamEvent, UpdateIdentityInLiyamDisplay>();

            services.AddActivity<CreatePersonInLiyamTask, CreatePersonInLiyamDisplay>();
        }
    }
}