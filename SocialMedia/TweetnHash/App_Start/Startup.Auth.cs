using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Twitter;
using Owin;
using System;
using System.Threading.Tasks;
using TweetnHash.Models;

namespace TweetnHash
{
    public partial class Startup
    {
        private object context;

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "vQ8yATnZWOXWEelgVVAovIToS",
            //   consumerSecret: "LFddwqut6dekKbGSbaE7f6k6ErAbU5VNbNa4FrmJT9sip2Bdaf");

            app.UseTwitterAuthentication(new TwitterAuthenticationOptions
            {
                ConsumerKey = "vQ8yATnZWOXWEelgVVAovIToS",
                ConsumerSecret = "LFddwqut6dekKbGSbaE7f6k6ErAbU5VNbNa4FrmJT9sip2Bdaf",
                BackchannelCertificateValidator = new CertificateSubjectKeyIdentifierValidator(new[]
                {
                    "A5EF0B11CEC04103A34A659048B21CE0572D7D47", // VeriSign Class 3 Secure Server CA - G2
                    "0D445C165344C1827E1D20AB25F40163D8BE79A5", // VeriSign Class 3 Secure Server CA - G3
                    "7FD365A7C2DDECBBF03009F34339FA02AF333133", // VeriSign Class 3 Public Primary Certification Authority - G5
                    "39A55D933676616E73A761DFA16A7E59CDE66FAD", // Symantec Class 3 Secure Server CA - G4
                    "‎add53f6680fe66e383cbac3e60922e3b4c412bed", // Symantec Class 3 EV SSL CA - G3
                    "4eb6d578499b1ccf5f581ead56be3d9b6744a5e5", // VeriSign Class 3 Primary CA - G5
                    "5168FF90AF0207753CCCD9656462A212B859723B", // DigiCert SHA2 High Assurance Server C‎A 
                    "B13EC36903F8BF4701D498261A0802EF63642BC3" // DigiCert High Assurance EV Root CA
                })
            });

            //app.UseFacebookAuthentication(new FacebookAuthenticationOptions()
            //{
            //    AppId = "1869018590030689",
            //    AppSecret = "e59ea6f37400f3bcfcd119e63636d0f0"
            //});

            //var facebookOptions = new FacebookAuthenticationOptions()
            //{
            //    AppId = "1228273303938047",
            //    AppSecret = "a194b3358cd27682691a3397ee84824b",
            //    BackchannelHttpHandler = new FacebookBackChannelHandler(),
            //    UserInformationEndpoint = "https://graph.facebook.com/v2.9/me?fields=id,name,email,first_name,last_name,picture"
            //};
            //facebookOptions.Scope.Add("email");
            //app.UseFacebookAuthentication(facebookOptions);

            var facebookOptions = new FacebookAuthenticationOptions()
            {
                AppId = "1228273303938047",
                AppSecret = "a194b3358cd27682691a3397ee84824b",
            };

            // Set requested scope
            facebookOptions.Scope.Add("email");
            facebookOptions.Scope.Add("public_profile");

            // Set requested fields
            facebookOptions.Fields.Add("email");
            facebookOptions.Fields.Add("first_name");
            facebookOptions.Fields.Add("last_name");

            facebookOptions.Provider = new FacebookAuthenticationProvider()
            {
                OnAuthenticated = (context) =>
                {
                    // Attach the access token if you need it later on for calls on behalf of the user
                    context.Identity.AddClaim(new System.Security.Claims.Claim("FacebookAccessToken", context.AccessToken));

                    foreach (var claim in context.User)
                    {
                        //var claimType = string.Format("urn:facebook:{0}", claim.Key);
                        var claimType = string.Format("{0}", claim.Key);
                        string claimValue = claim.Value.ToString();

                        if (!context.Identity.HasClaim(claimType, claimValue))
                            context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, "XmlSchemaString", "Facebook"));
                    }

                    return Task.FromResult(0);
                }
            };

            app.UseFacebookAuthentication(facebookOptions);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "168651069881-q42o8tvstotvrul5nl3ve8ndj911lcjh.apps.googleusercontent.com",
                ClientSecret = "7kUPNV3IMxH0LSWeAiz5YVuc"
            });
        }
    }
}