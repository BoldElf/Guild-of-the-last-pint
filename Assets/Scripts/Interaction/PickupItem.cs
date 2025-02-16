using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public void PickUp()
    {
        gameObject.SetActive(false);
    }
}
