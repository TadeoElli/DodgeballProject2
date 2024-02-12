using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider collider;
    [SerializeField] private Renderer my_render1, my_render2;
    [SerializeField] private Material my_material1, my_material2, invisible_material;
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DesactivatePowerUp(){
        collider.enabled = false;
        my_render1.material = invisible_material;
        my_render2.material = invisible_material;
        Invoke("ActivatePowerUp", 10f);
    }

    private void ActivatePowerUp(){
        collider.enabled = true;
        my_render1.material = my_material1;
        my_render2.material = my_material2;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            other.GetComponentInParent<PlayerShield>().ShieldPowerUp();
            DesactivatePowerUp();
        }
    }
}
