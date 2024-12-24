using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Authenticator
{
    private static readonly IDictionary<string, Identity> DefaultDevelopers =
        new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = EyeColor.Blue
            },
            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = EyeColor.Brown
            }
        };

    private readonly Identity admin;
    private readonly IDictionary<string, Identity> developers;

    public Authenticator(Identity admin)
    {
        this.admin = admin;
        developers = new ReadOnlyDictionary<string, Identity>(DefaultDevelopers);
    }

    public Identity Admin => new Identity
    {
        Email = admin.Email,
        EyeColor = admin.EyeColor
    };

    public IDictionary<string, Identity> GetDevelopers() => developers;

    private static class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }
}

public struct Identity
{
    public string Email { get; set; }
    public string EyeColor { get; set; }
}
