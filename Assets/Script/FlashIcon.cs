using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashIcon : MonoBehaviour
{
    
    public Image IconImage;
    public float Cooldown;
    public bool isCooldown;
    public int FlashCharges;

    void Start()
    {
        IconImage.fillAmount = 0;
    }

    void Update()
    {
        Cooldown = GameObject.FindGameObjectWithTag("Kill").GetComponent<FlashController>().FinalCooldown;
        FlashCharges = GameObject.FindGameObjectWithTag("Kill").GetComponent<FlashController>().Charges;
        Flash();
    }

    void Flash()
    {
        if (Input.GetKey(KeyCode.F) && isCooldown == false && FlashCharges > 0)
        {
            isCooldown = true;
            IconImage.fillAmount = 1;
        }

        if (isCooldown)
        {
            IconImage.fillAmount -= 1 / Cooldown * Time.deltaTime;

            if (IconImage.fillAmount <= 0)
            {
                IconImage.fillAmount = 0;
                isCooldown = false;
            }

        }
    }
}
