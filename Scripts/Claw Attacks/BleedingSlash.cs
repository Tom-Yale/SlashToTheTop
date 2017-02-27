using UnityEngine;
using System.Collections;

public class BleedingSlash : MonoBehaviour {

    public float myDamage;
    public float bleedDamage;
    GameObject enemy;
	// Use this for initialization
	void Start () {

        Destroy(gameObject, 3f);
        Invoke("TurnOffCollider", 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    public void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag("Enemy"))
        {
            enemy = _col.gameObject;
            enemy.GetComponent<HealthControlerScript>().TakeDamage(myDamage);            
            Invoke("BleedDamage", 1f);
            Invoke("BleedDamage", 1.5f);
            Invoke("BleedDamage", 2f);
            Invoke("BleedDamage", 2.5f);
        }
    }

    void BleedDamage()
    {
       enemy.GetComponent<HealthControlerScript>().TakeDamage(bleedDamage);
    }

    void TurnOffCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}

