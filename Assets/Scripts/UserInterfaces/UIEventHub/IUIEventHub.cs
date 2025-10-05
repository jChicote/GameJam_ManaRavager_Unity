public interface IUIEventHub
{

    void TriggerEvent(string key);
    void TriggerEvent(string key, object param);

}