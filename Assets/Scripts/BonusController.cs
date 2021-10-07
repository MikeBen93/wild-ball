using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    private bool _endingStarted;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);

            if (!_endingStarted)
            {
                StartCoroutine(DeleteBonus(this.transform.GetChild(1).GetComponent<ParticleSystem>().main.duration));
                _endingStarted = true;
            }
        }
    }

    /// <summary>
    /// Delete bonus object after it was taken by player
    /// </summary>
    /// <param name="duration">Total destruction delay equal to duration(sec) + 3(sec)</param>asdasd
    /// <returns></returns>
    private IEnumerator DeleteBonus(float duration)
    {
        yield return new WaitForSeconds(duration + 3f);
        Destroy(transform.parent.gameObject);
    }
}
