using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPartiicles : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ParticleSystem explosionVFX;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Ball"){
            explosionVFX.Play();
            Debug.Log("Explosion");
        }
    }
}
