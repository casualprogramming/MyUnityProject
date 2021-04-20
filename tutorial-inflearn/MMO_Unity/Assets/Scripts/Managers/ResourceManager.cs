﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private T Load<T> (string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent= null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if(prefab==null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        //rename display name
        GameObject go = Object.Instantiate(prefab, parent);
        int index = go.name.IndexOf("(Clone)");
        if(index > 0)
            go.name = go.name.Substring(0,index);
        return go;
    }

    public void Destory(GameObject go)
    {
        if (go == null)
            return;
        Object.Destroy(go);
    }
}
