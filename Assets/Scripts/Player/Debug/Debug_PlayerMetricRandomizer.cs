using UnityEngine;

public class Debug_PlayerMetricRandomizer : IDebugCommandRegistrater
{

    public void RegisterCommand(IDebugCommandSystem debugCommandSystem)
    {
        var randomizePlayerMetrics = new DebugCommand(
            "randomize_player_metrics",
            "Randomizes player metrics for testing purposes.",
            "randomize_player_metrics",
            RandomizePlayerMetrics);

        debugCommandSystem.RegisterCommand(randomizePlayerMetrics);
    }

    private void RandomizePlayerMetrics()
    {
        var player = GameObject.FindWithTag("Player");

        if (player == null) return;

        var damageHandler = player.GetComponent<IDamageableHandler>();
        var manaHandler = player.GetComponent<PlayerManaHandler>();
        var gameMetrics = GameManager.Instance.GameMetrics;

        if (damageHandler != null)
        {
            var randomDamage = Random.Range(0, 100);
            damageHandler.AddDamage(randomDamage);
        }

        if (manaHandler != null)
        {
            var randomMana = Random.Range(0f, manaHandler.RemainingManaPercentage);
            manaHandler.ConsumeMana(randomMana);
        }

        if (gameMetrics != null)
        {
            var randomScore = Random.Range(0, 10000);
            gameMetrics.TotalScore = randomScore;
            var randomCombo = Random.Range(0, 50);
            gameMetrics.ComboHits = randomCombo;
        }
    }

}