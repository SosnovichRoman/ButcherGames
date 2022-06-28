using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lantern : MonoBehaviour
{
    private float range = 12f;
    void Start()
    {
        RandomRotate();
    }

    void RandomRotate()
    {
        Vector3 target = new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
        transform.DOLocalRotate(target, 1.5f).SetEase(Ease.Linear).OnComplete(RandomRotate);
    }
}
