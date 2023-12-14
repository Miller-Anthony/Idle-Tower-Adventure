using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdButtonController : MonoBehaviour
{
    [SerializeField] ChestTracker tracker;
    [SerializeField] GeneralStats stats;
    [SerializeField] GameObject rewardWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckForAd()
    {
        /*
         * if (ad available)
         * {
         *      activate the ad button
         * }
         */

    }

    //when the button is clicked to play an add
    public void OnClick()
    {
        //display window of add rewards
        rewardWindow.SetActive(true);
        
    }

    //for clicking to play the ad from the reward window
    public void RewardClick()
    {
        //play ad
        //close reward window
        //deactivate the ad button
        tracker.AddChest(stats.GetTopFloor());
    }    
}
