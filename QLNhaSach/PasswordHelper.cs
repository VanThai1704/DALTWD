using System;
using System.Security.Cryptography;
using System.Text;

namespace QLNhaSach
{
    /// <summary>
    /// Helper class ?? hash m?t kh?u v?i salt ng?u nhiên
    /// M?i l?n hash s? t?o ra k?t qu? khác nhau ngay c? v?i cùng m?t kh?u
    /// </summary>
    public static class PasswordHelper
    {
        private const int SaltSize = 32; // 32 bytes = 256 bits
        private const int HashSize = 32; // 32 bytes = 256 bits
        private const int Iterations = 10000; // S? l?n l?p PBKDF2

        /// <summary>
        /// T?o salt ng?u nhiên (base64 string)
        /// </summary>
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Hash m?t kh?u v?i salt s? d?ng PBKDF2
        /// </summary>
        /// <param name="password">M?t kh?u g?c</param>
        /// <param name="salt">Salt (base64 string)</param>
        /// <returns>Hash (base64 string)</returns>
        public static string HashPassword(string password, string salt)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrEmpty(salt))
                throw new ArgumentNullException(nameof(salt));

            byte[] saltBytes = Convert.FromBase64String(salt);
            
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);
                return Convert.ToBase64String(hashBytes);
            }
        }

        /// <summary>
        /// Hash m?t kh?u và t?o salt m?i (dùng khi t?o user m?i ho?c ??i m?t kh?u)
        /// </summary>
        /// <param name="password">M?t kh?u g?c</param>
        /// <param name="salt">Output: Salt ???c t?o</param>
        /// <returns>Hash c?a m?t kh?u</returns>
        public static string HashPasswordWithNewSalt(string password, out string salt)
        {
            salt = GenerateSalt();
            return HashPassword(password, salt);
        }

        /// <summary>
        /// Verify m?t kh?u nh?p vào có kh?p v?i hash ?ã l?u không
        /// </summary>
        /// <param name="password">M?t kh?u c?n ki?m tra</param>
        /// <param name="storedHash">Hash ?ã l?u trong DB</param>
        /// <param name="storedSalt">Salt ?ã l?u trong DB</param>
        /// <returns>True n?u m?t kh?u ?úng</returns>
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(storedSalt))
                return false;

            try
            {
                string hashOfInput = HashPassword(password, storedSalt);
                return hashOfInput == storedHash;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Hash m?t kh?u theo cách c? (SHA256 ??n gi?n, không có salt)
        /// Ch? dùng ?? migrate d? li?u c?
        /// </summary>
        [Obsolete("Ch? dùng ?? migrate d? li?u c?. S? d?ng HashPasswordWithNewSalt thay th?.")]
        public static string HashPasswordLegacy(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
