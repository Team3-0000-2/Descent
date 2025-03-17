using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{

    //0 => red, 1 => blue, 2 => yellow, 3 => empty

    [SerializeField] private byte doorType;
    [SerializeField] private InventoryMananger _inventoryMananger;
    [SerializeField] private bool open;
    [SerializeField] private Animator openDoor;


    private void Awake()
    {
        _inventoryMananger = GameObject.Find("Manager").GetComponent<InventoryMananger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collisione");

        

        //other.CompareTag("Player")

        if (other.TryGetComponent(out Movement Player) && !open)
        {
            Debug.Log("collisione");

            if (doorType != 3)
            {
                if (_inventoryMananger.GetKey(doorType))
                {
                    Debug.Log("animazione porta che si apre");
                    open = true;
                    // openDoor.SetTrigger("OpenDoor");
                    openDoor.SetBool("OpenDoor", true);
                }
            } else 
            {
                Debug.Log("animazione porta che si apre");
                openDoor.SetBool("OpenDoor", true);

                open = true;
            }
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Movement Player) && open)
        {
            Debug.Log("animazione porta che si chiude");
            openDoor.SetBool("OpenDoor", false);
            open = false;
        }
    }
}
