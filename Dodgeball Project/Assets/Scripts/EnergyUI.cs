using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    // Start is called before the first frame update
    public FPSController reference;
    private Image slider;
    void Start()
    {
        slider = this.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.fillAmount = reference.boostEnergy / 100;
    }
}
