using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControllerRigidbody : MonoBehaviour
{
    [SerializeField]  private Transform mainCamera;
    [SerializeField] private float sesitivity;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float moveForce;
    [SerializeField] private float maxMoveSpeed;

    [SerializeField] private GameObject checkSphere;
    [SerializeField] private float checkSphereRadius;
    [SerializeField] private LayerMask grounLayerMask;
    [SerializeField] private float jumpForce;

    private bool grounded;
    private float pitch;
    private float yaw;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxisRaw("Mouse X") * sesitivity;
        pitch -= Input.GetAxisRaw("Mouse Y") * sesitivity;

        transform.localRotation = Quaternion.Euler(0, yaw, 0);
        mainCamera.localRotation = Quaternion.Euler(pitch, 0, 0);

        grounded = Physics.CheckSphere(checkSphere.transform.position, checkSphereRadius, grounLayerMask);
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    private void FixedUpdate() {
        _rigidbody.AddRelativeForce(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * moveForce);

        Vector3 vel = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        _rigidbody.AddForce(-vel * (moveForce / maxMoveSpeed), ForceMode.Acceleration);
    }
}
