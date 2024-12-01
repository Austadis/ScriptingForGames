using UnityEngine;
using UnityEngine.Events;

public class SimpleIDMatchBehaviour : MonoBehaviour
{
    public Id id;
    public UnityEvent matchEvent, noMatchEvent;
    
    private Collider objectCollider;

    private void Start()
    {
        objectCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherID = other.GetComponent<SimpleIDBehaviour>();

        if (otherID != null && otherID.id == id)
        {
            matchEvent.Invoke();
            Debug.Log("Matched ID: " + id);
            
            if (objectCollider != null)
            {
                objectCollider.enabled = false;
            }

            gameObject.SetActive(false);
        }
        else
        {
            noMatchEvent.Invoke();
            Debug.Log("No Match: " + id);
        }
    }
}
