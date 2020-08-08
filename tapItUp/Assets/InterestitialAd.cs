using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

//FOR INTERESTITIAL AD

public class InterestitialAd : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Request Ad
        RequestInterstitialAds();
    }

    public void ShowAd()
    {
        //Debug.Log("hello");
        Invoke("showInterstitialAd", 1f);
    }

    public void showInterstitialAd()
    {
        //Show Ad
        if (interstitial.IsLoaded())
        {
            interstitial.Show();

            //Stop Sound
            //

            //Debug.Log("SHOW AD XXX");
        }else {
            PlayerPrefsManager.IncrementGamesPlayed();
            GameOver gameOver = FindObjectOfType<GameOver>();
            gameOver.ResetLevel();
            SetVolume();
        }


    }

    InterstitialAd interstitial;
    private void RequestInterstitialAds()
    {
        string adID = "ca-app-pub-8509816676582957/4053865046";


        string adUnitId = adID;

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        // //***Test***
        // AdRequest request = new AdRequest.Builder()
        //                                  .AddTestDevice("3D1C672D219159D99B85A86CAED4BF66")  // My test device.
        //.Build();

        //***Production***
        AdRequest request = new AdRequest.Builder().Build();

        //Register Ad Close Event
        interstitial.OnAdClosed += Interstitial_OnAdClosed;


        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        //Debug.Log("AD LOADED XXX");

    }

    //Ad Close Event
    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        interstitial.Destroy();
        PlayerPrefsManager.IncrementGamesPlayed();
        GameOver gameOver = FindObjectOfType<GameOver>();
        gameOver.ResetLevel();
        SetVolume();
    }


    void SetVolume(){
        if (PlayerPrefsManager.GetMasterVolume() == 0)
        {
            VolumeManager.SetMusicVolume(VolumeManager.musicVolume);
        }else
        {
            VolumeManager.SetMusicVolume(0f);
        }
    }
  
}

