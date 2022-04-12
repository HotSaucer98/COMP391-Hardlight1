using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitchDualController : MonoBehaviour
{
    public Platforms platform;
    private float normalSpeed;
    public string crystalColor1 = "Red";
    public string crystalColor2 = "Blue";
    private bool PlayerInRange = false;
    private int counter = 0;
    private bool isActive = false;
    public GameObject crystalHolder;
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
            if (isActive == false)
            {
                Activate();
            }

        }
        else if (!PlayerInRange)
        {
            Deactivate();
        }
    }

    public void Activate()
    {
        if (Otherswitch.isActive == true)
        {
            platform.speed = 2.5f;
        }

    }

    public void Deactivate()
    {
        isActive = false;
        platform.speed = 0;
        //crystalHolder.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            PlayerInRange = true;
            collision.GetComponent<SpriteRenderer>().enabled = false;
            crystalHolder.GetComponent<SpriteRenderer>().sprite = collision.GetComponent<SpriteRenderer>().sprite;
        }
        if (collision.name.Equals(crystalColor2))
        {
            isActive = true;
            Debug.Log(isActive);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            PlayerInRange = false;
            collision.GetComponent<SpriteRenderer>().enabled = true;
            crystalHolder.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

}
