using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour
{
    public float rotationSpeed = -5.0f;
    public float fireForce = 500.0f;
    public Bird bird;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (bird)
        {
            bird.rigidbody2D.isKinematic = true;
            bird.rigidbody2D.WakeUp();
            gameManager.SetCurrentCanon(this);
        }
	}
	
	void Update () {
        if (bird)
        {
            transform.Rotate(0, 0, rotationSpeed);
        }
	}

    public void Fire()
    {
        if (bird)
        {
            bird.transform.position = transform.position;
            bird.rigidbody2D.isKinematic = false;
            bird.rigidbody2D.velocity = Vector2.zero;
            bird.rigidbody2D.AddForce(transform.up * fireForce);
            bird.SetLastCanon(this);
            gameManager.SetCurrentCanon(null);
            bird = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Bird newBird = collision.gameObject.GetComponent<Bird>();
        if (newBird && newBird.lastCanon != this)
        {
            bird = newBird;
            bird.transform.position = transform.position;
            bird.rigidbody2D.isKinematic = true;
            gameManager.SetCurrentCanon(this);
        }
    }
}
