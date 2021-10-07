using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatalObstacleColiison : MonoBehaviour
{
    private InGameCanvasController _canvasController;

    private void Start()
    {
        _canvasController = GameObject.Find("InGameCanvas").GetComponent<InGameCanvasController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(GameOver(collision.gameObject));
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameOver(other.gameObject));
        }
    }

    private IEnumerator GameOver(GameObject player)
    {
        player.GetComponent<PlayerEffects>().DeathStart();
        yield return new WaitForSeconds(2.0f);

        _canvasController.GameOverState();
    }


}
