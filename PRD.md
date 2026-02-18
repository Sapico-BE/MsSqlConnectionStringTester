# PRD: SQLConnCheck (Minimalist)

## 1. Objective
A lightweight Windows Forms utility to validate MS SQL Server connection strings via manual input or `appsettings.json` parsing.

---

## 2. User Stories
* **Manual Test:** As a developer, I want to paste a connection string into a textbox and click "Test" so I can verify credentials immediately.
* **File Test:** As a developer, I want to select an `appsettings.json` file so the app can automatically test all strings inside the `"ConnectionStrings"` object.
* **Feedback:** As a user, I want to see a clear **Success** (Green) or **Fail** (Red) status, with the specific SQL error message displayed upon failure.

---

## 3. Technical Stack
* **UI:** Windows Forms (.NET 8.0)
* **Library:** `Microsoft.Data.SqlClient`
* **Parser:** `System.Text.Json`

---

## 4. Functional Requirements

### Manual Validation
* **Input:** Multi-line Textbox.
* **Action:** Button "Test Connection".
* **Logic:** `SqlConnection.Open()` using the provided string.

### File Validation
* **Input:** File Picker (`.json` filter).
* **Logic:** Parse JSON -> Locate `"ConnectionStrings"` -> Iterate through Key/Value pairs.
* **Display:** A list or grid showing: **Name | Status | Error (if any)**.

---

## 5. UI Layout (Minimalist)
* **Top:** "Paste String" Textbox + "Test" Button.
* **Middle:** "Load appsettings.json" Button + File Path Label.
* **Bottom:** Results Grid / Status Label.

---

## 6. Reference Examples

### appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=a-server\\SQLEXPRESS;Initial Catalog=ACatalog;Persist Security Info=True;User ID=ausername;Password=a-password@;MultipleActiveResultSets=true;"
  }
}
