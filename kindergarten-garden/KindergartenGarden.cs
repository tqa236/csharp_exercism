using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private static readonly Dictionary<char, Plant> PlantMapping = new Dictionary<char, Plant>
    {
        { 'V', Plant.Violets },
        { 'R', Plant.Radishes },
        { 'C', Plant.Clover },
        { 'G', Plant.Grass }
    };

    private static readonly string[] Students = new[]
    {
        "Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"
    };

    private readonly Dictionary<string, List<Plant>> _studentPlants;

    public List<Plant> this[string student] => _studentPlants.GetValueOrDefault(student, new List<Plant>());

    public KindergartenGarden(string diagram)
    {
        _studentPlants = new Dictionary<string, List<Plant>>();
        var rows = diagram.Split('\n');
        
        int maxStudents = rows[0].Length / 2;
        for (int i = 0; i < Math.Min(Students.Length, maxStudents); i++)
        {
            var plants = new List<Plant>
            {
                PlantMapping[rows[0][2 * i]],
                PlantMapping[rows[0][2 * i + 1]],
                PlantMapping[rows[1][2 * i]],
                PlantMapping[rows[1][2 * i + 1]]
            };
            _studentPlants[Students[i]] = plants;
        }
    }

    public IEnumerable<Plant> Plants(string student) => this[student];
}