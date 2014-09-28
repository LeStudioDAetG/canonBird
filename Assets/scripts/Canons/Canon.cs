using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour
{
    public float rotationSpeed = -5.0f;
    public float fireForce = 500.0f;
	
    void Start()
    {
 
	}
	
	void Update ()
	{
    	transform.Rotate(0, 0, rotationSpeed);
	}

    public void Fire(Shootable ammo)
    {
		if (ammo)
        {
			ammo.transform.position = transform.position;
			ammo.rigidbody2D.isKinematic = false;
			ammo.rigidbody2D.velocity = Vector2.zero;
			ammo.rigidbody2D.AddForce(transform.up * fireForce);
        }
    }
	
	public void Place(float x, float y)
	{
		transform.position = new Vector3 (x, y, transform.position.z);
	}
}
