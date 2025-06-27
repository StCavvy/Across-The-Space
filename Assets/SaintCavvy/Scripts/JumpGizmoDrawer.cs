using System;
using UnityEngine;

public class JumpGizmoDrawer : MonoBehaviour
{
    private GameObject player;
    private float thrust;
    private float playerMass;
    private float gravityForce;
    private float jumpHeight;


    void Start()
    {
        gameObject.GetComponent<JumpGizmoDrawer>().enabled = false;
    }


    private void OnDrawGizmos()
    {
        player = GameObject.FindWithTag("Player");
        thrust = player.GetComponent<PlayerController>().thrust;
        playerMass = player.GetComponent<Rigidbody2D>().mass;
        gravityForce = -Physics.gravity.y;

        jumpHeight = Mathf.Pow(thrust, 2) / (2f * playerMass * playerMass * gravityForce);

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.up * jumpHeight);
    }
}
