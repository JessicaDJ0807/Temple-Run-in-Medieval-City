using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    public static UI_Control instance;
    public Animator transition_animator;
    public AudioSource button_sound;

    public void restart()
    {
        SceneManager.LoadScene(1);
        button_sound.Play();
    }

    public void OnEnable()
    {
        // SceneManager.LoadScene(1);
        StartCoroutine(LoadNextScene(1));
    }

    public void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    IEnumerator LoadNextScene(int id)
    {
        transition_animator.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(id);
        transition_animator.SetTrigger("start");
    }
}
