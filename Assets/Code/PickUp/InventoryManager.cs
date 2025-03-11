using UnityEngine;

public class InventoryMananger : MonoBehaviour
{
    //type 0 => Ammo - 2 => Score - 1 => keys (0 => red, 1 => blue, 2 => yellow)

    [Header("--- Ammo --- ")]
    [SerializeField]
    private int[] Ammo;


    [Header("--- Keys --- ")]
    [SerializeField]
    private bool[] Keys;
    

    [Header("--- Score --- ")]
    [SerializeField]
    private int score;

    public void SetAmmo(int ammoToAdd, byte subtype)
    {
        Ammo[subtype] += ammoToAdd;
    }

    public int GetAmmo(byte subtype)
    {
        return Ammo[subtype];
    }

    public void SetScore(int scoreToAdd) 
    {
        score += scoreToAdd;
    }

    public int GetScore() 
    {
        return score;
    }

    public void SetKey(byte subtype) 
    {
        Keys[subtype] = true;
    }

    public bool GetKey(byte subtype)
    {
        return Keys[subtype];
    }

}
