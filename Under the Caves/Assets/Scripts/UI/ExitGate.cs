using UnityEngine;

public class ExitGate : MonoBehaviour
{
    [SerializeField] private GameObject exitGate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            exitGate.SetActive(true);
        }
    }
}
