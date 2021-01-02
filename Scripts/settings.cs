using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class settings : MonoBehaviour
{
    public GameObject settingsimage;
    public AudioSource[] AudioSources;
    public Slider volume;
    public Text soundCount;
    float deger;

    public Slider Sensivity;
    public Text sensivitycount;
   float sensivevalue;

    public GameObject areyousure;
    public static bool CamMovement=true;
 
    void Start()
    {
       volume.value = PlayerPrefs.GetFloat("sound");
       Sensivity.value= PlayerPrefs.GetFloat("sensive");
        soundCount.text = (volume.value * 100).ToString();
        sensivitycount.text = (Sensivity.value * 10).ToString();
        CamMovement = true;
        
        
        
    }

    // Update is called once per frame
    void Update()
    {

        foreach (AudioSource audioSource in AudioSources)
        {

            audioSource.GetComponents<AudioSource>();
            deger = Mathf.Round(volume.value);
            audioSource.volume = volume.value/100;
            
            soundCount.text = deger.ToString();
            
           
            PlayerPrefs.SetFloat("sound", volume.value);
        }
        sensivechange();

    }
    public void settingsbutton()
    {
        settingsimage.SetActive(true);
        Time.timeScale = 0.01f;
        CamMovement = false;
        
    }
    public void settingscancel()
    {
        
        settingsimage.SetActive(false);
        
        StartCoroutine(Pause(3));
        CamMovement = true;
        
    }
    private IEnumerator Pause(int p)
    {
       
        float pauseEndTime = Time.realtimeSinceStartup + 1;
        
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            
            yield return 0;
        }
        Time.timeScale = 1;
    }
    public void sensivechange()
    {
        MouseLook.XSensitivity = Sensivity.value/10;
        MouseLook.YSensitivity = Sensivity.value / 10;

        sensivevalue = (float)System.Math.Round(Sensivity.value, 2);

        sensivitycount.text = sensivevalue.ToString();

        PlayerPrefs.SetFloat("sensive", Sensivity.value);

    }

    public void exit()
    {
        areyousure.SetActive(true);

    }
    public void AreyouSurecancel()
    {
        areyousure.SetActive(false);
    }
    public void yes()
    {
        
        
        
        SceneManager.LoadSceneAsync(0);
    }

}
