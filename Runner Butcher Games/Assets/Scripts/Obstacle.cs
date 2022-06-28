using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Minion>(out Minion minion))
        {
            minion.Death();
            GameObject particle = Instantiate(particlePrefab, minion.transform.position, particlePrefab.transform.rotation);
            Destroy(particle, 3f);
        }
    }
}
