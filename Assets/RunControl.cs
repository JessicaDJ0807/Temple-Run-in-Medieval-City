using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunControl : MonoBehaviour
{
    public Animator animator;
    public Animator monster_animator;
    public float speed = 10.0f;
    public AudioSource trip_sound, lose_sound;
    private CharacterController character_controller;

    public Text gameover_text;
    // public Text congrats_text, finished_text;
    public Button restart_button;

    // Start is called before the first frame update
    void Start()
    {
        character_controller = GetComponent<CharacterController>();
        animator.SetBool("run", true);
        animator.SetBool("jump", false);
        animator.SetBool("fall", false);
        animator.SetBool("trip", false);
    }

    // Update is called once per frame
    void Update()
    {
        bool is_run = animator.GetBool("run");
        bool is_jump = animator.GetBool("jump");
        bool is_trip = animator.GetBool("trip");
        bool is_fall = animator.GetBool("fall");

        // fall out or get hit
        if (transform.position.y < 0.1 || monster_animator.GetBool("hit"))
        {
            if (!is_fall) {
                lose_sound.Play();
            }
            animator.SetBool("fall", true);
            animator.SetBool("run", false);
            gameover_text.gameObject.SetActive(true);
            restart_button.gameObject.SetActive(true);
            return;
        }

        // move forward
        if (is_run) {
            character_controller.SimpleMove(new Vector3(0f, 0f, 0f));
            character_controller.Move(transform.forward * speed * Time.deltaTime);
        }

        // jump
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            animator.SetBool("jump", true);
        } else {
            animator.SetBool("jump", false);
        }

        // if the Rabbit is not at state "trip" or state "jump"
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("trip") && !animator.GetCurrentAnimatorStateInfo(0).IsName("jump"))
        {
            // turn left
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                transform.Rotate(new Vector3(0f, -30f, 0f));
            }
            // turn right
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                transform.Rotate(new Vector3(0f, 30f, 0f));
            }
        }

        if (!is_jump && transform.position.y > 7) {
            if (!is_trip) {
                trip_sound.Play();
            }
            animator.SetBool("trip", true);
        } else {
            animator.SetBool("trip", false);
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
