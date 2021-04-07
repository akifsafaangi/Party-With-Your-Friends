using UnityEngine;

public class PlayerControllerDenemeleri2 : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;

    public Rigidbody hips;
    public bool isGrounded;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        hips = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                hips.AddForce(hips.transform.forward * speed * 1.5f);
            }
            else
            {
                hips.AddForce(hips.transform.forward * speed);
            }

        }
        if (Input.GetKey(KeyCode.A))
        {
            hips.AddForce(-hips.transform.right * strafeSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            hips.AddForce(-hips.transform.forward * speed);

        }
        if (Input.GetKey(KeyCode.D))
        {
            hips.AddForce(hips.transform.right * strafeSpeed);

        }
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            hips.AddForce(new Vector3(0f, jumpForce, 0f));
            isGrounded = false;
        }
            
    }
}
