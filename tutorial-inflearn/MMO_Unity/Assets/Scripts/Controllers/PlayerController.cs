using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed=0;
    [SerializeField]
    float _rspped=5;
    
    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;//if exist, erase first
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
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
        var mix = Time.deltaTime * _rspped;

        //ex) 
        if (W())
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), mix);
        if (S())
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), mix);
        if (A())
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), mix);
        if (D())
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), mix);

        if (W() || A() || S() || D())
        {
            //ex0) move position given direction
            Vector3 dir = W() ? Vector3.forward : S() ? Vector3.back : A() ? Vector3.left : D() ? Vector3.right : new Vector3(0, 0, 0);
            transform.position += dir * Time.deltaTime * _speed;
            //ex1) move position toward direction of looking 
            //Vector3 dir = transform.rotation * Vector3.forward;
            //transform.position += dir * Time.deltaTime * _speed;
            //ex2) move position toward direction of looking (translate)
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);//Translation multiply after Rotation (T*R*pos), so Translate to the forward direction, it goes that direction
        }

        //if (Input.GetKey(KeyCode.W))
        //    transform.Translate(Vector3.forward   * Time.deltaTime * _speed);
        //if (Input.GetKey(KeyCode.S))
        //    transform.Translate(Vector3.back      * Time.deltaTime * _speed);
        //if (Input.GetKey(KeyCode.A))
        //    transform.Translate(Vector3.left      * Time.deltaTime * _speed);
        //if (Input.GetKey(KeyCode.D))
        //    transform.Translate(Vector3.right     * Time.deltaTime * _speed);
    }
}
