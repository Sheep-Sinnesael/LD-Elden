using UnityEngine;
using System.Collections;

public class LeverZone : MonoBehaviour
{
    public GameObject openMessage;
    public GameObject door;
    
    void OnTriggerEnter(Collider potentialPlayer)
    {
        if (potentialPlayer.transform.CompareTag("Player"))
        {
            Debug.Log("LeverActivated");
            door.SetActive(false);
            StartCoroutine(OpenMessage());
        }
    }

    IEnumerator OpenMessage()
    {
        openMessage.SetActive(true);
        yield return new WaitForSeconds(3f);
        openMessage.SetActive(false);
    }
}
