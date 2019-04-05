using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D theRB;

    public Transform bottomLeftLimit, topRightLimit;

    public Transform shotpoint;
    public GameObject shot;
    private float shotCounter;
    public float timeBetweenShots = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))*moveSpeed;
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y),  transform.position.z);

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(shot, shotpoint.position, shotpoint.rotation);
            shotCounter = timeBetweenShots;
        }

        if (Input.GetButton("Fire1"))
        {
           // Instantiate(shot, shotpoint.position, shotpoint.rotation);
            shotCounter -= Time.deltaTime;
            if(shotCounter <=0)
            {
                Instantiate(shot, shotpoint.position, shotpoint.rotation);
                shotCounter = timeBetweenShots;
            }
        }



    }
}
