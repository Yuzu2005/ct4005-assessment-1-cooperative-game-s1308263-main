using System;
using TMPro;
using UnityEngine;

public class FlamethrowerFuel : MonoBehaviour{

    [SerializeField] private TMP_Text fuelText;
    public GameObject fuelTextObject;
    
    [SerializeField] private float consumeRate = 2.0f;
    public float fuel = 100;
    public bool isActive;

    //Updates fuel consumtion every frame when using flamethrower
    private void Update() {
        TryGetComponent<Shoot>(out Shoot pickupCheck);
        if (pickupCheck.hasFlamePickup == true) {
            fuelTextObject.SetActive(true);
            fuelTextObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, fuelTextObject.transform.rotation.z * -1.0f);
            fuelText.SetText("Fuel: " + Math.Round(fuel, 2, MidpointRounding.AwayFromZero).ToString("0.0"));
        }
        FuelConsume();
    }

    //Sets comsume rate
    public void FuelConsume() {
        if (isActive == true) {
            fuel -= consumeRate;
            if (fuel <= 0) {
                fuel = 0;
                TryGetComponent<Shoot>(out Shoot flameStop);
                flameStop.hasFlamePickup = false;
                flameStop.FlamethrowerStop();
            }
        }
    }
}

//Script by Jacob
