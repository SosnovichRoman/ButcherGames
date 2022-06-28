using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MinionContainer : MonoBehaviour
{
    [SerializeField]
    private List<Minion> minions;
    [SerializeField]
    private float forwardSpeed;
    [SerializeField]
    private float moveDuration;

    [SerializeField]
    private Vector2 fieldSize;

    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
    }

    public void SetShape(List<Vector3> positions)
    {
        if (minions == null) return;
        List<Vector3> reducedPositions = new List<Vector3>();
        float normalizeMultiplier = positions.Count / minions.Count;
        for(int i = 0; i < minions.Count; i++)
        {
            int normilizedIndex = (int)Mathf.Floor(normalizeMultiplier * i);
            reducedPositions.Add(positions[normilizedIndex]);
        }
        ReplaceMinions(reducedPositions);
    }

    private void ReplaceMinions(List<Vector3> positions)
    {
        for(int i = 0; i < minions.Count; i++)
        {
            Vector3 target = new Vector3(positions[i].x * fieldSize.x, positions[i].y, positions[i].z * fieldSize.y);
            minions[i].transform.DOLocalMove(target, moveDuration);
        }
    }

    public void DeleteMinion(Minion minion)
    {
        minions.Remove(minion);
        if (minions.Count == 0) forwardSpeed = 0;
    }

    public void AddMinion(Minion minion)
    {
        minions.Add(minion);
    }
}
