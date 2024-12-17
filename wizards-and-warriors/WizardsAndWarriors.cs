using System;

abstract class Character
{
    private string CharacterType { get; }

    protected Character(string characterType) => CharacterType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {CharacterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior") { }

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    private bool SpellPrepared { get; set; } = false;

    public Wizard() : base("Wizard") { }

    public override int DamagePoints(Character target) => SpellPrepared ? 12 : 3;

    public override bool Vulnerable() => !SpellPrepared;

    public void PrepareSpell() => SpellPrepared = true;
}
