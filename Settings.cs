namespace Summary.Liyam
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Core.DisplayManagement.Entities;
    using Core.DisplayManagement.Handlers;
    using Core.DisplayManagement.Views;
    using Core.Entities;
    using Core.Environment.Shell;
    using Core.Settings;

    public class LiyamSettings
    {
        public string ApiAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AppKey { get; set; }
    }

    public class LiyamSettingsDisplayDriver : SectionDisplayDriver<ISite,
        LiyamSettings>
    {
        private readonly IShellHost _host;
        private readonly ShellSettings _shell;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly IAuthorizationService _authorize;

        public LiyamSettingsDisplayDriver(IShellHost host,
            ShellSettings settings,
            IHttpContextAccessor httpContext,
            IAuthorizationService authorize)
        {
            _host = host;
            _shell = settings;
            _httpAccessor = httpContext;
            _authorize = authorize;
        }

        public override async Task<IDisplayResult> EditAsync(LiyamSettings settings,
            BuildEditorContext context)
        {
            var user = _httpAccessor.HttpContext?.User;
            if (user is null || !await _authorize.AuthorizeAsync(user, Permissions.ManageLiyamSettings))
            {
                return null;
            }

            var init = Initialize<LiyamSettings>("LiyamSettings_Edit", model =>
            {
                model.ApiAddress = settings.ApiAddress;
                model.Username = settings.Username;
                model.Password = settings.Password;
                model.AppKey = settings.AppKey;
            });
            return init.Location("Content:5").OnGroup("Liyam");
        }

        public override async Task<IDisplayResult> UpdateAsync(LiyamSettings settings,
            BuildEditorContext context)
        {
            var user = _httpAccessor.HttpContext?.User;
            if (user is null || !await _authorize.AuthorizeAsync(user, Permissions.ManageLiyamSettings))
            {
                return null;
            }
            if (context.GroupId == "Liyam")
            {
                await context.Updater.TryUpdateModelAsync(settings, Prefix);
                await _host.ReloadShellContextAsync(_shell);
            }
            return await EditAsync(settings, context);
        }
    }

    public class LiyamSettingsConfiguration : IConfigureOptions<LiyamSettings>
    {
        private readonly ISiteService _site;
        private readonly ILogger<LiyamSettingsConfiguration> _logger;

        public LiyamSettingsConfiguration(ISiteService site,
            ILogger<LiyamSettingsConfiguration> logger)
        {
            _site = site;
            _logger = logger;
        }

        public void Configure(LiyamSettings options)
        {
            var settings = _site.GetSiteSettingsAsync().GetAwaiter().GetResult().As<LiyamSettings>();
            options.ApiAddress = settings.ApiAddress;
            options.Username = settings.Username;
            options.Password = settings.Password;
            options.AppKey = settings.AppKey;
        }
    }
}