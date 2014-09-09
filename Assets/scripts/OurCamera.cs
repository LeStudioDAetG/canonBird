using UnityEngine;

public class OurCamera : MonoBehaviour
{
	private Shootable target_;
	public float maxVelocity_ = 5000;


//***************************************
// Unity functions

	void Start()
	{
		Debug.Log("Init Camera");
		//Rigidbody rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        if (target_ != null) 
        {
			transform.position = new Vector3(target_.transform.position.x, target_.transform.position.y, this.transform.position.z);
        }
    }

//***************************************
// Other functions

	public void SetTarget(Shootable target)
	{
		target_ = target;
	}

	public void Reset()
	{

	}

}
