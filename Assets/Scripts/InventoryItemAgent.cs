using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemAgent : MonoBehaviour {

    public InventoryItem item;
    public bool hasBeenCollected = false;
    public bool shouldBeDestroyed = true;

   
    public void OnTriggerEnter(Collider other)
    {
    
        if (hasBeenCollected||!shouldBeDestroyed){
            return;        
        }
        
        if(other.gameObject.tag.Equals("Player")){

            hasBeenCollected = true;
            InventoryItem collectedItem = new InventoryItem();
            collectedItem.CopyInventoryItem(item);
            GameMaster.sharedInstance.inventory.AddItem(collectedItem);
            GameMaster.sharedInstance.RpgDestroy(gameObject);
        }
    }

}
