using GoogleMobileAds.Api;
using GoogleMobileAds;
using UnityEngine;


// FOR BANNER AD ON TOP

public class BannerAd : MonoBehaviour {

    private BannerView bannerView;


    public void Start()
    {

        DontDestroyOnLoad(this.gameObject);

        #if UNITY_ANDROID
        string appId = "ca-app-pub-8509816676582957~6852715940";
        #elif UNITY_IPHONE
                string appId = "unexpected_platform";
        #else
                string appId = "unexpected_platform";
        #endif

                // Initialize the Google Mobile Ads SDK.
                MobileAds.Initialize(appId);

                this.RequestBanner();
    }

    private void RequestBanner()
    {
        
        string adUnitId = "ca-app-pub-8509816676582957/8077596883";
     
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }


}
