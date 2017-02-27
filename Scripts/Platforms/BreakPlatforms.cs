using UnityEngine;
using System.Collections;

public class BreakPlatforms : MonoBehaviour
{

    [SerializeField]
    Sprite Platform;
    [SerializeField]
    Sprite PlatformBroken;
    [SerializeField]
    Sprite PlatformGone;
    [SerializeField]
    bool Broken = false;
    [SerializeField]
    float time = 2.0f;
    [SerializeField]
    float reset = 8.0f;
    bool soundPLayed = false;

    [SerializeField]
    AudioClip CrackingSound;
    [SerializeField]
    AudioClip BreakingSound;
    [SerializeField]
    AudioSource audioManager;
    // Use this for initialization
    void Start()
    {
        audioManager = Object.FindObjectOfType<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Broken == true)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {

                this.GetComponent<SpriteRenderer>().sprite = PlatformGone;
                this.GetComponent<EdgeCollider2D>().enabled = false;
                if (soundPLayed == true)
                {
                    audioManager.PlayOneShot(BreakingSound, audioManager.GetComponent<SoundManager>().SfxSource.volume);
                    //SoundManager.instance.PlayOnce(BreakingSound);
                    soundPLayed = false;
                }
            }

        }
        if (this.GetComponent<SpriteRenderer>().sprite == PlatformGone)
            reset -= Time.deltaTime;

        if (reset <= 0)
        {

            this.GetComponent<SpriteRenderer>().sprite = Platform;
            this.GetComponent<EdgeCollider2D>().enabled = true;
            time = 2.0f;
            reset = 8.0f;
            Broken = false;
            soundPLayed = false;
        }
    }

    void OnCollisionEnter2D(Collision2D _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            if (_col.gameObject.GetComponent<PlayerControler>().grounded)
            {

                BrokenPlatform();
                if (soundPLayed == false)
                {
                    audioManager.PlayOneShot(CrackingSound, audioManager.GetComponent<SoundManager>().SfxSource.volume);
                    soundPLayed = true;
                }
            }
        }
    }

    public void BrokenPlatform()
    {

        Broken = true;

        if (Broken == true)
            this.GetComponent<SpriteRenderer>().sprite = PlatformBroken;
        else
            this.GetComponent<SpriteRenderer>().sprite = Platform;
    }
}
