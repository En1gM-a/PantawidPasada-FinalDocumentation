using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PantawidPasada
{
    /// <summary>
    /// Provides password hashing functionality using the SHA-256 algorithm.
    /// Passwords are never stored in plain text; they are always hashed before
    /// being saved to or compared against the database.
    /// </summary>
    public class HashPassword
    {
        /// <summary>
        /// Hashes a plain-text password using SHA-256 and returns the result
        /// as a lowercase hexadecimal string.
        /// </summary>
        /// <param name="password">The plain-text password to hash.</param>
        /// <returns>
        /// A 64-character lowercase hex string representing the SHA-256 hash
        /// of the input password.
        /// </returns>
        public string HashPass(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the password string to a UTF-8 byte array and compute its hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert each byte to a two-digit lowercase hex string and concatenate
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
