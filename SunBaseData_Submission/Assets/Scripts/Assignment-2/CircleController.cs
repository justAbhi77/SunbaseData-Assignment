using UnityEngine;
using DG.Tweening;

public class CircleController : MonoBehaviour
{
    // public float TimeScale,shakeDuration;
    Collider2D cutcollider;

    // Tweener animator;

    /*
    private void OnEnable()
    {
        animator = transform.DOScale(0,TimeScale).SetEase(Ease.InBack).SetLoops(-1,LoopType.Yoyo);
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetType() != typeof(EdgeCollider2D))
            return;

        // animator.Pause();

        cutcollider = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision == cutcollider)
        {

            Destroy(gameObject);
            /*
            transform.DOShakePosition(shakeDuration,0.3f).OnComplete(() =>
            {
            });
            */
        }
    }
}
