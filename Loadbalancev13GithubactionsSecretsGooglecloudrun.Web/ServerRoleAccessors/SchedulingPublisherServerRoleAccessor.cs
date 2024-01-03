using Umbraco.Cms.Core.Sync;
namespace Loadbalancev13GithubactionsSecretsGooglecloudrun.Web.ServerRoleAccessors;

public class SchedulingPublisherServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.SchedulingPublisher;
}