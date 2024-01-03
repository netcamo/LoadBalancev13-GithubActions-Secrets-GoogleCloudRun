using Umbraco.Cms.Core.Sync;
namespace Loadbalancev13GithubactionsSecretsGooglecloudrun.Web.ServerRoleAccessors;

public class SingleServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.Single;
}