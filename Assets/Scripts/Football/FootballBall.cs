using UnityEngine;

public class FootballBall : MonoBehaviour
{
    [SerializeField]private FootballGameController gameController;
    GameObject gameControl;
    private void Start()
    {
        gameControl = GameObject.Find("GameController");
        gameController = gameControl.GetComponent<FootballGameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Team1Goal")
        {
            gameController.Team1();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Team2Goal")
        {
            gameController.Team2();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Team3Goal")
        {
            gameController.Team3();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Team4Goal")
        {
            gameController.Team4();
            Destroy(gameObject);
        }
    }
}
