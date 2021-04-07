using UnityEngine;

public class SimitFighter : MonoBehaviour
{
    [SerializeField]Animator animator;
    SimitGameController simitGameController;
    GameObject gameControl;
    float simitTimer = 20;
    float simitTimerCount;

    private void Start()
    {
        gameControl = GameObject.Find("GameController");
        simitGameController = gameControl.GetComponent<SimitGameController>();
        simitTimerCount = simitTimer;
    }

    private void Update()
    {
        simitTimerCount -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Punching") && collision.gameObject.tag == "OtherPlayers")
        {
            if (simitTimerCount > 0)
            {
                simitGameController.OtherPlayersScore();
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "SnowGround")
        {
            simitTimerCount = simitTimer;
        }
    }
}
