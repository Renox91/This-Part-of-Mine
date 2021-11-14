using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement.Move = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
            playerMovement.JumpOrGlide();
        else if (Input.GetButtonUp("Jump"))
            playerMovement.StopGliding();

        if (Input.GetAxis("Vertical") > 0.5f)
            playerMovement.TryClimbing();
    }
}
