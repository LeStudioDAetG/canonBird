using UnityEngine;

public class Bird : Shootable
{
    [HideInInspector]
	public Canon currentCanon;
	[HideInInspector]
	public Canon lastCanon;


	private bool firsJump_;


//***************************************
// Unity functions

	void Start()
	{
		Debug.Log("Init Pioupiou");
		//Rigidbody rb = GetComponent<Rigidbody>();
		rigidbody2D.isKinematic = true;
		rigidbody2D.WakeUp();

		firsJump_ = true;
	}

	void Update()
	{
		if (currentCanon)
		{
			transform.rotation = currentCanon.getRotation();
		}
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
		else if(firsJump_)
		{
			// jump
			rigidbody2D.isKinematic = false;
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(transform.up * 500);
			firsJump_ = false;
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
