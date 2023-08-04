using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
    [SerializeField] float hasteActiveTime;
    [SerializeField] float increaseActiveTime;
    [SerializeField] float teleportActiveTime;
    [SerializeField] float autoActiveTime;
    [SerializeField] float hasteCooldown;
    [SerializeField] float increaseCooldown;
    [SerializeField] float teleportCooldown;
    [SerializeField] float autoCooldown;
    [SerializeField] LootTracker loot;

    //stored timer values
    private float hasteTimer;
    private float increaseTimer;
    private float teleportTimer;
    private float autoTimer;
    public bool hasteIsActive = false;
    public bool increaseIsActive = false;
    public bool teleportIsActive = false;
    public bool autoIsActive = false;

    //stored power effect values
    private float hasteRate;
    private float hasteSpeed;
    private float bountyRate;
    private float teleportRate;
    private float teleportBoost = 1.2f;
    private int autoLimit;
    private int autoPerSecond;

    //level of the upgrade
    private int hasteLevel = 0;
    private int bountyLevel = 0;
    private int teleportLevel = 0;
    private int autoLevel = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasteTimer > 0)
        {
            hasteTimer -= Time.deltaTime;

            if (hasteTimer <= 0)
            {
                if (hasteIsActive)
                {
                    hasteTimer = hasteCooldown * (float)(loot.GetController("alchemyKit").GetTotalBonus() / new BigInteger(100));
                    hasteIsActive = false;
                }
            }
            if (hasteTimer <= 0)
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
                    increaseTimer = increaseCooldown * (float)(loot.GetController("ringOfWishes").GetTotalBonus() / new BigInteger(100));
                    increaseIsActive = false;
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
                    teleportTimer = teleportCooldown * (float)(loot.GetController("manaPotion").GetTotalBonus() / new BigInteger(100));
                    teleportIsActive = false;
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
                    autoTimer = autoCooldown * (float)(loot.GetController("summonersRobe").GetTotalBonus() / new BigInteger(100));
                    autoIsActive = false;
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

    public void SetHasteRate(float rate)
    {
        hasteRate = rate;
    }

    public float GetHasteRate()
    {
        if(hasteIsActive)
        {
            return hasteRate * (float)(loot.GetController("highQualityIngredients").GetTotalBonus() / new BigInteger(100));
        }
        return 1.0f;
    }

    public void SetHasteSpeed(float speed)
    {
        hasteSpeed = speed;
    }

    public float GetHasteSpeed()
    {
        if (hasteIsActive)
        {
            return hasteSpeed;
        }
        return 1.0f;
    }

    public void SetBountyRate(float rate)
    {
        bountyRate = rate;
    }

    public float GetBountyRate()
    {
        if(increaseIsActive)
        {
            return bountyRate * (float)(loot.GetController("glovesOfMidas").GetTotalBonus() / new BigInteger(100));
        }
        return 1.0f;
    }

    public void SetTeleportRate(float rate)
    {
        teleportRate = rate;
    }

    public float GetTeleportRate()
    {
        return teleportRate * (float)(loot.GetController("tomeOfIntelegence").GetTotalBonus() / new BigInteger(100));
    }

    public float GetTeleportBoost()
    {
        if (teleportIsActive)
        {
            return teleportBoost;
        }
        return 1.0f;
    }

    public void SetAutoLimit(int limit)
    {
        autoLimit = limit * (int)(loot.GetController("summonersStaff").GetTotalBonus() / new BigInteger(100));
    }

    public int GetAutoLimit()
    {
        if(autoIsActive)
        {
            return autoLimit;
        }
        return 0;
    }

    public void SetAutoPerSecond(int ps)
    {
        autoPerSecond = ps;  
    }

    public int GetAutoPerSecond()
    {
        return autoPerSecond * (int)(loot.GetController("summonersStaff").GetTotalBonus() / new BigInteger(100));
    }

    public int GetHasteLevel()
    {
        return hasteLevel;
    }

    public int GetBountyLevel()
    {
        return bountyLevel;
    }

    public int GetTeleportLevel()
    {
        return teleportLevel;
    }

    public int GetAutoLevel()
    {
        return autoLevel;
    }

    public void Activate(string name)
    {
        switch (name)
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

    public void LevelUp(string name)
    {
        switch (name)
        {
            case "hastePotion":
                if(hasteLevel == 0)
                {
                    hasteRate = 1.05f;
                    hasteSpeed = 1.6f;
                    Activate(name);
                }
                else
                {
                    hasteRate += 0.04f;
                }
                hasteLevel++;
                break;
            case "increasedBounty":
                if (bountyLevel == 0)
                {
                    bountyRate = 1.05f;
                    Activate(name);
                }
                else
                {
                    bountyRate += 0.04f;
                }
                bountyLevel++;
                break;
            case "teleport":
                if (teleportLevel == 0)
                {
                    teleportRate = 1.0f;
                    Activate(name);
                }
                else
                {
                    teleportRate += 0.04f;
                }
                teleportLevel++;
                break;
            case "autoSpawner":
                if (autoLevel == 0)
                {
                    autoLimit = 20;
                    autoPerSecond = 4;
                    Activate(name);
                }
                else
                {
                    autoLimit += 10;
                    autoPerSecond += 1;
                }
                autoLevel++;
                break;
            default:
                break;
        }
    }

    public void Clicked(string name)
    {
        switch (name)
        {
            case "hastePotion":
                if (hasteTimer <= 0)
                {
                    hasteTimer = hasteActiveTime * (float)(loot.GetController("largeVial").GetTotalBonus() / new BigInteger(100));
                    hasteIsActive = true;
                }
                break;
            case "increasedBounty":
                if (increaseTimer <= 0)
                {
                    increaseTimer = increaseActiveTime * (float)(loot.GetController("amuletOfTime").GetTotalBonus() / new BigInteger(100));
                    increaseIsActive = true;
                }
                break;
            case "teleport":
                if (teleportTimer <= 0)
                {
                    teleportTimer = teleportActiveTime * (float)(loot.GetController("magicFocus").GetTotalBonus() / new BigInteger(100));
                    teleportIsActive = true;
                }
                break;
            case "autoSpawner":
                if (autoTimer <= 0)
                {
                    autoTimer = autoActiveTime * (float)(loot.GetController("summonersRing").GetTotalBonus() / new BigInteger(100));
                    autoIsActive = true;
                }
                break;
            default:
                break;
        }
    }
}
