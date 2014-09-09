using UnityEngine;

public class Bird : Shootable
{
    [HideInInspector]
	public Canon currentCanon;
	[HideInInspector]
	public Canon lastCanon;


//***************************************
// Unity functions

	void Start()
	{
		Debug.Log("Init Pioupiou");
		//Rigidbody rb = GetComponent<Rigidbody>();
		rigidbody2D.isKinematic = true;
		rigidbody2D.WakeUp();
	}

	void Update()
	{
		
	}

//***************************************
// Other functions


	public void SetLastCanon(Canon canon)
	{
		lastCanon = canon;
	}


	public void Shoot()
	{
		if (currentCanon)
		{
			// shoot 
			currentCanon.Fire(this);
			lastCanon = currentCanon;
			currentCanon = null;
		}
		else
		{
			//jump
			rigidbody2D.isKinematic = false;
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(transform.up * 500);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		Canon canon = collision.gameObject.GetComponent<Canon>();
		if (canon)
		{
			transform.position = canon.transform.position;
			rigidbody2D.isKinematic = true;
			currentCanon = canon;
		}
	}
}
