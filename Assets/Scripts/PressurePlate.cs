using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    public bool correct = false;

    private void OnTriggerEnter(Collider collision)
    {
        animator.Play("Press");

        if ((CompareTag("Sphere") && collision.gameObject.CompareTag("Sphere")) || (CompareTag("Cube") && collision.gameObject.CompareTag("Cube")))
        {
            correct = true;
            print("YES!");
        }
        else
        {
            correct = false;
            print("NO!");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        animator.Play("Unpress");
        correct = false;
        print("LOHI");
    }
}
