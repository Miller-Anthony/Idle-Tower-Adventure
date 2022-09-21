using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Mediation;

public class AddManager : MonoBehaviour
{
    [Header("Ad Unit Ids"), Tooltip("Android Ad Unit Ids")]
    [SerializeField] string androidAdUnitId;

    [Tooltip("[Optional] Specifies the Android GameId. Otherwise uses the GameId of the linked project.")]
    [SerializeField] string androidGameId;

    [Header("Banner options")]
    [SerializeField] BannerAdAnchor bannerAdAnchor = BannerAdAnchor.TopCenter;

    [SerializeField] BannerAdPredefinedSize bannerSize = BannerAdPredefinedSize.Banner;

    IBannerAd m_BannerAd;

    // Start is called before the first frame update
    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync(GetGameId());
            InitializationComplete();
        }
        catch (Exception e)
        {
            InitializationFailed(e);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    InitializationOptions GetGameId()
    {
        InitializationOptions initializationOptions = new InitializationOptions();

        if (!string.IsNullOrEmpty(androidGameId))
        {
            initializationOptions.SetGameId(androidGameId);
        }
        return initializationOptions;
    }

    void InitializationComplete()
    {
        // Impression Event
        MediationService.Instance.ImpressionEventPublisher.OnImpression += ImpressionEvent;

        var bannerAdSize = bannerSize.ToBannerAdSize();
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                m_BannerAd = MediationService.Instance.CreateBannerAd(androidAdUnitId, bannerAdSize, bannerAdAnchor);
                break;
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.LinuxEditor:
                m_BannerAd = MediationService.Instance.CreateBannerAd(androidAdUnitId, bannerAdSize, bannerAdAnchor);
                break;
            default:
                Debug.LogWarning("Mediation service is not available for this platform:" + Application.platform);
                return;
        }

        Debug.Log("Initialized On Start! Loading banner Ad...");
        LoadAd();
    }

    async void LoadAd()
    {
        try
        {
            await m_BannerAd.LoadAsync();
            AdLoaded();
        }
        catch (LoadFailedException e)
        {
            AdFailedLoad(e);
        }
    }

    void AdLoaded()
    {
        Debug.Log("Ad loaded");
    }

    void AdFailedLoad(LoadFailedException e)
    {
        Debug.Log("Failed to load ad");
        Debug.Log(e.Message);
    }

    void ImpressionEvent(object sender, ImpressionEventArgs args)
    {
        var impressionData = args.ImpressionData != null ? JsonUtility.ToJson(args.ImpressionData, true) : "null";
        Debug.Log($"Impression event from ad unit id {args.AdUnitId} : {impressionData}");
    }

    void InitializationFailed(Exception error)
    {
        var initializationError = SdkInitializationError.Unknown;
        if (error is InitializeFailedException initializeFailedException)
        {
            initializationError = initializeFailedException.initializationError;
        }

        Debug.Log($"Initialization Failed: {initializationError}:{error.Message}");
    }
}
