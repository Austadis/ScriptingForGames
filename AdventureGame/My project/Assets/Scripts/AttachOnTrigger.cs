using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachOnTrigger : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            transform.SetParent(other.transform);
        }
    }
}
