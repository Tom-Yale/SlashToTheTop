using UnityEngine;
using System.Collections;

public class MegaSlash : MonoBehaviour {

    public string TagToHit;
    public float myDamage;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, .5f);
        FlashOn();
        Invoke("FlashOff", .1f);
        Invoke("FlashOn", .2f);
        Invoke("FlashOff", .3f);
        Invoke("FlashOn", .4f);
        Invoke("FlashOff", .5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag(TagToHit))
        {
            _col.gameObject.GetComponent<HealthControlerScript>().TakeDamage(myDamage);
            Debug.Log("MegaSlash");
        }
    }

    void FlashOn()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }

    void FlashOff()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
