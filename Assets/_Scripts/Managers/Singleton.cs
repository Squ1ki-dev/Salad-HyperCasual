using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance is null)
                {
                    GameObject newGo = new GameObject();
                    newGo.name = "TInstance";
                    _instance = newGo.AddComponent<T>();
                    DontDestroyOnLoad(newGo);
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake() => _instance = this as T;
}