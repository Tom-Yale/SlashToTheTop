using UnityEngine;
using System.Collections;

public class FlurrySlash : MonoBehaviour {

    public float myDamage;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, .1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag("Enemy"))
        {
            _col.gameObject.GetComponent<HealthControlerScript>().TakeDamage(myDamage);
        }
    }


}
