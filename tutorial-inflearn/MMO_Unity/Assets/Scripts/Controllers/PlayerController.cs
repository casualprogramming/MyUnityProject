using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed=0;
    [SerializeField]
    float _rspped=5;

    bool _moveToDst = false;
    Vector3 _dstPos;
    
    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;//if exist, erase first
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }
    delegate bool myCheck();
    myCheck W = () => { return Input.GetKey(KeyCode.W); };
    myCheck S = () => { return Input.GetKey(KeyCode.S); };
    myCheck A = () => { return Input.GetKey(KeyCode.A); };
    myCheck D = () => { return Input.GetKey(KeyCode.D); };
    
    //GameObject (Player)
    // Transform
    // PlayerController
    void Update()
    {
        if(_moveToDst)
        {
            Vector3 dir = _dstPos - transform.position;
            if(dir.magnitude<0.00001f)//@warning: The solution of the equation oscillates
            {
                _moveToDst = false;
            }
            else
            {
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
                transform.position += dir.normalized * moveDist;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            }
        }
    }
    void OnKeyboard()
    {
        // transform : transform of attatched GameObject
        // .TransformDirection : Local -> World
        // .normalize, .magnitude

        //transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);//automatic 360 clamp with c# set method
        //The value related to rotate is defined as only one quaternion, and the get set method of eulerAngles changes that value. (maybe)

        //ex) Ratate euler angle
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * _speed, 0.0f));
        if(W()| S()| A()| D()) 
        {
            var mix = Time.deltaTime * _rspped;
            Vector3 dir = new Vector3(0, 0, 0);
            if (W()) dir += Vector3.forward;
            if (S()) dir += Vector3.back;
            if (A()) dir += Vector3.left;
            if (D()) dir += Vector3.right;
            dir.Normalize();

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), mix);
            transform.position += dir * Time.deltaTime * _speed;
            _moveToDst = false;
        }
        //    //ex1) move position toward direction of looking 
        //    //Vector3 dir = transform.rotation * Vector3.forward;
        //    //transform.position += dir * Time.deltaTime * _speed;
        //    //ex2) move position toward direction of looking (translate)
        //    //transform.Translate(Vector3.forward * Time.deltaTime * _speed);//Translation multiply after Rotation (T*R*pos), so Translate to the forward direction, it goes that direction
    }
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;
        Debug.Log("OnMouseClicked");

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 1.0f);
        if (Physics.Raycast(ray, out hit, 20, LayerMask.GetMask("Wall")))
        {
            _dstPos = hit.point;
            _moveToDst = true;
        }
    }
}
