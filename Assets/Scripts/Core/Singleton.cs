using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    [SerializeField]
    bool destroyOnLoad = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            if (!destroyOnLoad)
                DontDestroyOnLoad(gameObject);
            OnAwake();
        }
        else if (Instance != this)
            Destroy(gameObject);
    }

    protected virtual void OnAwake()
    {
    }
}
