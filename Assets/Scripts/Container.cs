using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Collectible
{

    public Sprite emptyChest;
    public int coinsAmount = 5;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            if (Input.GetKeyDown("z"))
            {
                OnCollect();
            }

        }
    }

    protected override void OnCollect()
    {
        
        if (!collected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Give " + coinsAmount + " coins.");
        }
    }
}
