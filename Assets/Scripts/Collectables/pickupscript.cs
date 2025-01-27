using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class pickupscript : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}