using UnityEngine;
using System.Collections;

public class PierceStab : MonoBehaviour
{

    public string TagToHit;
    public float myDamage;
    bool playerFacingRight;
    // Use this for initialization
    void Start()
    {
        playerFacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>().facingRight;

        if (playerFacingRight)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        Destroy(gameObject, .3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        ScaleSpear();
    }
    public void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag(TagToHit))
        {
            _col.gameObject.GetComponent<HealthControlerScript>().TakeDamage(myDamage);
            Debug.Log("Pierce Stab");
        }
    }

    void ScaleSpear()
    {
        if (playerFacingRight)
        {
            transform.localScale = new Vector3(transform.localScale.x - .1f, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(transform.position.x + .05f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x + .1f, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(transform.position.x - .05f, transform.position.y, transform.position.z);
        }
    }
}
