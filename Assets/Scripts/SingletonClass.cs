using UnityEngine;

public class SingletonClass<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null) instance = this as T;
        else Destroy(gameObject);
    }
}
