using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"Collision Enter@{collision.gameObject.name}!");
    }
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log($"Collision Exit@{collision.gameObject.name}!");
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger !");
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 1.0f);
            LayerMask mask = LayerMask.GetMask("Monster", "Wall");
            if (Physics.Raycast(ray, out hit, 20, mask))
            {
                Debug.Log($"Raycast !{hit.collider.gameObject.tag}");
            }
        }

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //Vector3 dir = mousePos - Camera.main.transform.position;
        //dir.Normalize();


    }
}
