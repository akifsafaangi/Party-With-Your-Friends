using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    Rigidbody snowballRigidbody;
    float sizeMultiplier = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        snowballRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "SnowGround")
        {
            if (snowballRigidbody.velocity != Vector3.zero)
            {
                transform.localScale += new Vector3(0.001f,0.001f,0.001f);
                //snowballRigidbody.mass = Mathf.Pow(transform.localScale.x, 1f/5f);
            }
        }
    }
}
