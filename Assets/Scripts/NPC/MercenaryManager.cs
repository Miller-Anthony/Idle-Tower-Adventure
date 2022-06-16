using System.Collections;
using System.Collections.Generic;
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

    public BigNumber GetTotalStrength(float percent = 1.0f)
    {
        BigNumber holder = fighterStats.GetStrength();
        holder += barbarianStats.GetStrength();
        holder += rogueStats.GetStrength();
        holder += rangerStats.GetStrength();
        holder += monkStats.GetStrength();
        holder += clericStats.GetStrength();
        holder += bardStats.GetStrength();
        holder += wizzardStats.GetStrength();
        holder += warlockStats.GetStrength();
        holder += sorcererStats.GetStrength();
        holder += paladinStats.GetStrength();
        holder += druidStats.GetStrength();

        return holder * percent;
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
}
