using UnityEngine;
using System.Collections;

public class UppercutSlash : MonoBehaviour {

    public string TagToHit;
    public float myDamage;
    bool playerFacingRight;
    // Use this for initialization
    void Start()
    {
        playerFacingRight = GameObject.Find("Player").GetComponent<PlayerControler>().facingRight;
        Destroy(gameObject, .3f);
    }
	
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag(TagToHit))
        {
            _col.gameObject.GetComponent<HealthControlerScript>().TakeDamage(myDamage);
         
            if (playerFacingRight)
                _col.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 8);
            else
                _col.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 8);


        }
    }
}
