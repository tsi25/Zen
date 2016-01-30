using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    protected Dictionary<System.Type, object> singletons = new Dictionary<System.Type, object>();

    protected static GameManager instance = null;

    public static GameManager Instance
    {
        get { return (instance != null) ? instance : instance = FindObjectOfType<GameManager>(); }
    }


    public static T Retrieve<T>() where T : class
    {
        System.Type t = typeof(T);
        T singleton = null;
        if (Instance.singletons.ContainsKey(t))
        {
            singleton = Instance.singletons[t] as T;
        }
        else
        {
            singleton = Instance.GetComponentInChildren<T>();
            Instance.singletons.Add(t, singleton);
        }

        return singleton;
    }
}
