using Photon.Pun;
using UnityEngine;
using System.Collections;

public class NetworkPlayer : MonoBehaviourPunCallbacks, IPunObservable
{
    bool isAlive = true;


    Vector3 position;
    Quaternion rotation;

    float lerpSmoothing = 5f;

    private void Start()
    {
        if (photonView.IsMine)
        {
        }
        else
        {
            StartCoroutine("Alive");
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            position = (Vector3)stream.ReceiveNext();
            rotation = (Quaternion)stream.ReceiveNext();
        }
    }

    IEnumerator Alive()
    {
        while (isAlive)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * lerpSmoothing);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * lerpSmoothing);

            yield return null;
        }
    }
}

