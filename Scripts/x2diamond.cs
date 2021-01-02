using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class x2diamond : MonoBehaviour
{
    public static x2diamond Instance { get; private set; }

    string gameID_ANDROID = "3794955";
    

    [Header("AD Settings")]

    public bool testMode;


    public Button x2;
   

    [Header("Placement IDs")]
    

    public string intersitialPlacement = "intersitialVideo";

    string shiledRewardedPlacement = "rewardedVideo1";
    string doubleCoinRewardedPlacement = "rewardedVideo2";
  

    string rewardType;

    

    public Text gainedText;
    public GameObject gained;

    public GameObject noconnection;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
#if UNITY_ANDROID
        Advertisement.Initialize(gameID_ANDROID, testMode);
#elif UNITY_IOS
        Advertisement.Initialize(gameID_IOS, testMode);
#endif
        x2.interactable = true;
    }


    public void ShowRewardedAd(string _rewardType)
    {
        ShowOptions _showOptions = new ShowOptions() { resultCallback = OnUnityAdsDidFinish };

        rewardType = _rewardType;
        switch (rewardType)
        {
            case "contınue":
                Advertisement.Show(shiledRewardedPlacement, _showOptions);
                break;
            case "Double Coin":
                Advertisement.Show(doubleCoinRewardedPlacement, _showOptions);
                break;
           
        }
    }

    public void ShowIntersitial()
    {
        ShowOptions _showOptions = new ShowOptions() { resultCallback = OnUnityAdsDidFinish };
        Advertisement.Show(intersitialPlacement);
      
    }

    #region CALL BACKS

    public void OnUnityAdsDidFinish(ShowResult showResult)
    {
        Debug.Log("Ad finished");
        if (showResult == ShowResult.Finished)
        {
            switch (rewardType)
            {
                case "contınue":

                    GameObject.FindObjectOfType<Rewind>().Continue();

                    break;

                case "Double Coin":

                    gained.SetActive(true);
                    gainedText.text = "+"+GoldCounter.gameGold.ToString();
                    GoldCounter.totalMoney += GoldCounter.gameGold;
                    PlayerPrefs.SetInt("totalmoney", GoldCounter.totalMoney);

                    x2.interactable = false;
                    break;
                
                default:
                    break;
            }
        }
    }
    #endregion
    public void OnUnityAdsDidError()
    {
        StartCoroutine(noconnect());

    }

    IEnumerator noconnect()
    {
        noconnection.SetActive(true);
        yield return new WaitForSeconds(2f);
        noconnection.SetActive(false);
    }


}
