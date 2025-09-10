using System;
using UnityEngine;

public class GameMetrics : MonoBehaviour
{

    public int TotalScore { get; set; }

    public int ComboHits { get; set; }

    public event Action<int> OnTotalScoreChanged;

    public event Action<int> OnComboHitsChanged;

}