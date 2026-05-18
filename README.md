# Pantawid Pasada

Pantawid Pasada is a Windows Forms desktop application built with C# and .NET for managing fuel subsidy applications, driver records, fuel prices, fare information, and role-based account access.

The system is designed around four main user roles:

- Drivers can register, submit personal/vehicle/financial information, and request subsidy support.
- Administrators can manage accounts, review records, and monitor system activity.
- Government users can review driver subsidy applications and update application status.
- Fuel editors can manage fuel price information used throughout the app.

---

## Features

- Role-based login for drivers, administrators, government users, and fuel editors
- Driver registration workflow with personal, contact, financial, and vehicle details
- Subsidy application review with approval, rejection, hold, and review states
- Admin and government account management
- Fuel price viewing and editing
- Fuel station price tracking
- Dashboard-style views for different roles
- Fare matrix display
- MySQL-backed data storage
- Password hashing support
- Email helper service
- Chart support using LiveCharts and SkiaSharp

---

## Tech Stack

| Area | Technology |
| --- | --- |
| Language | C# |
| UI Framework | Windows Forms |
| Runtime | .NET 10 Windows |
| Database | MySQL |
| Charts | LiveChartsCore, SkiaSharp |
| Data / Utility Packages | MySql.Data, Newtonsoft.Json, Parquet.Net, System.Net.Http |

---

## Requirements

Before running the project, install:

- Windows 10 or later
- Visual Studio 2022 or later
- .NET 10 SDK
- MySQL Community Server
- MySQL Workbench, optional but recommended

In Visual Studio, install the `.NET desktop development` workload.

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/En1gM-a/PantawidPasada2.git
cd PantawidPasada2
```

### 2. Open the project

Open the solution file in Visual Studio:

```text
PantawidPasada.slnx
```

### 3. Restore packages

Visual Studio usually restores NuGet packages automatically. If needed, run:

```bash
dotnet restore
```

### 4. Build the project

```bash
dotnet build
```

Or press `Ctrl + Shift + B` in Visual Studio.

---

## Database Setup

This project uses MySQL. A database backup is included in the repository:

```text
backup.sql
```

### Option A: Import using MySQL Workbench

1. Open MySQL Workbench.
2. Connect to your local MySQL server.
3. Go to `Server > Data Import`.
4. Choose `Import from Self-Contained File`.
5. Select `backup.sql`.
6. Start the import.

### Option B: Import using command line

Create the database first:

```sql
CREATE DATABASE IF NOT EXISTS pantawid_pasada;
```

Then import the backup:

```bash
mysql -u root -p pantawid_pasada < backup.sql
```

---

## Connection String

The app connects to a local MySQL database. Update the connection string values in the source files that access the database.

Common files that contain database access logic include:

- `dataBaseDetails.cs`
- `SaveDataBase.cs`
- `loginCheck.cs`
- `accessDriverInfo.cs`
- `accessAdminGovAccs.cs`
- `manageAccAdmin.cs`
- `subsidyApp.cs`
- `manageSubsidy.cs`
- `fuelPrice.cs`
- `dashboardPetron.cs`

Typical connection string format:

```csharp
server=localhost;user id=root;password=YOUR_PASSWORD;database=pantawid_pasada;
```

For security, avoid committing real passwords to GitHub. Use local-only configuration for private credentials when possible.

---

## Running the App

Run from Visual Studio:

1. Open `PantawidPasada.slnx`.
2. Set the project as the startup project.
3. Press `F5`.

Or run from the command line:

```bash
dotnet run
```

The application starts at the login screen.

---

## Project Structure

```text
PantawidPasada/
|-- Program.cs                    # Application entry point
|-- PantawidPasada.csproj         # .NET project configuration
|-- PantawidPasada.slnx           # Visual Studio solution
|-- backup.sql                    # MySQL database backup
|
|-- Form1.cs                      # Login screen
|-- Form2.cs                      # Driver registration workflow
|-- Form3.cs                      # Driver main panel
|-- adminPanel.cs                 # Admin main panel
|-- governmentPanel.cs            # Government main panel
|-- homeAdmin.cs                  # Admin dashboard
|-- homeDriver.cs                 # Driver dashboard
|-- homeGovernment.cs             # Government dashboard
|-- homePetroncs.cs               # Fuel editor home panel
|
|-- personalInfo.cs               # Driver personal information form
|-- contact.cs                    # Driver contact information form
|-- financialInfo.cs              # Driver financial information form
|-- vehicleInfo.cs                # Driver vehicle information form
|-- summary.cs                    # Registration summary view
|
|-- subsidyApp.cs                 # Subsidy application review
|-- requestSubsidy.cs             # Driver subsidy request form
|-- manageSubsidy.cs              # Subsidy release and management
|
|-- fuelPrice.cs                  # Fuel price display
|-- fuelPriceONLINE.cs            # Online fuel price data support
|-- fuelPricewithStation.cs       # Station fuel price data
|-- manageFuel.cs                 # Fuel price management
|-- dashboardPetron.cs            # Fuel editor dashboard
|-- forGraph.cs                   # Chart setup logic
|
|-- manageAccAdmin.cs             # Admin/government account management
|-- accessDriverInfo.cs           # Driver database loading helper
|-- accessAdminGovAccs.cs         # Admin/government database loading helper
|-- loginCheck.cs                 # Login validation logic
|-- HashPassword.cs               # Password hashing helper
|-- SaveDataBase.cs               # Driver registration database save logic
|-- SendEmail.cs                  # Email helper service
|
|-- Resources/                    # Image assets used by the UI
|-- Properties/                   # Generated resource metadata
```

Most Windows Forms screens also have matching `.Designer.cs` and `.resx` files generated by Visual Studio.

---

## Main Workflows

### Driver Workflow

1. Driver creates an account.
2. Driver fills in personal, contact, financial, and vehicle information.
3. Driver reviews the summary and submits the application.
4. Driver can request subsidy support.

### Government Workflow

1. Government user logs in.
2. User reviews submitted driver applications.
3. User changes application status to approved, rejected, on hold, or under review.

### Admin Workflow

1. Admin logs in.
2. Admin manages administrator and government accounts.
3. Admin monitors driver and account data.

### Fuel Editor Workflow

1. Fuel editor logs in.
2. Fuel editor manages fuel prices.
3. Updated fuel price information appears in fuel-related dashboards and views.

---

## Notes for Contributors

- Keep generated `.Designer.cs` files managed through Visual Studio Designer when possible.
- Do not commit `bin/`, `obj/`, `.vs/`, or local database credentials.
- Test login and database workflows after changing table names, connection strings, or account models.
- Keep UI resource images inside the `Resources/` folder.
- If you change the database schema, update `backup.sql` and this README.

---

## Disclaimer

This project is an academic/student system prototype for managing Pantawid Pasada-related workflows. It is not an official government system.
