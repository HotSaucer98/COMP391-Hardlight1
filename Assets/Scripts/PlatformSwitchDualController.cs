using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitchDualController : MonoBehaviour
{
    public Platforms platform;
    private float normalSpeed;
    private bool PlayerInRange = false;
    private int counter = 0;
    private bool isActive = false;
    public PlatformSwitchDualController Otherswitch;

    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = platform.speed;
        platform.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && isActive == false)
            {
                Activate();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isActive == true)
            {
                Deactivate();
                isActive = false;
            }
        }
    }

    public void Activate()
    {
        if (Otherswitch.isActive == true)
        {
            platform.speed = 4f;
        }

        isActive = true;
       
    }

    public void Deactivate()
    {
        platform.speed = 0;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }
}
