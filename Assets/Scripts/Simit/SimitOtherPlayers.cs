using UnityEngine;

public class SimitOtherPlayers : MonoBehaviour
{
    Animator animator;
    SimitGameController simitGameController;
    GameObject gameControl;
    float simitTimerCount = 20;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameControl = GameObject.Find("GameController");
        simitGameController = gameControl.GetComponent<SimitGameController>();
    }

    private void Update()
    {
        simitTimerCount -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Punching") && collision.gameObject.tag == "SimitFighter")
        {
            if (simitTimerCount <= 0)
            {
                simitGameController.Player1Score();
            }
        }
    }
}
