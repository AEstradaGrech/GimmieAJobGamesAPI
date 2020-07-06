using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


public class AuthorizationRequirement : AuthorizationHandler<AuthorizationRequirement>, IAuthorizationRequirement
{
    private IEnumerable<string> _requiredScopes;

    public AuthorizationRequirement(IEnumerable<string> requiredScopes)
    {
        _requiredScopes = requiredScopes;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
    {
        var roleClaim = context.User.Identities
                                    .First()
                                    .Claims
                                    .Where(c => c.Type.Contains("role"))
                                    .ToList();

        roleClaim.ToList().ForEach(claim => {
            if (_requiredScopes.Contains(claim.Value))
                context.Succeed(requirement);
        });

        return;
    }
}