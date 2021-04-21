using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance = null;
    static Managers instance {get{ init();return s_instance;}}

    InputManager input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    SceneManagerEx _scene = new SceneManagerEx();
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();
    public static InputManager Input { get { return instance.input; } }
    public static ResourceManager Resource { get { return instance._resource; } }
    public static SceneManagerEx Scene { get { return instance._scene; } }
    public static UIManager UI { get { return instance._ui; } }
    public static SoundManager Sound { get { return instance._sound;} }

    void Update()
    {
        input.OnUpdate();
    }

    static void init()
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

            s_instance._sound.init();
        }
    }
}
