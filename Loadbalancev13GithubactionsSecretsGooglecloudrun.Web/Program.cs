using Hangfire;
using Umbraco.Cms.Infrastructure.DependencyInjection;
using Loadbalancev13GithubactionsSecretsGooglecloudrun.Web.ServerRoleAccessors;
using Loadbalancev13GithubactionsSecretsGooglecloudrun.Web.TvMazeShow;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var umbracoBuilder = builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers();

if (builder.Environment.EnvironmentName.Equals("Subscriber"))
{
    umbracoBuilder.SetServerRegistrar<SubscriberServerRoleAccessor>()
        .AddAzureBlobMediaFileSystem()
        .AddAzureBlobImageSharpCache();
}
else if (builder.Environment.IsProduction())
{
    umbracoBuilder.SetServerRegistrar<SchedulingPublisherServerRoleAccessor>();
    RecurringJob.AddOrUpdate<TvMazeUtility>("MoveTvShowsFromTvMazeToUmbraco", x => x.MoveTvShowsFromTvMazeToUmbraco(), Cron.Monthly);

}
else
{
    umbracoBuilder.SetServerRegistrar<SingleServerRoleAccessor>();
 
}


umbracoBuilder.Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();


//if (builder.Environment.IsProduction())
//{
 
//}

app.UseHttpsRedirection();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
