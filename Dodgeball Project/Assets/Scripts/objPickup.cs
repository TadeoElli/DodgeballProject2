using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objPickup : MonoBehaviour
{
    public GameObject crosshair1, crosshair2;
    public Transform objTransform, cameraTrans;
    [SerializeField] private bool interactable, pickedup;
    [SerializeField] private Rigidbody objRigidbody;
    [SerializeField] private float throwAmount;

    private void Start() {
        objTransform = GetComponent<Transform>();
        objRigidbody = GetComponent<Rigidbody>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(pickedup == false)
            {
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
            }
            if (pickedup == true)
            {
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
                pickedup = false;
            }
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                objTransform.parent = cameraTrans;
                objRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                objRigidbody.useGravity = false;
                pickedup = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                objTransform.parent = null;
                objRigidbody.constraints = RigidbodyConstraints.None;
                objRigidbody.useGravity = true;
                pickedup = false;
            }
            if(pickedup == true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    objTransform.parent = null;
                    objRigidbody.constraints = RigidbodyConstraints.None;
                    objRigidbody.useGravity = true;
                    objRigidbody.velocity = cameraTrans.forward * throwAmount * Time.deltaTime;
                    pickedup = false;
                }
            }
        }
    }
}