using System;
using System.Collections.Generic;
using System.Text;

namespace PantawidPasada
{
    /// <summary>
    /// Provides the global MySQL connection string used throughout the application.
    /// Centralizes database configuration so that changes to credentials or host
    /// only need to be made in one place.
    /// </summary>
    public static class dataBaseDetails
    {
        /// <summary>
        /// The MySQL connection string for the pantawid_pasada database.
        /// Uses localhost with root credentials. Update this value if the
        /// database host, username, password, or schema name changes.
        /// </summary>
        public const string connStr = "server=localhost;user=root;password=karlbensi12345;database=pantawid_pasada;";
    }
}
