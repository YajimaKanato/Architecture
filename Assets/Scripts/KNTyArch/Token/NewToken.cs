using KNTyArch.Runtime;

public readonly struct NewToken : IToken
{
    public readonly string ID;

    public NewToken(string id)
    {
        ID = id;
    }
}