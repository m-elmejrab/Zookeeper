using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement movementScript;
    private PlayerMeatPlacer meatPlacerScript;
    private PlayerCleaner cleaningScript;
    void Start()
    {
        movementScript = GetComponent<PlayerMovement>();
        meatPlacerScript = GetComponent<PlayerMeatPlacer>();
        cleaningScript = GetComponent<PlayerCleaner>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;
        movementScript.SetDirection(direction);

        if(Input.GetKeyUp(KeyCode.LeftShift))
            movementScript.ToggleRunning();
        
        if (Input.GetKeyUp(KeyCode.Space))
            movementScript.Jump();
        
        if(Input.GetKeyUp(KeyCode.R))
            meatPlacerScript.PlaceMeat();
        
        if(Input.GetKeyUp(KeyCode.E))
            cleaningScript.Clean();
            

    }
}
