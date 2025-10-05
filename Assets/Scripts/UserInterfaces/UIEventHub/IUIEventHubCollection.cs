using System;

public interface IUIEventHubCollection
{

    void RegisterEvent(string key, Action eventAction);
    void RegisterEvent(string key, Action<object> eventAction);
    void UnRegisterEvent(string key);

}