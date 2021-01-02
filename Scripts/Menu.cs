using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Menu : MonoBehaviour
{
    public CanvasGroup SHOP;
    
    public GameObject buybuttonW2;
    public GameObject buybuttonW3;
    public GameObject buybuttonW4;
    public GameObject buybuttonW5;
    public GameObject buybuttonW6;
    public GameObject buybuttonW7;
    public GameObject buybuttonW8;
    public GameObject buybuttonW9;


    public GameObject selectW1;
    public GameObject selectW2;
    public GameObject selectW3;
    public GameObject selectW4;
    public GameObject selectW5;
    public GameObject selectW6;
    public GameObject selectW7;
    public GameObject selectW8;
    public GameObject selectW9;




    public GameObject selectedW1;
    public GameObject selectedW2;
    public GameObject selectedW3;
    public GameObject selectedW4;
    public GameObject selectedW5;
    public GameObject selectedW6;
    public GameObject selectedW7;
    public GameObject selectedW8;
    public GameObject selectedW9;





    public static bool w1=true;
  public static bool w2=false;
  public static bool w3=false;
  public static bool w4 = false;
  public static bool w5 = false;
  public static bool w6 = false;
  public static bool w7 = false;
    public static bool w8 = false;
    public static bool w9 = false;


    int buyw2;
    int buyw3;
    int buyw4;
    int buyw5;
    int buyw6;
    int buyw7;
    int buyw8;
    int buyw9;

    public GameObject alien1;
    public GameObject alien2;
    public GameObject alien3;

    public int totalMoney;

    int gamegold;
    int score;
    int menuMoney;
    int bestScore;

    public Text ScoreText;
    public Text menumoneytext; 
  
    public GameObject dontMoney2;
    public GameObject dontMoney3;
    public GameObject dontMoney4;
    public GameObject dontMoney5;
    public GameObject dontMoney6;
    public GameObject dontMoney7;
    public GameObject dontMoney8;
    public GameObject dontMoney9;

    public GameObject controls;
    public static int adscounter;
    string gameId = "3794955";
    bool testMode = true;

    public Button getfree;
    public GameObject watched;

    public GameObject loadingScreen;
    public Slider loadbar;
    public Text progressText;

    int purchase;
    void Start()
       {
        Time.timeScale = 1.0f;
        Advertisement.Initialize(gameId, testMode);


        GoldCounter.gameGold = 0;
        Npc.score = 0;




       score = PlayerPrefs.GetInt("Score");

        totalMoney = PlayerPrefs.GetInt("totalmoney");
      
       
        

        bestScore = PlayerPrefs.GetInt("bestScore");
        ScoreText.text = bestScore.ToString();


        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
           
            
        }


        SHOP.alpha = 0;
        SHOP.blocksRaycasts = false;
        SHOP.interactable = false;


        loadData();
        
        if(w2 || w3 || w4 || w5 || w6 || w7 || w8 || w9)
        {
            w1 = false;
        }
        else
        {
            w1 = true;
        }

        if (w1)
        {
            selectedW1.SetActive(true);
            selectW1.SetActive(false);
            
        }

        else if (w2)
        {
            selectedW2.SetActive(true);
            selectW2.SetActive(false);
            buybuttonW2.SetActive(false);


        }

        else if (w3)
        {
            selectedW3.SetActive(true);
            selectW3.SetActive(false);
            buybuttonW3.SetActive(false);


        }

       else if (w4)
        {
            selectedW4.SetActive(true);
            selectW4.SetActive(false);
             buybuttonW4.SetActive(false);

        }

       else if (w5)
        {
            selectedW5.SetActive(true);
         
            selectW5.SetActive(false);
            buybuttonW5.SetActive(false);

        }

       else if (w6)
        {
            selectedW6.SetActive(true);
            selectW6.SetActive(false);
            buybuttonW6.SetActive(false);

        }

        else if (w7)
        {
            selectedW7.SetActive(true);
            selectW7.SetActive(false);
            buybuttonW7.SetActive(false);

        }

       else if (w8)
        {
            selectedW8.SetActive(true);
            selectW8.SetActive(false);
            buybuttonW8.SetActive(false);

        }else if (w9)
        {
            selectedW9.SetActive(true);
            selectW9.SetActive(false);
            buybuttonW9.SetActive(false);

        }

        buyw2 = PlayerPrefs.GetInt("buyw2");
        buyw3 = PlayerPrefs.GetInt("buyw3");
        buyw4 = PlayerPrefs.GetInt("buyw4");
        buyw5 = PlayerPrefs.GetInt("buyw5");
        buyw6 = PlayerPrefs.GetInt("buyw6");
        buyw7 = PlayerPrefs.GetInt("buyw7");
        buyw8 = PlayerPrefs.GetInt("buyw8");
        buyw9 = PlayerPrefs.GetInt("buyw9");

        if (buyw2 == 1)
        {
            buybuttonW2.SetActive(false);
        }


        if (buyw3 == 1)
        {
            buybuttonW3.SetActive(false);
        }

        if (buyw4 == 1)
        {
            buybuttonW4.SetActive(false);
        }

        if (buyw5 == 1)
        {
            buybuttonW5.SetActive(false);
        }

        if (buyw6 == 1)
        {
            buybuttonW6.SetActive(false);
        }

        if (buyw7 == 1)
        {
            buybuttonW7.SetActive(false);
        }

        if (buyw8 == 1)
        {
            buybuttonW8.SetActive(false);
        }

        if (buyw9 == 1)
        {
            buybuttonW9.SetActive(false);
        }

    }
   
    // Update is called once per frame
    void Update()
    {
        getfree.interactable = true;
        saveData();

        if (Advertisement.IsReady()&& adscounter==3 )
        {
            Advertisement.Show();
            adscounter = 0;
        }

        menumoneytext.text = totalMoney.ToString();
        PlayerPrefs.SetInt("totalmoney", totalMoney);
        
    }

    public void PlayButton()
    {
        StartCoroutine(loadAsyncchronosly(1));
        adscounter++;
       
    }
    IEnumerator loadAsyncchronosly(int sceneIndex)
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(sceneIndex);
        alien1.SetActive(false);
        alien2.SetActive(false);
        alien3.SetActive(false);
        loadingScreen.SetActive(true);

        while (!Operation.isDone)
        {
            float progress = Mathf.Clamp01(Operation.progress);

            loadbar.value = progress;
            progressText.text = progress*100f+"%";

            yield return null;
        }

    }

    

   public void ShopButton()
    {
        SHOP.alpha = 1;
        SHOP.blocksRaycasts = true;
        SHOP.interactable = true;
        alien1.SetActive(false);
        alien2.SetActive(false);
        alien3.SetActive(false);

    }


    public void shopCancel()
    {

        SHOP.alpha = 0;
        SHOP.blocksRaycasts = false;
        SHOP.interactable = false;
        alien1.SetActive(true);
        alien2.SetActive(true);
        alien3.SetActive(true);

    }

    public void buyweapon2()
    {
        if (totalMoney >= 5000) {

            buybuttonW2.SetActive(false);
            PlayerPrefs.SetInt("buyw2", 1);
            totalMoney -= 5000;

        }

        else
        {
            StartCoroutine(waitForText2());
        }



    }

    public void buyweapon3()
    {
        if(totalMoney >= 10000)
        {
            buybuttonW3.SetActive(false);

            PlayerPrefs.SetInt("buyw3", 1);
            totalMoney -= 10000;
        }
        else
        {
            StartCoroutine(waitForText3());
        }


    }
    public void buyweapon4()
    {
        if(totalMoney >= 20000)
        {
            buybuttonW4.SetActive(false);
            PlayerPrefs.SetInt("buyw4", 1);
            totalMoney -= 20000;

        }

        else
        {
            StartCoroutine(waitForText4());
        }


    }
    public void buyweapon5()
    {
      

        if(totalMoney >= 50000)
        {
            buybuttonW5.SetActive(false);
            PlayerPrefs.SetInt("buyw5", 1);
            totalMoney -= 50000;
        }
        else
        {
            StartCoroutine(waitForText5());
        }

    }
    public void buyweapon6()
    {
       
        if(totalMoney >= 75000)
        {
            buybuttonW6.SetActive(false);
            PlayerPrefs.SetInt("buyw6", 1);
            totalMoney -= 75000;

        }
        else
        {
            StartCoroutine(waitForText6());
        }


    }
    public void buyweapon7()
    {
        if(totalMoney >= 125000)
        {


            buybuttonW7.SetActive(false);
            PlayerPrefs.SetInt("buyw7", 1);
            totalMoney -= 125000;
        }
        else
        {
            StartCoroutine(waitForText7());
        }



    }
    public void buyweapon8()
    {
        if (totalMoney >= 200000)
        {
            buybuttonW8.SetActive(false);
            PlayerPrefs.SetInt("buyw8", 1);
            totalMoney -= 200000;
        }
        else
        {
            StartCoroutine(waitForText8());
        }



    }
    public void buyweapon9()
    {
        if (totalMoney >= 500000)
        {
            buybuttonW9.SetActive(false);
            PlayerPrefs.SetInt("buyw9", 1);
            totalMoney -= 500000;

        }
        else
        {
            StartCoroutine(waitForText9());
        }
     

    }

    IEnumerator waitForText9()
    {
        dontMoney9.SetActive(true);
       yield return new WaitForSeconds(1f);
        dontMoney9.SetActive(false);

    }
    IEnumerator waitForText8()
    {
        dontMoney8.SetActive(true);
        yield return new WaitForSeconds(1f);
        dontMoney8.SetActive(false);

    }
    IEnumerator waitForText7()
    {
        dontMoney7.SetActive(true);
        yield return new WaitForSeconds(1f);
        dontMoney7.SetActive(false);

    }
    IEnumerator waitForText6()
    {
        dontMoney6.SetActive(true);
        yield return new WaitForSeconds(1f);
        dontMoney6.SetActive(false);

    }
    IEnumerator waitForText5()
    {
        dontMoney5.SetActive(true);
        yield return new WaitForSeconds(1f);
        dontMoney5.SetActive(false);

    }
    IEnumerator waitForText4()
    {
        dontMoney4.SetActive(true);
        yield return new WaitForSeconds(1f);
        dontMoney4.SetActive(false);

    }
    IEnumerator waitForText3()
    {
        dontMoney3.SetActive(true);
        yield return new WaitForSeconds(1f);
        dontMoney3.SetActive(false);

    }
    IEnumerator waitForText2()
    {
        dontMoney2.SetActive(true);
        yield return new WaitForSeconds(1f);
        dontMoney2.SetActive(false);

    }

    public void selectweapon1()
    {
        selectW1.SetActive(false);
        selectW2.SetActive(true);
        selectW3.SetActive(true);
        selectW4.SetActive(true);
        selectW5.SetActive(true);
        selectW6.SetActive(true);
        selectW7.SetActive(true);
        selectW8.SetActive(true);
        selectW9.SetActive(true);

        selectedW1.SetActive(true);
        selectedW2.SetActive(false);
        selectedW3.SetActive(false);
        selectedW4.SetActive(false);
        selectedW5.SetActive(false);
        selectedW6.SetActive(false);
        selectedW7.SetActive(false);
        selectedW8.SetActive(false);
        selectedW9.SetActive(false);



        w1 = true;
        w2 = false;
        w3 = false;
        w4 = false;
        w5 = false;
        w6 = false;
        w7 = false;
        w8 = false;
        w9 = false;
    }


    public void selectweapon2()
    {
        selectW1.SetActive(true);
        selectW2.SetActive(false);
        selectW3.SetActive(true);
        selectW4.SetActive(true);
        selectW5.SetActive(true);
        selectW6.SetActive(true);
        selectW7.SetActive(true);
        selectW8.SetActive(true);
        selectW9.SetActive(true);


        selectedW1.SetActive(false);
        selectedW2.SetActive(true);
        selectedW3.SetActive(false);
        selectedW4.SetActive(false);
        selectedW5.SetActive(false);
        selectedW6.SetActive(false);
        selectedW7.SetActive(false);
        selectedW8.SetActive(false);
        selectedW9.SetActive(false);




        w1 = false;
        w2 = true;
        w3 = false;
        w4 = false;
        w5 = false;
        w6 = false;
        w7 = false;
        w8 = false;
        w9 = false;

    }
    public void selectweapon3()
    {
        selectW1.SetActive(true);
        selectW2.SetActive(true);
        selectW3.SetActive(false);
        selectW4.SetActive(true);
        selectW5.SetActive(true);
        selectW6.SetActive(true);
        selectW7.SetActive(true);
        selectW8.SetActive(true);
        selectW9.SetActive(true);


        selectedW1.SetActive(false);
        selectedW2.SetActive(false);
        selectedW3.SetActive(true);
        selectedW4.SetActive(false);
        selectedW5.SetActive(false);
        selectedW6.SetActive(false);
        selectedW7.SetActive(false);
        selectedW8.SetActive(false);
        selectedW9.SetActive(false);



        w1 = false;
        w2 = false;
        w3 = true;
        w4 = false;
        w5 = false;
        w6 = false;
        w7 = false;
        w8 = false;
        w9 = false;


    }
    public void selectweapon4()
    {
        
        selectW1.SetActive(true);
        selectW2.SetActive(true);
        selectW3.SetActive(true);
        selectW4.SetActive(false);
        selectW5.SetActive(true);
        selectW6.SetActive(true);
        selectW7.SetActive(true);
        selectW8.SetActive(true);
        selectW9.SetActive(true);







        selectedW1.SetActive(false);
        selectedW2.SetActive(false);
        selectedW3.SetActive(false);
        selectedW4.SetActive(true);
        selectedW5.SetActive(false);
        selectedW6.SetActive(false);
        selectedW7.SetActive(false);
        selectedW8.SetActive(false);
        selectedW9.SetActive(false);



        w1 = false;
        w2 = false;
        w3 = false;
        w4 = true;
        w5 = false;
        w6 = false;
        w7 = false;
        w8 = false;
        w9 = false;

    }
    public void selectweapon5()
    {
        selectW1.SetActive(true);
        selectW2.SetActive(true);
        selectW3.SetActive(true);
        selectW4.SetActive(true);
        selectW5.SetActive(false);
        selectW6.SetActive(true);
        selectW7.SetActive(true);
        selectW8.SetActive(true);
        selectW9.SetActive(true);




        selectedW1.SetActive(false);
        selectedW2.SetActive(false);
        selectedW3.SetActive(false);
        selectedW4.SetActive(false);
        selectedW5.SetActive(true);
        selectedW6.SetActive(false);
        selectedW7.SetActive(false);
        selectedW8.SetActive(false);
        selectedW9.SetActive(false);



        w1 = false;
        w2 = false;
        w3 = false;
        w4 = false;
        w5 = true;
        w6 = false;
        w7 = false;
        w8 = false;
        w9 = false;


    }
    public void selectweapon6()
    {
        selectW1.SetActive(true);
        selectW2.SetActive(true);
        selectW3.SetActive(true);
        selectW4.SetActive(true);
        selectW5.SetActive(true);
        selectW6.SetActive(false);
        selectW7.SetActive(true);
        selectW8.SetActive(true);
        selectW9.SetActive(true);



        selectedW1.SetActive(false);
        selectedW2.SetActive(false);
        selectedW3.SetActive(false);
        selectedW4.SetActive(false);
        selectedW5.SetActive(false);
        selectedW6.SetActive(true);
        selectedW7.SetActive(false);
        selectedW8.SetActive(false);
        selectedW9.SetActive(false);



        w1 = false;
        w2 = false;
        w3 = false;
        w4 = false;
        w5 = false;
        w6 = true;
        w7 = false;
        w8 = false;
        w9 = false;


    }
    public void selectweapon7()
    {
        selectW1.SetActive(true);
        selectW2.SetActive(true);
        selectW3.SetActive(true);
        selectW4.SetActive(true);
        selectW5.SetActive(true);
        selectW6.SetActive(true);
        selectW7.SetActive(false);
        selectW8.SetActive(true);
        selectW9.SetActive(true);


        selectedW1.SetActive(false);
        selectedW2.SetActive(false);
        selectedW3.SetActive(false);
        selectedW4.SetActive(false);
        selectedW5.SetActive(false);
        selectedW6.SetActive(false);
        selectedW7.SetActive(true);
        selectedW8.SetActive(false);
        selectedW9.SetActive(false);



        w1 = false;
        w2 = false;
        w3 = false;
        w4 = false;
        w5 = false;
        w6 = false;
        w7 = true;
        w8 = false;
        w9 = false;


    }
    public void selectweapon8()
    {
        selectW1.SetActive(true);
        selectW2.SetActive(true);
        selectW3.SetActive(true);
        selectW4.SetActive(true);
        selectW5.SetActive(true);
        selectW6.SetActive(true);
        selectW7.SetActive(true);
        selectW8.SetActive(false);
        selectW9.SetActive(true);


        selectedW1.SetActive(false);
        selectedW2.SetActive(false);
        selectedW3.SetActive(false);
        selectedW4.SetActive(false);
        selectedW5.SetActive(false);
        selectedW6.SetActive(false);
        selectedW7.SetActive(false);
        selectedW8.SetActive(true);
        selectedW9.SetActive(false);


        w1 = false;
        w2 = false;
        w3 = false;
        w4 = false;
        w5 = false;
        w6 = false;
        w7 = false;
        w8 = true;
        w9 = false;


    }
    public void selectweapon9()
    {
        selectW1.SetActive(true);
        selectW2.SetActive(true);
        selectW3.SetActive(true);
        selectW4.SetActive(true);
        selectW5.SetActive(true);
        selectW6.SetActive(true);
        selectW7.SetActive(true);
        selectW8.SetActive(true);
        selectW9.SetActive(false);

        selectedW1.SetActive(false);
        selectedW2.SetActive(false);
        selectedW3.SetActive(false);
        selectedW4.SetActive(false);
        selectedW5.SetActive(false);
        selectedW6.SetActive(false);
        selectedW7.SetActive(false);
        selectedW8.SetActive(false);
        selectedW9.SetActive(true);


        w1 = false;
        w2 = false;
        w3 = false;
        w4 = false;
        w5 = false;
        w6 = false;
        w7 = false;
        w8 = false;
        w9 = true;


    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }


    void saveData()
    {
        

        PlayerPrefs.SetInt("w1", boolToInt(w1));
        PlayerPrefs.SetInt("w2", boolToInt(w2));
        PlayerPrefs.SetInt("w3", boolToInt(w3));
        PlayerPrefs.SetInt("w4", boolToInt(w4));
        PlayerPrefs.SetInt("w5", boolToInt(w5));
        PlayerPrefs.SetInt("w6", boolToInt(w6));
        PlayerPrefs.SetInt("w7", boolToInt(w7));
        PlayerPrefs.SetInt("w8", boolToInt(w8));
        PlayerPrefs.SetInt("w9", boolToInt(w9));








    }

    void loadData()
    {
        w1 = intToBool(PlayerPrefs.GetInt("w1", 0));
        w2 = intToBool(PlayerPrefs.GetInt("w2", 0));
        w3 = intToBool(PlayerPrefs.GetInt("w3", 0));
        w4 = intToBool(PlayerPrefs.GetInt("w4", 0));
        w5 = intToBool(PlayerPrefs.GetInt("w5", 0));
        w6 = intToBool(PlayerPrefs.GetInt("w6", 0));
        w7 = intToBool(PlayerPrefs.GetInt("w7", 0));
        w8 = intToBool(PlayerPrefs.GetInt("w8", 0));
        w9 = intToBool(PlayerPrefs.GetInt("w9", 0));




    }

    public void controlsbutton()
    {
        controls.SetActive(true);
        alien1.SetActive(false);
        alien2.SetActive(false);
        alien3.SetActive(false);
    }

    public void controlCancel()
    {
        alien1.SetActive(true);
        alien2.SetActive(true);
        alien3.SetActive(true);
        controls.SetActive(false);
    }

    public void CloseRewardAlert()
    {
        alien1.SetActive(true);
        alien2.SetActive(true);
        alien3.SetActive(true);
        watched.SetActive(false);
    }

    public void getfreebutton()
    {
        alien1.SetActive(false);
        alien2.SetActive(false);
        alien3.SetActive(false);

    }


}
