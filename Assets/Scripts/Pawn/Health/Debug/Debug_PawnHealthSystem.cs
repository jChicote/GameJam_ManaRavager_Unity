using UnityEngine;

public class Debug_PawnHealthSystem : IDebugCommandRegistrater
{

    public void RegisterCommand(IDebugCommandSystem debugCommandSystem)
    {
        var addDamataToNearbyEnemyPawns = new DebugCommand(
            "add_damage_to_nearby_enemies",
            "Casts damage to nearby enemies from objects belonging to 'Player'",
            "add_damage_to_nearby_enemies",
            AddDamageToNearbyEnemyPawns);

        debugCommandSystem.RegisterCommand(addDamataToNearbyEnemyPawns);
    }

    private void AddDamageToNearbyEnemyPawns()
    {
        // Find nearest enemy pawn from 'Player' collision object
        var players = GameObject.FindGameObjectsWithTag("Player");
        if (players == null || players.Length == 0) return;

        var enemyLayerMask = 1 << GameLayers.Enemy;

        // Add damage to nearest pawn within radius of each player object
        foreach (var player in players)
        {
            var colliders = new Collider[5]; // No need to include all enemies for testing
            var numberOfColliders = Physics.OverlapSphereNonAlloc(player.transform.position, 10f, colliders, enemyLayerMask);
            for (var i = 0; i < numberOfColliders; i++)
            {
                var enemyDamage = colliders[i].GetComponentInParent<IDamageableHandler>();
                enemyDamage?.AddDamage(40f);

                Debug.Log("Applied damage to: " + colliders[i].gameObject.name);
            }
        }
    }

}