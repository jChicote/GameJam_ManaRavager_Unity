using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySummonerHandler : MonoBehaviour
{

    [Header("References")]
    public EnemyManaHandler ManaHandler;
    public NavMeshAgent Agent;
    public GameObject PawnPrefab;

    [Header("Settings")]
    public float SummoningRadius = 15f;
    public float SpawnRadius = 5f;
    public int MaxSpawnCount = 6;
    public float PawnSpawnCost = 0.5f;

    private List<GameObject> SpawnedPawns = new List<GameObject>();
    private Vector3 _selectedDestination = Vector3.zero;

    public void SummonPawns()
    {
        // Get location in NavMesh
        _selectedDestination = GetRandomPointOnNavMesh(Agent.transform.position, SummoningRadius);

        // Spawn variable size of pawns
        var calculatedSpawnCount = ManaHandler.CurrentMana >= PawnSpawnCost
            ? Mathf.Clamp(Mathf.FloorToInt(ManaHandler.CurrentMana / PawnSpawnCost), 1, MaxSpawnCount)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_selectedDestination, SpawnRadius);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Agent.transform.position, SummoningRadius);
    }

}