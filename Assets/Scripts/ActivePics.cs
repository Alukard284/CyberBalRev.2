using UnityEngine;

public class ActivePics : MonoBehaviour
{
    [SerializeField] Animator animator;
    private bool active = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !active)
        {
            animator.SetTrigger("Active");
            active = true;  
        }
    }
}
