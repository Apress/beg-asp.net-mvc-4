using System;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using HaveYouSeenMe.Models;

namespace HaveYouSeenMe
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "00000000400EF579",
                clientSecret: "6KQc3wk1Gbapkqt5taQTnu5kghaX5yz0");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "DkHHXTnfqeeVs36LsEDznQ",
                consumerSecret: "FLM48v3AnwhyRWlJd82x9asLrgFUYKhYkcnzYiEBCg");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "234957339982566",
                appSecret: "a68e8c9fc57dec9283dde2c3f4f2d20e");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
