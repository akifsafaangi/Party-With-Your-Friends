using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject goCreate;
    [SerializeField] private Vector3 spawnPoint;
    public FootballGameController gameController;
    private float spawnTimer = 2f;
    private float Score;
    float fTimer = 0;

    private void Start()
    {
        fTimer = spawnTimer;
    }   
    private void Update()
    {
        Score = gameController.LeftBallCount;
        if (Score != 0)
        {
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                fTimer = spawnTimer;
                Instantiate(goCreate, spawnPoint, Quaternion.identity);
                gameController.LeftBallCount--;
            }
        }
    }
}
