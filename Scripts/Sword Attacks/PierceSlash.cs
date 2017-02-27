using UnityEngine;
using System.Collections;

public class PierceSlash : MonoBehaviour {

    public string TagToHit;
    public float myDamage;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, .2f);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag(TagToHit))
        {
           _col.gameObject.GetComponent<HealthControlerScript>().TakeDamage(myDamage);
           Debug.Log("Pierce Slash");
       }
    }
}
