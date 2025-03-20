using UnityEngine;

public class Collectibles : MonoBehaviour
{
    
    [SerializeField] private InventoryMananger _inventoryManager;
    [SerializeField] private byte type;
    [SerializeField] private byte subtype;
    [SerializeField] private int quantityToAdd;

    private void Awake()
    {
        _inventoryManager = GameObject.Find("Manager").GetComponent<InventoryMananger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (type)
        {
            case 0:
                _inventoryManager.SetAmmo(quantityToAdd, subtype);
                break;
            case 1:
                _inventoryManager.SetKey(subtype);
                break;
            case 2:
                _inventoryManager.SetScore(quantityToAdd);
                break;
        }

        Debug.Log("disattivazione key");
        //gameObject.SetActive(false);

    }

}
