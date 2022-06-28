using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionIdle : MonoBehaviour
{
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private GameObject particlePrefab;
    //private 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Minion>(out Minion minion))
        {
            Destroy(gameObject);
            GameObject created = Instantiate(minionPrefab, transform.position, minionPrefab.transform.rotation, minion.minionContainer.transform);
            GameObject particle = Instantiate(particlePrefab, transform.position, particlePrefab.transform.rotation);
            Destroy(particle, 3f);
            minion.minionContainer.AddMinion(created.GetComponent<Minion>());

        }
    }
}
