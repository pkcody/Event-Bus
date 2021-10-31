using UnityEngine;
public class Client : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.InitializeGame();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            InventoryManager.Instance.AddItem(001);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            InventoryManager.Instance.RemoveItem(023);
        }
    }
}
