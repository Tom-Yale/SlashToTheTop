using UnityEngine;
using System.Collections;

public class HeliSwing : MonoBehaviour {

    public string TagToHit;
    public float myDamage;
	// Use this for initialization
	void Start () {
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
            if (transform.position.x < _col.transform.position.x)
                _col.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            else
                _col.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);


        }
    }
}
