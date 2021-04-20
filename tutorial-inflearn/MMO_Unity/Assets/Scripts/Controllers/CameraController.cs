using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;
    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);
    [SerializeField]
    GameObject _player = null;

    void LateUpdate()//Ensure that this function runs after player controller update
    {
        if(_mode == Define.CameraMode.QuaterView)
        {
            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position, _delta, out hit,_delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + dist * _delta.normalized;
                //ex) camera move smooth
                //transform.position = Vector3.Slerp(transform.position, _player.transform.position + dist * _delta.normalized, 0.01f);
            }
            else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform.position);
                //ex) camera move smooth
                //transform.position = Vector3.Slerp(transform.position, _player.transform.position + _delta, 0.01f);
                //Vector3 dir = (_player.transform.position- transform.position).normalized;
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            }
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuaterView;
        _delta = delta;
    }
}
