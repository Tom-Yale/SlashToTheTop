using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{

    public AudioSource SfxSource;
    public AudioSource musicSource;
    float Sfxaverage = 1;
    [SerializeField]
    AudioClip Level1;

    public static SoundManager instance = null;

    // Use this for initialization
    void Update()
    {
        GameObject Global = GameObject.Find("Global");
        if (Global != null)
        {
            if(GameObject.Find("OptionsMenu").GetComponent<Canvas>().enabled)
            {
                float average = musicSource.volume = (Global.GetComponent<Slider>().normalizedValue * GameObject.Find("BGM").GetComponent<Slider>().normalizedValue);
                musicSource.volume = average;

                Sfxaverage = SfxSource.volume = (GameObject.Find("Global").GetComponent<Slider>().normalizedValue * GameObject.Find("SFX").GetComponent<Slider>().normalizedValue);
                SfxSource.volume = Sfxaverage;
            }
        }

        // if (Application.loadedLevelName == "Level 2")
        //     ChangeMusic(Level1);
    }

    // Update is called once per frame
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    public void PlayOnce(AudioClip clip)
    {
        SfxSource.volume = Sfxaverage;
        SfxSource.clip = clip;
        SfxSource.Play();
    }
    public void Volume(AudioClip clip)
    {

    }

    public void ChangeMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }


}
