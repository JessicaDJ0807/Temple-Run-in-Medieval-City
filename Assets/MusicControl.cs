using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
