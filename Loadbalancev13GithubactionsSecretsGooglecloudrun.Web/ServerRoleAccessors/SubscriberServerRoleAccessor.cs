using Umbraco.Cms.Core.Sync;
namespace Loadbalancev13GithubactionsSecretsGooglecloudrun.Web.ServerRoleAccessors;

public class SubscriberServerRoleAccessor :IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.Subscriber;
}