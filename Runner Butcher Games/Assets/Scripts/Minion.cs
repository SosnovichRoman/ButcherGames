using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Minion : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private float rotateTime;
    public MinionContainer minionContainer;
    private CapsuleCollider col;

    private void Start()
    {
        animator.SetFloat("f_speed", 1f);
        col = GetComponent<CapsuleCollider>();
        minionContainer = transform.parent.GetComponent<MinionContainer>();
    }

    public void Death()
    {
        col.enabled = false;
        minionContainer.DeleteMinion(this);
        transform.parent = null;
        animator.SetFloat("f_speed", 0f);
        transform.DOLocalRotate(new Vector3(0, 360, 0), rotateTime, RotateMode.FastBeyond360).SetRelative(true)
            .OnComplete(() => transform.DOLocalRotate(new Vector3(-90, 0, 0), rotateTime)
            .OnComplete(() => animator.enabled = false));
    }
}
