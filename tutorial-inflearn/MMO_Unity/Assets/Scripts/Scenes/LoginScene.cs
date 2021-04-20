using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    public override void Clear()
    {
    }
    protected override void init()
    {
        base.init();
        SceneType = Define.Scene.Login;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            //SceneManager.LoadScene("Game");
            SceneManager.LoadSceneAsync("Game");
        }
    }
}
