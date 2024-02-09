using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform _transform;
    public float jumpForce;
    public FPSController player;
    public bool horizontal;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
            player = other.gameObject.GetComponent<FPSController>();
            if(horizontal)
            {
                player.SpeedTrampoline(jumpForce, -this.transform.forward);
            }
            else
            {
                player.JumpTrampoline(jumpForce);
            }
            

        }
        else if(other.gameObject.tag == "Ball")
        {
            if(horizontal)
            {
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(-_transform.forward * jumpForce * 10, ForceMode.Impulse);
            }
            else
            {
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(_transform.up * jumpForce * 10, ForceMode.Impulse);
            }

        }
    }
}
