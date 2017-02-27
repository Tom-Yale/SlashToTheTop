using UnityEngine;
using System.Collections;

public class PierceThrow : MonoBehaviour {
    public string TagToHit;
    public float myDamage;
    bool playerFacingRight;
	// Use this for initialization
	void Start () 
    {
        playerFacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>().facingRight;

        if (playerFacingRight)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        Destroy(gameObject, 1);
	}
	
	// Update is called once per frame
	void Update () {

        if (playerFacingRight)
            transform.Translate(new Vector3(Time.deltaTime * 10, 0, 0));
        else
            transform.Translate(new Vector3(-Time.deltaTime * 10, 0, 0));
	}

    public void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag(TagToHit))
        {
            _col.gameObject.GetComponent<HealthControlerScript>().TakeDamage(myDamage);
            Debug.Log("Pierce Throw");
        }
    }
}
