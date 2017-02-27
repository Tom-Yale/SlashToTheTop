using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour
{
    public string TagToHit;
    PolygonCollider2D attackzone;
    public float myDamage;
    bool playerFacingRight;
    public float ShockForce = 10;
    // Use this for initialization
    void Start()
    {
        playerFacingRight = GameObject.Find("Player").GetComponent<PlayerControler>().facingRight;
        if (!playerFacingRight)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerFacingRight)
            transform.Translate(new Vector3(Time.deltaTime * 10, 0, 0));
        else
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
                if (collision.GetComponent<Rigidbody2D>() != null)
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(ShockForce, 0);
            }
        }
    }
}
