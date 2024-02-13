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
    private bool isEnding = false;
    private float timer = 0f;
    [SerializeField] private ScriptableRendererFeature _fullScreenShield;
    [SerializeField] private Material fullScreenShield_Material;

    void Start()
    {
        _fullScreenShield.SetActive(false);
        fullScreenShield_Material.SetFloat("_LerpEndings", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnding){
            timer = timer + 0.5f * Time.deltaTime;
            fullScreenShield_Material.SetFloat("_LerpEndings", timer);
        }
    }

    public void ShieldPowerUp(){
        shield.SetActive(true);
        _fullScreenShield.SetActive(true);
        Invoke("ShieldPowerUpEnd", 10f);
        Invoke("StartEnding", 8f);
    }

    private void StartEnding(){
        isEnding = true;
    }
    private void ShieldPowerUpEnd(){
        shield.SetActive(false);
        fullScreenShield_Material.SetFloat("_LerpEndings", 0f);
        timer  = 0f;
        isEnding = false;
        _fullScreenShield.SetActive(false);
    }
}
