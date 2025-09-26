# School Login System (WinForms, C#)

A Visual Studio WinForms project connected to SQL Server.

## Features
- **Login**: Student & Instructor authentication
- **Student Form**: Show midterm/final grades, compute average, compare to class average
- **Instructor Form**: Sort grades (ascending/descending) for midterm/final
- **Info Forms**: Curriculum, fees, and academic calendar displayed in DataGridView with text wrapping
- **Database**: `StudentInfo` table with `StudentNumber`, `MidtermGrade`, `FinalGrade`, and `Password`

## How to Run
1. Open `SchoolSystem.sln` in Visual Studio.
2. Restore NuGet packages (if any).
3. Update the SQL connection string in `App.config` if necessary.
4. Press **F5** to build and run.

## Technologies Used
- C# WinForms (.NET)
- SQL Server (`System.Data.SqlClient`)

## Notes
- Build artifacts (`bin/`, `obj/`, `.vs/`) are excluded with `.gitignore`.
- Example project for educational purposes.

