using System;
using System.Collections.Generic;

public class FacialFeatures : IEquatable<FacialFeatures>
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public bool Equals(FacialFeatures other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((FacialFeatures)obj);
    }

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity : IEquatable<Identity>
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public bool Equals(Identity other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Email == other.Email && FacialFeatures.Equals(other.FacialFeatures);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Identity)obj);
    }

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private readonly HashSet<Identity> _registeredIdentities = new HashSet<Identity>();
    private readonly Identity _adminIdentity = new Identity(
        "admin@exerc.ism", 
        new FacialFeatures("green", 0.9m)
    );

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(_adminIdentity);

    public bool Register(Identity identity) => _registeredIdentities.Add(identity);

    public bool IsRegistered(Identity identity) => _registeredIdentities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);
}