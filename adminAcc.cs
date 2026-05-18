using System;
using System.Collections.Generic;
using System.Text;

namespace PantawidPasada
{
    /// <summary>
    /// Data transfer object (DTO) that holds profile information for an administrator account.
    /// Populated during admin login and passed between forms to display admin details
    /// and enforce role-based access without repeated database queries.
    /// </summary>
    public class adminAcc
    {
        /// <summary>The administrator's first name.</summary>
        public string FirstName { get; set; }

        /// <summary>The administrator's last name.</summary>
        public string LastName { get; set; }

        /// <summary>The administrator's middle initial.</summary>
        public string MiddleInit { get; set; }

        /// <summary>
        /// The administrator's role within the system (e.g., "Admin", "SuperAdmin").
        /// Used to determine access level and permissions.
        /// </summary>
        public string role { get; set; }

        /// <summary>The administrator's login username.</summary>
        public string username { get; set; }

        /// <summary>The administrator's contact/phone number.</summary>
        public string phoneNum { get; set; }

        /// <summary>The administrator's email address.</summary>
        public string email { get; set; }

        /// <summary>The date and time when the admin account was created.</summary>
        public string createDay { get; set; }

        /// <summary>
        /// The current account status. Expected values: "Active" or "Deactivated".
        /// Deactivated accounts are blocked from logging in.
        /// </summary>
        public string status { get; set; }
    }
}
