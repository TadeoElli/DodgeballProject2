using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] public Material originMaterial, invisibleMaterial;
    [SerializeField] private Renderer myRenderer;
    [SerializeField] private ParticleSystem goal;
    [SerializeField] public bool hasFlag;
    [SerializeField] private Flag otherTeamFlag;

    [SerializeField] private PlayerFlag playerFlag;
    
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();   
        hasFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {

        if(this.gameObject.layer == 6)
        {
            if(other.TryGetComponent<PlayerFlag>(out PlayerFlag playerFlag))
            {
                if(other.gameObject.layer == 7)
                {
                    if(hasFlag){
                        hasFlag = false;
                        myRenderer.material = invisibleMaterial;
                        playerFlag.GetTheFlag();
                        Debug.Log("Perdi la bandera violeta");
                    }
                }
                else if(other.gameObject.layer == 6)
                { 
                    if(playerFlag.hasTheFlag)
                    {
                        if(playerFlag.flag.GetComponent<Renderer>().material == originMaterial){
                            hasFlag = true;
                            myRenderer.material = originMaterial;
                            playerFlag.UseTheFlag();
                            Debug.Log("Recupere la bandera violeta");
                        }
                        else{
                            Debug.Log("Explotion");
                            goal.Play();
                            playerFlag.UseTheFlag();
                            otherTeamFlag.GetANewFlag();
                        }
                    }
                }
            }
        }
        if(this.gameObject.layer == 7)
        {
            if(other.TryGetComponent<PlayerFlag>(out PlayerFlag playerFlag))
            {
                if(other.gameObject.layer == 6)
                {
                    if(hasFlag){
                        hasFlag = false;
                        myRenderer.material = invisibleMaterial;
                        playerFlag.GetTheFlag();
                        Debug.Log("Perdi la bandera Verde");
                    }
                }
                else if(other.gameObject.layer == 7)
                {
                    if(playerFlag.hasTheFlag)
                    {
                        if(playerFlag.flag.GetComponent<Renderer>().material == originMaterial){
                            hasFlag = true;
                            myRenderer.material = originMaterial;
                            playerFlag.UseTheFlag();
                            Debug.Log("Recupere la bandera verde");
                        }
                        else{
                            goal.Play();
                            Debug.Log("Explotion");
                            playerFlag.UseTheFlag();
                            otherTeamFlag.GetANewFlag();
                        }
                    }
                }
            }
        }
    }

    public void GetANewFlag()
    {
        hasFlag = true;
        myRenderer.material = originMaterial;
        Debug.Log("Punto");
    }
}
