using Photon.Pun;
using UnityEngine;

public class ChangeColor : MonoBehaviourPun
{
    public static ChangeColor changeColor;
    [SerializeField]SkinnedMeshRenderer meshRenderer;
    Color characterColor;
    private void Start()
    {
        if (photonView.IsMine)
        {
            changeColor = this;
        }
         characterColor = Color.white;
    }
    private void Update()
    {
        if (photonView.IsMine)
        {
            meshRenderer.material.color = characterColor;
        }
    }
    public void SetColor(Color newColor)
    {
            characterColor = newColor;
    }
}