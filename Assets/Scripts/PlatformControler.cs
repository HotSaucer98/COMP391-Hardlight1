using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControler : MonoBehaviour
{
    public Platforms platform;
    public string crystalColor = "White";
    private float normalSpeed;
    private bool PlayerInRange = false;
    private bool isActive = false;
    public GameObject crystalHolder;
    // Start is called before the first frame update
    void Start()
    {
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

        }else if(!PlayerInRange)
        {
            Deactivate();
        }
    }

    public void Activate()
    {
        platform.speed = 4;

        isActive = true;
        crystalHolder.GetComponent<SpriteRenderer>().sprite = crystalHolder.GetComponent<SpriteRenderer>().sprite; 
    }

    public void Deactivate()
    {
        isActive = false;
        platform.speed = 0;
        crystalHolder.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            PlayerInRange = true;
            Debug.Log(PlayerInRange);
            collision.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") && collision.name.Equals(crystalColor))
        {
            PlayerInRange = false;
            Debug.Log(PlayerInRange);
            collision.GetComponent<SpriteRenderer>().enabled = true;
        }
    }


}
