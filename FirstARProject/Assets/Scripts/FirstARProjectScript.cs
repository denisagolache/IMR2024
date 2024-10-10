using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstARProjectScript : MonoBehaviour
{
    public GameObject wizard1;  
    public GameObject wizard2;  

    public float minimumDistance = 0.25f;  

    private Animator wizard1Animator;
    private Animator wizard2Animator;

    void Start()
    {
        wizard1Animator = wizard1.GetComponent<Animator>();
        wizard2Animator = wizard2.GetComponent<Animator>();

        if (wizard1Animator == null || wizard2Animator == null)
        {
            Debug.LogError("Animator component is missing on one of the wizards.");
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(wizard1.transform.position, wizard2.transform.position);

        if (distance <= minimumDistance)
        {
            wizard1Animator.SetBool("isAttacking", true);

            wizard2Animator.SetBool("isAttacking", true);

            Debug.Log("Wizards are in attack range");
        }
        else
        {
            wizard1Animator.SetBool("isAttacking", false);

            wizard2Animator.SetBool("isAttacking", false);

            Debug.Log("Wizards are in idle");
        }
    }
}
