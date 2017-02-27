using UnityEngine;
using System.Collections;

public class GroundPound : MonoBehaviour {

    public string TagToHit;
    public float myDamage;
    float fade = 1;
    bool playerFacingRight;
	// Use this for initialization
	void Start () {

        playerFacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>().facingRight;

        if (!playerFacingRight)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        Destroy(gameObject, .5f);
        Invoke("FadeAbility", .2f);
        Invoke("FadeAbility", .3f);
        Invoke("FadeAbility", .4f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag(TagToHit))
        {
            _col.gameObject.GetComponent<HealthControlerScript>().TakeDamage(myDamage);
            Debug.Log("GroundPound");
            if (playerFacingRight)
                _col.GetComponent<Rigidbody2D>().velocity = new Vector2(7, 4);
            else
                _col.GetComponent<Rigidbody2D>().velocity = new Vector2(-7, 4);

        }

    }

    void FadeAbility()
    {
        fade -= .25f;
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, fade);
    }

}
