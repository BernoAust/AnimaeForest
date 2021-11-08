using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashController : MonoBehaviour
{

    private Collider2D FlashArea;
    public float FlashCooldown = 0f;
    public float FinalCooldown;
    public float Cooldown = 5f;
    public float CooldownMultiplier = 1f;
    public int Charges = 0;
    private Light2D Flash;
    public float FlashEffect = 0.5f;
    public BatteryBar BatteryBar;

    void Start()
    {
        FlashArea = GetComponent<Collider2D>();
        FlashArea.enabled = false;
        Flash = GetComponent<Light2D>();
        Flash.enabled = false;
        BatteryBar = GameObject.FindGameObjectWithTag("BatteryBar").GetComponent<BatteryBar>();
        BatteryBar.SetMaxBattery(5);
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            FlashUse();
        }

        FinalCooldown = Cooldown * CooldownMultiplier;
        BatteryBar.SetBattery(Charges);

    }

    void FlashUse()
    {
        if(FlashCooldown <= 0 && Charges > 0)
        {
            FlashArea.enabled = true;
            Flash.enabled = true;
            Charges -= 1;
            StartCoroutine(FlashlightCD());
            StartCoroutine(FlashlightEffect());
        }
    }
    IEnumerator FlashlightCD()
    {
        FlashCooldown = 5;
        yield return new WaitForSeconds(FinalCooldown);
        FlashCooldown = 0;
    }

    IEnumerator FlashlightEffect()
    {
        FlashArea.enabled = true;
        Flash.enabled = true;
        yield return new WaitForSeconds(FlashEffect);
        FlashArea.enabled = false;
        Flash.enabled = false;
    }

}
