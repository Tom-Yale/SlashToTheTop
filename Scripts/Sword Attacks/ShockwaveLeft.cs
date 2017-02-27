using UnityEngine;
using System.Collections;

public class ShockwaveLeft : MonoBehaviour {
    public string TagToHit;
    PolygonCollider2D attackzone;
    public float myDamage;
    float ShockForce = 10;
	// Use this for initialization
	void Start () {
        attackzone = gameObject.GetComponent<PolygonCollider2D>();
        attackzone.isTrigger = true;
        attackzone.enabled = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.Translate(new Vector3(-Time.deltaTime * 10, 0, 0));

        Destroy(this.gameObject, .5f);
        ShockForce -= .3f;
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (collision.CompareTag(TagToHit))
            {

                Debug.Log("I hit the player, dealing damage");
                HealthControlerScript targetHealth = collision.gameObject.GetComponent<HealthControlerScript>();
                targetHealth.TakeDamage(myDamage);
                if (collision.GetComponent<Rigidbody2D>()!=null)
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-ShockForce, 0);
            }
        }
    }
}
