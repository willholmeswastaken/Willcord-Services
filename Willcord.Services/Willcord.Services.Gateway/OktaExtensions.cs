using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Okta.AspNet.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Willcord.Services.Gateway
{
    public static class OktaExtensions
    {
        public static AuthenticationBuilder AddOktaWebApiTest(this AuthenticationBuilder builder, OktaWebApiOptions options)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            new OktaWebApiOptionsValidator().Validate(options);

            return AddJwtValidation(builder, options);
        }

        private static AuthenticationBuilder AddJwtValidation(AuthenticationBuilder builder, OktaWebApiOptions options)
        {
            var issuer = UrlHelper.CreateIssuerUrl(options.OktaDomain, options.AuthorizationServerId);

            var tokenValidationParameters = new DefaultTokenValidationParameters(options, issuer)
            {
                ValidAudience = options.Audience,
            };

            builder.AddJwtBearer("okta", opt =>
            {
                opt.Audience = options.Audience;
                opt.Authority = issuer;
                opt.TokenValidationParameters = tokenValidationParameters;
                opt.BackchannelHttpHandler = new OktaHttpMessageHandler("okta-aspnetcore", typeof(Okta.AspNetCore.OktaAuthenticationOptionsExtensions).Assembly.GetName().Version, options);

                opt.SecurityTokenValidators.Clear();
                opt.SecurityTokenValidators.Add(new StrictSecurityTokenValidator());
            });

            return builder;
        }

        public static string CreateIssuerUrl(string oktaDomain, string authorizationServerId)
        {
            if (string.IsNullOrEmpty(oktaDomain))
            {
                throw new ArgumentNullException(nameof(oktaDomain));
            }

            if (string.IsNullOrEmpty(authorizationServerId))
            {
                return oktaDomain;
            }

            return $"{EnsureTrailingSlash(oktaDomain)}oauth2/{authorizationServerId}";
        }

        public static string EnsureTrailingSlash(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            return uri.EndsWith("/")
                ? uri
                : $"{uri}/";
        }
    }
}
