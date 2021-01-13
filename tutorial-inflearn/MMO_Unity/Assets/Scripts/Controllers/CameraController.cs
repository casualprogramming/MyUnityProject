using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;
    [SerializeField]
    Vector3 _deltas = new Vector3(0.0f, 6.0f, -5.0f);
    [SerializeField]
    GameObject _player = null;
    void Start()
    {
        
    }

    void LateUpdate()//Ensure that this function runs after player controller update
    {
        if(_mode == Define.CameraMode.QuaterView)
        {
            transform.position = _player.transform.position + _deltas;
            transform.LookAt(_player.transform.position);
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuaterView;
        _deltas = delta;
    }
}
