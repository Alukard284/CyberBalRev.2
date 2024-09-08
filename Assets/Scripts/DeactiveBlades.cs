using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveBlades : MonoBehaviour
{
    [SerializeField] Animator bladesAnimator;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bladesAnimator.SetBool("Active", false);
        }
    }
}
