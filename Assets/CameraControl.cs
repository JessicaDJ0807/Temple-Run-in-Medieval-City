using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public float trail_distance = 7.0f;
    public float height_offset = 5.0f;
    public float delay = 0.05f;
    private Transform player_transform;
    private Vector3 tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = player.GetComponent<CharacterController>().center * 3;
        player_transform = player.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = player_transform.position - player_transform.forward * trail_distance;

        offset.y += height_offset;
        transform.position += (offset - transform.position) * delay;
        
        transform.LookAt(player_transform.position + tmp);
    }
}


