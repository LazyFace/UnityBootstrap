using UnityEngine;
using UnityEngine.Events;

public class PlatformTriggerScript : MonoBehaviour
{
    private bool isPlayerInsideZone = false;

    public UnityEvent PlayerEnteredTheZone;
    public UnityEvent PlayerExitedTheZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerEnteredTheZone?.Invoke();
            isPlayerInsideZone = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInsideZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExitedTheZone?.Invoke();
            isPlayerInsideZone = false;
        }
    }

    public bool PlayerInsideZone()
    {
        return isPlayerInsideZone;
    }
}
