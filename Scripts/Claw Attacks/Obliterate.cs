using UnityEngine;
using System.Collections;

public class Obliterate : MonoBehaviour {

    public float myDamage;
    bool playerFacingRight;
	// Use this for initialization
	void Start () {
        playerFacingRight = GameObject.Find("Player").GetComponent<PlayerControler>().facingRight;
        if (!playerFacingRight)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); 
        Destroy(gameObject, .2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag("Enemy"))
        {
            _col.gameObject.GetComponent<HealthControlerScript>().TakeDamage(myDamage);
            Debug.Log("Obliterate");
        }
    }
}
