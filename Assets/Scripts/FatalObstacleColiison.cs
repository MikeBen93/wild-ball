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

    /// <summary>
    /// Function to initiate game over on player collision with fatal obstacle
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(GameOver(collision.gameObject));
        }

    }

    /// <summary>
    /// Function to initiate game over when player enters fatal object
    /// </summary>
    /// <param name="other"></param>
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
