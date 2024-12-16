using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string departmentLabel = department == null ? "OWNER" : department.ToUpper();
        return id.HasValue 
            ? $"[{id}] - {name} - {departmentLabel}"
            : $"{name} - {departmentLabel}";
    }
}
