using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using cSharpAuth.Services;
using Lib;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace cSharpAuth.HealthChecks
{
    public class UserProfileHealthCheck : IHealthCheck
    {
        private readonly UserProfileService  _userProfileService;
        public UserProfileHealthCheck(UserProfileService userProfileService)
        {
            this._userProfileService = userProfileService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _userProfileService.GetUserProfileAsync("a");
                return HealthCheckResult.Healthy("A healthy result");
            }
            catch(Exception e){
                return HealthCheckResult.Unhealthy("An unhealthy result");
            }
        }
    }
}