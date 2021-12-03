using Osb.Core.Platform.Common.Util.Security;

namespace Osb.Core.Platform.Business.Util
{
    public static class CardUtil
    {
        public static string EncryptPin(string pin, string salt, string aesKey, string aesIV)
        {
            return AesProvider.Encrypt(pin, salt, aesKey, aesIV);
        }

        public static string DecryptPin(string pin, string salt, string aesKey, string aesIV)
        {
            return AesProvider.Decrypt(pin, salt, aesKey, aesIV);
        }
    }
}