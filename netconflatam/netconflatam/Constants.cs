using System;
namespace netconflatam
{
    public static class Constants
    {
        public static readonly string TenantName = "";

        public static readonly string TenantId = "";

        public static readonly string ClientId = "";

        public static readonly string PolicySignin = "";

        public static readonly string PolicyPassword = "";

        // set to a unique value for your app, such as your bundle identifier. Used on iOS to share keychain access.
        public static readonly string IosKeychainSecurityGroup = "com.talkwithangel.netconflatam";

        public static readonly string[] Scopes = { "" };

        public static readonly string AuthorityBase = $"https://{TenantName}.b2clogin.com/tfp/{TenantId}/";

        public static string AuthoritySignin = $"{AuthorityBase}{PolicySignin}";

        public static string AuthorityPasswordReset = $"{AuthorityBase}{PolicyPassword}";

    }
}
