using UnityEngine;
using System.Collections;

public class TogglePlatforms : MonoBehaviour {


    [SerializeField]
    Sprite PlatformVisible;
    [SerializeField]
    bool Visible = false;
    [SerializeField]
    float time = 2.0f;
    [SerializeField]
    float reset = 2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        time -= Time.deltaTime;

        if (time <= 0)
        {
            SetVisible();

            time += reset;
        }
	
	}


    public void SetVisible()
    {
        Visible = !Visible;

        if (Visible == true)
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        //this.GetComponent<SpriteRenderer>().sprite = PlatformVisible;
        else
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .25f);

            //this.GetComponent<SpriteRenderer>().sprite = PlatformInvisible;

        this.GetComponent<EdgeCollider2D>().enabled = Visible;

    }
}
