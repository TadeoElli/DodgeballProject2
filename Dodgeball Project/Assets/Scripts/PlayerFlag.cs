using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlag : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public bool hasTheFlag;
    [SerializeField] public GameObject flag;
    [SerializeField] private Material m_flag1, m_flag2;
    [SerializeField] private Renderer flagMaterial;

    void Start()
    {
        hasTheFlag = false;
        flagMaterial = flag.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GetTheFlag()
    {
        hasTheFlag = true;
        flag.SetActive(true);
        if(this.gameObject.layer == 6){
            flagMaterial.material = m_flag2;
        }
        else if(this.gameObject.layer == 7){
            flagMaterial.material = m_flag1;
        }
    }
    public void UseTheFlag()
    {
        hasTheFlag = false;
        flag.SetActive(false);
    }



}
