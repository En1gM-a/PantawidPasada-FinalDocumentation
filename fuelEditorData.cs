using System;
using System.Collections.Generic;
using System.Text;

namespace PantawidPasada
{
    /// <summary>
    /// Data transfer object (DTO) that holds session information for a fuel editor account.
    /// Populated during fuel editor login and passed to the fuel editor dashboard
    /// to identify which fuel station the editor manages.
    /// </summary>
    public class fuelEditorData
    {
        /// <summary>
        /// The unique database identifier for this fuel editor account.
        /// Maps to the <c>editor_id</c> column in the <c>fuelEditors</c> table.
        /// </summary>
        public int editor_id { get; set; }

        /// <summary>
        /// The full display name of the fuel editor (typically the station brand name,
        /// e.g., "Petron", "Shell", "Caltex", "SeaOil").
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The fuel editor's login username. The username typically contains the station
        /// brand keyword (e.g., "petron_editor") which is used to determine the station
        /// logo and branding on the dashboard.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// The current account status. Expected values: "Active" or "Deactivated".
        /// Deactivated accounts are blocked from logging in.
        /// </summary>
        public string status { get; set; }
    }
}
