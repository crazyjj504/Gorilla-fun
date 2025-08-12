using System.Collections;
using UnityEngine;
using Photon.Pun;

namespace teatimefox
{
    public class Door : MonoBehaviourPun, IPunObservable
    {
        public Transform closedPosition;
        public Transform openPosition;
        public AudioClip openClip;
        public AudioClip closeClip;
        public AudioClip movingClip;
        public AudioClip alarmClip;
        public AudioSource movingSource;
        public AudioSource alarmSource;
        public AudioSource sfxSource;
        public float speed = 2f;

        private bool isOpen = false;
        private bool isMoving = false;
        private Vector3 targetPosition;

        public void ToggleDoor()
        {
            if (isMoving) return;
            photonView.RPC("RPC_ToggleDoor", RpcTarget.AllBuffered);
        }

        [PunRPC]
        private void RPC_ToggleDoor()
        {
            if (isMoving) return;
            isOpen = !isOpen;
            if (movingSource != null && movingClip != null)
            {
                movingSource.clip = movingClip;
                movingSource.loop = true;
                movingSource.Play();
            }
            if (alarmSource != null && alarmClip != null)
            {
                alarmSource.clip = alarmClip;
                alarmSource.loop = true;
                alarmSource.Play();
            }
            StopAllCoroutines();
            StartCoroutine(MoveDoor());
        }

        private IEnumerator MoveDoor()
        {
            isMoving = true;
            targetPosition = isOpen ? openPosition.position : closedPosition.position;
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
            transform.position = targetPosition;
            isMoving = false;
            if (movingSource != null) movingSource.Stop();
            if (alarmSource != null) alarmSource.Stop();
            if (sfxSource != null)
            {
                sfxSource.Stop();
                sfxSource.clip = isOpen ? openClip : closeClip;
                sfxSource.Play();
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(isOpen);
                stream.SendNext(transform.position);
            }
            else
            {
                isOpen = (bool)stream.ReceiveNext();
                transform.position = (Vector3)stream.ReceiveNext();
            }
        }
    }
}
