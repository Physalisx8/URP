using UnityEngine;
// Info:    Treats 3D objects like buttons
// Ref:     https://www.youtube.com/watch?v=Ova7l0UB26U

// Once per scene
#region Singleton
public class Singleton<T> : MonoBehaviour where T : Component
{
    static T _instance; // keeping track of instance in this class

    public static T Instance
    {
        // when called it will go through get
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                obj.hideFlags = HideFlags.HideAndDontSave;
                _instance = obj.AddComponent<T>();
            }
            return _instance;
        }
    }

    private void OnDestroy()
    {
        if (_instance != this)
        {
            _instance = null;
        }
    }
}
#endregion

#region Example Use
/* SINGLETON CLASS
 * public class ClassName : Singleton<ClassName> {
 * 
 * ... Do Stuff
 * 
 * }
 */
#endregion

// Throughout Scenes.
// IMPORTANT: You need to override Awake functions in your script.
#region Singleton Persistant
public class SingletonPersistent<T> : MonoBehaviour where T : Component
{
    static T _instance; // keeping track of instance in this class

    public static T Instance
    {
        // when called it will go through get
        get { return _instance; }
    }

    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        if (_instance != this)
        {
            _instance = null;
        }
    }
}
#endregion

#region Example Use
/*
 * public class ClassName : SingletonPersistent<ClassName> {
 * 
 *  public override void Awake() 
 *  {
 *      base.Awake();
 *      
 *      ... Do Stuff
 *  }
 * }
 */
#endregion
