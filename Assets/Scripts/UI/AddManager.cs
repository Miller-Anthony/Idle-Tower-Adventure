using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Mediation;

public class AddManager : MonoBehaviour
{
    public string androidGameId;


    // Start is called before the first frame update
    async void Start()
    {
        // Initialize package with a custom Game ID
        InitializationOptions options = new InitializationOptions();
        options.SetGameId("TestGameId");
        await UnityServices.InitializeAsync(options);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    InitializationOptions GetGameId()
    {
        var initializationOptions = new InitializationOptions();

#if UNITY_IOS
                if (!string.IsNullOrEmpty(iosGameId))
                {
                    initializationOptions.SetGameId(iosGameId);
                }
#elif UNITY_ANDROID
        if (!string.IsNullOrEmpty(androidGameId))
        {
            initializationOptions.SetGameId(androidGameId);
        }
#endif

        return initializationOptions;
    }
}
