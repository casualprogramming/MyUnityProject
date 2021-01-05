using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance = null;
    static Managers instance 
    {
        get
        {
            if (!s_instance)
            {
                GameObject mgr = GameObject.Find("@Managers");
                if (!mgr)
                {
                    mgr = new GameObject { name = "@Managers" };
                    mgr.AddComponent<Managers>();
                }
                DontDestroyOnLoad(mgr);
                s_instance = mgr.GetComponent<Managers>();
            }
            return s_instance;
        }
    }
    InputManager input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    public static InputManager Input { get { return instance.input; } }
    public static ResourceManager Resource { get { return instance._resource; } }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input.OnUpdate();
    }

}
