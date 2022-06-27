using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    [SerializeField] Button hasteButton;
    [SerializeField] Button increaseButton;
    [SerializeField] Button teleportButton;
    [SerializeField] Button autoButton;
    [SerializeField] Text hasteText;
    [SerializeField] Text increaseText;
    [SerializeField] Text teleportText;
    [SerializeField] Text autoText;
    [SerializeField] float hasteActive;
    [SerializeField] float increaseActive;
    [SerializeField] float teleportActive;
    [SerializeField] float autoActive;
    [SerializeField] float hasteCooldown;
    [SerializeField] float increaseCooldown;
    [SerializeField] float teleportCooldown;
    [SerializeField] float autoCooldown;

    private float hasteTimer;
    private float increaseTimer;
    private float teleportTimer;
    private float autoTimer;
    private bool hasteIsActive;
    private bool increaseIsActive;
    private bool teleportIsActive;
    private bool autoIsActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasteTimer > 0)
        {
            hasteTimer -= Time.deltaTime;

            if(hasteTimer <= 0)
            {
                if(hasteIsActive)
                {
                    hasteTimer = hasteCooldown;
                }
            }
            if(hasteTimer <= 0)
            {
                //update text to name of button
                hasteText.text = "haste";
            }
            else
            {
                //update text to timer
                hasteText.text = hasteTimer + "s";
            }
        }
        if (increaseTimer > 0)
        {
            increaseTimer -= Time.deltaTime;

            if (increaseTimer <= 0)
            {
                if (increaseIsActive)
                {
                    increaseTimer = increaseCooldown;
                }
            }
            if (increaseTimer <= 0)
            {
                //update text to name of button
                increaseText.text = "Increase";
            }
            else
            {
                //update text to timer
                increaseText.text = increaseTimer + "s";
            }
        }
        if (teleportTimer > 0)
        {
            teleportTimer -= Time.deltaTime;

            if (teleportTimer <= 0)
            {
                if (teleportIsActive)
                {
                    teleportTimer = teleportCooldown;
                }
            }
            if (teleportTimer <= 0)
            {
                //update text to name of button
                teleportText.text = "teleport";
            }
            else
            {
                //update text to timer
                teleportText.text = teleportTimer + "s";
            }
        }
        if (autoTimer > 0)
        {
            autoTimer -= Time.deltaTime;

            if (autoTimer <= 0)
            {
                if (autoIsActive)
                {
                    autoTimer = autoCooldown;
                }
            }
            if (autoTimer <= 0)
            {
                //update text to name of button
                autoText.text = "auto";
            }
            else
            {
                //update text to timer

                autoText.text = autoTimer + "s";
            }
        }
    }

    public void Activate(string name)
    {
        switch(name)
        {
            case "hastePotion":
                hasteButton.interactable = true;
                break;
            case "increasedBounty":
                increaseButton.interactable = true;
                break;
            case "teleport":
                teleportButton.interactable = true;
                break;
            case "autoSpawner":
                autoButton.interactable = true;
                break;
            default:
                break;
        }
    }

    public void OnClick()
    {
        switch (tag)
        {
            case "hastePotion":
                if(hasteTimer <= 0)
                {
                    hasteTimer = hasteActive;
                    hasteIsActive = true;
                }
                break;
            case "increasedBounty":
                if(increaseTimer <= 0)
                {
                    increaseTimer = increaseActive;
                    increaseIsActive = true;
                }
                break;
            case "teleport":
                if(teleportTimer <= 0)
                {
                    teleportTimer = teleportActive;
                    teleportIsActive = true;
                }
                break;
            case "autoSpawner":
                if(autoTimer <= 0)
                {
                    autoTimer = autoActive;
                    autoIsActive = true;
                }                
                break;
            default:
                break;
        }
    }
}
