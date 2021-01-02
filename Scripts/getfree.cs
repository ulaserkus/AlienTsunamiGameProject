using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(Button))]
public class getfree : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "1486551";
#elif UNITY_ANDROID
    private string gameId = "3794955";
#endif
    int randomMoney;
    Button myButton;
    public string myPlacementId = "rewardedVideo";
    public GameObject watched;
    public Text gained;
    public GameObject noconnection;
    public GameObject alien1;
    public GameObject alien2;
    public GameObject alien3;
    
    void Start()
    {
        myButton = GetComponent<Button>();
       
        watched.SetActive(false);
        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);
       
        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
        

    }
    
    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
      
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            
            watched.SetActive(true);
            randomMoney = Random.Range(1000, 5000);
            gained.text = randomMoney.ToString();
            GameObject.FindObjectOfType<Menu>().totalMoney += randomMoney;
        }
       
        else if (showResult == ShowResult.Failed)
        {
            StartCoroutine(noconnect());
        }
      }

    IEnumerator noconnect()
    {
        noconnection.SetActive(true);
        alien1.SetActive(false);
        alien2.SetActive(false);
        alien3.SetActive(false);
        yield return new WaitForSeconds(3f);
        noconnection.SetActive(false);
        alien1.SetActive(true);
        alien2.SetActive(true);
        alien3.SetActive(true);

    }
    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
    void OnDestroy()
    {


        myButton.onClick.RemoveListener(ShowRewardedVideo);
        Advertisement.RemoveListener(this);

    }
}