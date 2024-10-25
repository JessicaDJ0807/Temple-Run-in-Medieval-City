using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public Animator animator;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // move forward if sneaking
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("sneak") || animator.GetCurrentAnimatorStateInfo(0).IsName("sneak 1")) {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }

        // Quit game on Esc
        if (Input.GetKey(KeyCode.Escape)) {            
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
