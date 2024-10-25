using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    public Transform rabbit_transform;
    public Animator rabbit_animator;
    public Animator animator;
    public float speedup = 1.0f;
    private CharacterController character_controller;

    // Start is called before the first frame update
    void Start()
    {
        character_controller = GetComponent<CharacterController>();
        animator.SetBool("hit", false);
    }

    // Update is called once per frame
    void Update()
    {
        // catch rabbit
        // float dist = Vector3.Distance(rabbit_transform.position, transform.position);
        if (Vector3.Distance(rabbit_transform.position, transform.position) < 2.5) {
            animator.SetBool("hit", true);
        }

        // if "trip" happens, get closer to the rabbit
        if (rabbit_animator.GetBool("trip") && !rabbit_animator.GetBool("fall")) {
            transform.Translate(new Vector3(0, 0, 1) * speedup * Time.deltaTime);
        }
    }
}
