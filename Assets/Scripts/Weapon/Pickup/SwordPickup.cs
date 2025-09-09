using UnityEngine;

public class SwordPickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var swordHandler = other.GetComponent<PlayerSwordHandler>();
            swordHandler.EquipSword();

            Destroy(gameObject);
        }
    }

}