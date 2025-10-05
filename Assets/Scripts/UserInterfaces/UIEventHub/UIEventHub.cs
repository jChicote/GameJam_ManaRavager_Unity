using System;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHub : MonoBehaviour, IUIEventHub, IUIEventHubCollection
{

    public static UIEventHub Instance;

    private readonly Dictionary<string, Action> _uiActions = new();
    private readonly Dictionary<string, Action<object>> _uiActionsWithParam = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void TriggerEvent(string key)
    {
        if (!_uiActions.TryGetValue(key, out var action))
        {
            Debug.LogWarning($"No action found for key: {key}");
            return;
        }

        action?.Invoke();
    }

    public void TriggerEvent(string key, object param)
    {
        if (!_uiActionsWithParam.TryGetValue(key, out var action))
        {
            Debug.LogWarning($"No action found for key: {key}");
            return;
        }

        action?.Invoke(param);
    }

    public void RegisterEvent(string key, Action eventAction)
        => _uiActions.Add(key, eventAction);

    public void RegisterEvent(string key, Action<object> eventAction)
        => _uiActionsWithParam.Add(key, eventAction);

    public void UnRegisterEvent(string key)
    {
        if (_uiActions.ContainsKey(key))
            _uiActions.Remove(key);

        if (_uiActionsWithParam.ContainsKey(key))
            _uiActionsWithParam.Remove(key);
    }

}