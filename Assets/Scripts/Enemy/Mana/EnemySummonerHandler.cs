using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySummonerHandler : MonoBehaviour
{

    public EnemyManaHandler ManaHandler;
    public NavMeshAgent Agent;
    public float SummoningRadius = 15f;
    public float SpawnRadius = 5f;
    public int MaxSpawnCount = 6;

    public float PawnSpawnCost = 0.5f;
    public GameObject PawnPrefab;
    public List<GameObject> SpawnedPawns = new List<GameObject>();

    private Vector3 _selectedDestination = Vector3.zero;

    public void SummonPawns()
    {
        // Get location in NavMesh
        _selectedDestination = GetRandomPointOnNavMesh(Agent.transform.position, SummoningRadius);

        // Spawn variable size of pawns
        var calculatedSpawnCount = ManaHandler.CurrentMana >= PawnSpawnCost
            ? Mathf.FloorToInt(ManaHandler.CurrentMana / PawnSpawnCost)
            : 0;

        for (int i = 0; i < calculatedSpawnCount; i++)
        {
            var spawnPosition = GetRandomPointOnNavMesh(_selectedDestination, SpawnRadius);
            var spawnedPawn = Instantiate(PawnPrefab, spawnPosition, Quaternion.identity);

            SpawnedPawns.Add(spawnedPawn);
            ManaHandler.UseMana(PawnSpawnCost);
        }
    }

    private Vector3 GetRandomPointOnNavMesh(Vector3 sourcePosition, float spawnRadius)
    {
        var randomDirection = Random.insideUnitSphere * spawnRadius + sourcePosition;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit navHit, spawnRadius, NavMesh.AllAreas))
            return navHit.position;

        return Agent.transform.position;
    }

}