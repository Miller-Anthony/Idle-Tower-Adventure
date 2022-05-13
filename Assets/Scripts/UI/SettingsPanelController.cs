using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelController : MonoBehaviour
{
    [SerializeField] GameObject bgm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleBGM()
    {
        if(bgm.activeSelf)
        {
            bgm.SetActive(false);
        }
        else
        {
            bgm.SetActive(true);
        }
    }    
}
