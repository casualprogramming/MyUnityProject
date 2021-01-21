using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed=0;

    Vector3 _dstPos;
 
    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
        Channeling,
        Jumping,
        Falling,
    }

    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }
    delegate bool myCheck();
    myCheck W = () => { return Input.GetKey(KeyCode.W); };
    myCheck S = () => { return Input.GetKey(KeyCode.S); };
    myCheck A = () => { return Input.GetKey(KeyCode.A); };
    myCheck D = () => { return Input.GetKey(KeyCode.D); };

    float wait_run_ratio = 0.0f;

    PlayerState _state = PlayerState.Idle;
    void UpdateDie()
    { }
    void UpdateMoving()
    {
        Vector3 dir = _dstPos - transform.position;
        if (dir.magnitude < 0.00001f)//@warning: The solution of the equation oscillates
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }

        //animation
        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10 * Time.deltaTime);
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("wait_run_ratio", wait_run_ratio);
        anim.Play("WAIT_RUN");
    }

    void UpdateIdle()
    {
        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10 * Time.deltaTime);
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("wait_run_ratio", wait_run_ratio);
        anim.Play("WAIT_RUN");
    }
    void Update()
    {
        switch(_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }

    }
    
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 1.0f);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20, LayerMask.GetMask("Wall")))
        {
            _dstPos = hit.point;
            _state = PlayerState.Moving;
        }
    }
}
