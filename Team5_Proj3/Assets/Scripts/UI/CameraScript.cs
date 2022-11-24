using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform position;
    [SerializeField] float speed;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = player.moveSpeed;
        this.transform.position = Vector3.MoveTowards(transform.position, position.position, Time.deltaTime * speed);
    }
}
