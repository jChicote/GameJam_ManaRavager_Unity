public class GameTags : SmartEnum
{

    public static GameTags HitBox = new GameTags("HitBox", 0);

    protected GameTags(string name, int value) : base(name, value) { }

    public static implicit operator int(GameTags gameTag)
        => gameTag.GetValue();

    public static implicit operator string(GameTags gameTag)
        => gameTag.ToString();

}