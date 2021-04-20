using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        foreach (Item item in controller.player.currentLocation.items)
        {
            if (item.isEnabled && item.itemName.ToLower() == noun.ToLower())
            {
                if (item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.currentText.text = $"You take the {item.itemName}";
                    return;
                }
            }
        }

        controller.currentText.text = "You can't get that";
    }
}
