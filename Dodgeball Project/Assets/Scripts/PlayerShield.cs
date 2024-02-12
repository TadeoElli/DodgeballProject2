using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
//using UnityEngine.InputSystem;

public class PlayerShield : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Shield")]
    public GameObject shield;
    [SerializeField] private ScriptableRendererFeature _fullScreenShield;
    void Start()
    {
        _fullScreenShield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShieldPowerUp(){
        shield.SetActive(true);
        _fullScreenShield.SetActive(true);
        Invoke("ShieldPowerUpEnd", 10f);
    }

    private void ShieldPowerUpEnd(){
        shield.SetActive(false);
        _fullScreenShield.SetActive(false);
    }
}
