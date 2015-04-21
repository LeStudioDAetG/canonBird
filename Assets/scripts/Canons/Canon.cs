using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour
{
    public float rotationSpeed = -90.0f;
    public float fireForce = 500.0f;

	public float rotationLockFor = 0.0f;
	
    void Start()
    {
 
	}
	
	void Update ()
	{
		float delta = GameManager.getDeltaTime();


		// This meant to keep the canon on his frequency
		if(rotationLockFor>0)
		{
			rotationLockFor -= delta;

			if(rotationLockFor <= 0)
			{
				delta = -rotationLockFor; // Add the delta that happened
			}
		}

		if (rotationLockFor <= 0)
		{
			transform.Rotate (0, 0, rotationSpeed*delta);
		}
	}

    public void Fire(Shootable ammo)
    {
		if (ammo)
        {
			Vector3 dir = Quaternion.Euler(0, transform.rotation.z, 0) * transform.up;
			ammo.transform.position = transform.position;
			ammo.GetComponent<Rigidbody2D>().isKinematic = false;
			ammo.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			ammo.GetComponent<Rigidbody2D>().AddForce(dir * fireForce);

			//
			rotationLockFor = 4;
        }
    }
	
	public void Place(float x, float y)
	{
		transform.position = new Vector3 (x, y, transform.position.z);
	}

	public Quaternion getRotation ()
	{
		return transform.rotation;
	}
}
