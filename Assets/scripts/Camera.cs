using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;

    void Update () 
    {
        if (target) 
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        }
    }
}