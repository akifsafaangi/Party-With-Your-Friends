using UnityEngine;

public class VolleyballBall : MonoBehaviour
{
    [SerializeField]private VolleyballGameController gameController;
    GameObject gameControl;
    private void Start()
    {
        gameControl = GameObject.Find("GameController");
        gameController = gameControl.GetComponent<VolleyballGameController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Team1")
        {
            gameController.Team2();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Team2")
        {
            gameController.Team1();
            Destroy(gameObject);
        }
    }
}
