using UnityEngine;
using System.Collections;

public class CameraPlayerFollow : MonoBehaviour
{
    public GameObject Player;

    public Vector2 Margin, Smoothing;

    public BoxCollider2D Bounds;

    private Vector3 _min, _max;

    public float time = 0;

    bool unFrozen = false;


    public bool StillFollowing { get; set; }


    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;
        StillFollowing = true;
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        
    }

    void Update()
    {

    }
    public void FixedUpdate()
    {
        //float orthographicSize = 3f;
        var x = transform.position.x;
        var y = transform.position.y /* + 0.15f*/;
        
        if (Camera.main.orthographicSize > 3 && time > 2)
        {
            Camera.main.orthographicSize -= 0.05f;
            
        }
        else if (time > 3 && !unFrozen)
        {         
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            unFrozen = true;
        }
        time += Time.deltaTime;



        if (StillFollowing)
        {
            if (Mathf.Abs(x - Player.transform.position.x) > Margin.x)
                x = Mathf.Lerp(x, Player.transform.position.x, Smoothing.x * Time.deltaTime);

            if (Mathf.Abs(y - Player.transform.position.y) > Margin.y)
                y = Mathf.Lerp(y, Player.transform.position.y, Smoothing.y * Time.deltaTime);
        }

        var cameraHalfWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);

        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
        y = Mathf.Clamp(y, _min.y + Camera.main.orthographicSize, _max.y - Camera.main.orthographicSize);

        transform.position = new Vector3(x, y, transform.position.z);

    }

}
