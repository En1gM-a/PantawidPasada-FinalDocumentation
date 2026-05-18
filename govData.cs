using System;
using System.Collections.Generic;
using System.Text;

namespace PantawidPasada
{
    /// <summary>
    /// Data transfer object (DTO) that holds profile information for a government user account.
    /// Populated during government login and passed between forms to display the user's
    /// details and agency affiliation without additional database queries.
    /// </summary>
    public class govData
    {
        /// <summary>The government user's first name.</summary>
        public string firstName { get; set; }

        /// <summary>The government user's last name.</summary>
        public string lastName { get; set; }

        /// <summary>The government user's middle initial (optional).</summary>
        public string? middleInit { get; set; }

        /// <summary>
        /// The government agency the user belongs to (e.g., "DOTr", "DOH", "DPWH", "DSWD").
        /// </summary>
        public string agency { get; set; }

        /// <summary>The government user's login username.</summary>
        public string username { get; set; }

        /// <summary>
        /// The current account status. Expected values: "Active" or "Deactivated".
        /// Deactivated accounts are blocked from logging in.
        /// </summary>
        public string govStats { get; set; }

        /// <summary>The government user's contact/phone number.</summary>
        public string contactNum { get; set; }

        /// <summary>The government user's email address.</summary>
        public string email { get; set; }

        /// <summary>The date and time when the government account was created.</summary>
        public string createDay { get; set; }
    }
}
