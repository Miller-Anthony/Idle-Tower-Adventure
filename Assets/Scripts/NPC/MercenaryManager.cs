using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MercenaryManager : MonoBehaviour
{
    [SerializeField] GeneralStats general;
    [SerializeField] StatStorrage fighterStats;
    [SerializeField] StatStorrage barbarianStats;
    [SerializeField] StatStorrage rogueStats;
    [SerializeField] StatStorrage rangerStats;
    [SerializeField] StatStorrage monkStats;
    [SerializeField] StatStorrage clericStats;
    [SerializeField] StatStorrage bardStats;
    [SerializeField] StatStorrage wizzardStats;
    [SerializeField] StatStorrage warlockStats;
    [SerializeField] StatStorrage sorcererStats;
    [SerializeField] StatStorrage paladinStats;
    [SerializeField] StatStorrage druidStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BigInteger GetTotalStrength(float percent = 1.0f)
    {
        BigInteger holder = new BigInteger(0);

        if (fighterStats.GetLevel() > 0)
        {
            holder += fighterStats.GetStrength();
        }

        if (barbarianStats.GetLevel() > 0)
        {
            holder += barbarianStats.GetStrength();
        }

        if (rogueStats.GetLevel() > 0)
        {
            holder += rogueStats.GetStrength();
        }

        if (rangerStats.GetLevel() > 0)
        {
            holder += rangerStats.GetStrength();
        }

        if (monkStats.GetLevel() > 0)
        {
            holder += monkStats.GetStrength();
        }

        if (clericStats.GetLevel() > 0)
        {
            holder += clericStats.GetStrength();
        }

        if (bardStats.GetLevel() > 0)
        {
            holder += bardStats.GetStrength();
        }

        if (wizzardStats.GetLevel() > 0)
        {
            holder += wizzardStats.GetStrength();
        }

        if (warlockStats.GetLevel() > 0)
        {
            holder += warlockStats.GetStrength();
        }

        if (sorcererStats.GetLevel() > 0)
        {
            holder += sorcererStats.GetStrength();
        }

        if (paladinStats.GetLevel() > 0)
        {
            holder += paladinStats.GetStrength();
        }

        if (druidStats.GetLevel() > 0)
        {
            holder += druidStats.GetStrength();
        }

        return holder * (BigInteger)percent;
    }

    public float GetSpawnPercent()
    {
        return fighterStats.GetSpawnPercent();
    }

    public void ChangeSpawnTime(float change)
    {
        fighterStats.ChangeSpawnPercent(change);
        barbarianStats.ChangeSpawnPercent(change);
        rogueStats.ChangeSpawnPercent(change);
        rangerStats.ChangeSpawnPercent(change);
        monkStats.ChangeSpawnPercent(change);
        clericStats.ChangeSpawnPercent(change);
        bardStats.ChangeSpawnPercent(change);
        wizzardStats.ChangeSpawnPercent(change);
        warlockStats.ChangeSpawnPercent(change);
        sorcererStats.ChangeSpawnPercent(change);
        paladinStats.ChangeSpawnPercent(change);
        druidStats.ChangeSpawnPercent(change);
    }

    public float GetGearPercent()
    {
        return fighterStats.GetGearPercent();
    }

    public void ChangeGearValue(float change)
    {
        fighterStats.ChangeGearPercent(change);
        barbarianStats.ChangeGearPercent(change);
        rogueStats.ChangeGearPercent(change);
        rangerStats.ChangeGearPercent(change);
        monkStats.ChangeGearPercent(change);
        clericStats.ChangeGearPercent(change);
        bardStats.ChangeGearPercent(change);
        wizzardStats.ChangeGearPercent(change);
        warlockStats.ChangeGearPercent(change);
        sorcererStats.ChangeGearPercent(change);
        paladinStats.ChangeGearPercent(change);
        druidStats.ChangeGearPercent(change);
    }
}
