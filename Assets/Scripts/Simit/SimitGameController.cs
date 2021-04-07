using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimitGameController : MonoBehaviour
{
    public TMP_Text player1Text;
    public TMP_Text otherPlayersText;
    public TMP_Text timerText;
    private bool MatchActive;

    //PlayerScores
    private int player1Score = 20;
    private int otherPlayersScore = 10;

    // Start is called before the first frame update
    void Start()
    {
        MatchActive = true;
    }

     public void Player1Score()
     {
       if (MatchActive)
       {
          player1Score--;
          player1Text.text = player1Score.ToString();
       }
     }
     public void OtherPlayersScore()
     {
       if (MatchActive)
       {
          otherPlayersScore--;
          otherPlayersText.text = otherPlayersScore.ToString();
       }
     }
}
