public class GameLayers : SmartEnum
{

    public static GameLayers Default = new("Default", 0);
    public static GameLayers TransparentFX = new("TransparentFX", 1);
    public static GameLayers IgnoreRaycast = new("Ignore Raycast", 2);
    public static GameLayers Water = new("Water", 4);
    public static GameLayers UI = new("UI", 5);
    public static GameLayers Ground = new("Ground", 6);
    public static GameLayers Player = new("Player", 7);
    public static GameLayers Enemy = new("Enemy", 8);

    protected GameLayers(string name, int value) : base(name, value) { }

    public static implicit operator int(GameLayers layer)
        => layer.GetValue();

    public static implicit operator string(GameLayers layer)
        => layer.ToString();

}