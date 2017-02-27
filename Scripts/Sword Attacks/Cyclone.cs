using UnityEngine;
using System.Collections;

public class Cyclone : MonoBehaviour
{

    // Use this for initialization
    public string TagToHit;
    //CircleCollider2D attackZone;
    public float myDamage;

   
    
    void Start()
    {
        Invoke("TurnOffCircleCollider", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, .5f);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {   
            if (collision.CompareTag(TagToHit))
            {
                Debug.Log("Cyclone");
                HealthControlerScript targetHealth = collision.gameObject.GetComponent<HealthControlerScript>();
                targetHealth.TakeDamage(myDamage);
                if (this.transform.position.x > collision.transform.position.x)
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
                else
                    collision.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

            }        
    }

    void TurnOffCircleCollider()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
   
}
