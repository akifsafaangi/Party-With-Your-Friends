using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerControllerDenemeleri2 playerControllerDenemeleri;

    private void Start()
    {
        playerControllerDenemeleri = GameObject.FindObjectOfType<PlayerControllerDenemeleri2>().GetComponent<PlayerControllerDenemeleri2>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerControllerDenemeleri.isGrounded = true;
    }
}
