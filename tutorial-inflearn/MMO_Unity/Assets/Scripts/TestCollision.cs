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
        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);
        RaycastHit hit;

        RaycastHit[] hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);
        foreach (var h in hits)
        {
            Debug.Log($"Raycast all !{h.collider.name}");
        }
        if (Physics.Raycast(transform.position + Vector3.up, look, out hit, 10))
        {
            
            //Debug.Log($"Raycast !{hit.collider.gameObject.name}");
        }
    }
}
