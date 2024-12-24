using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly Dictionary<int, List<string>> _studentsByGrade = new Dictionary<int, List<string>>();

    public bool Add(string student, int grade)
    {
        if (_studentsByGrade.Values.Any(students => students.Contains(student)))
        {
            return false;
        }

        if (!_studentsByGrade.ContainsKey(grade))
        {
            _studentsByGrade[grade] = new List<string>();
        }

        _studentsByGrade[grade].Add(student);
        _studentsByGrade[grade].Sort();
        return true;
    }

    public IEnumerable<string> Roster() => _studentsByGrade
            .OrderBy(g => g.Key)
            .SelectMany(g => g.Value)
            .ToList();

    public IEnumerable<string> Grade(int grade) => _studentsByGrade.ContainsKey(grade) ? _studentsByGrade[grade] : new List<string>();
}