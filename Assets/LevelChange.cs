using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : Collidable
{

    public string sceneName;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            //change level
            SceneManager.LoadScene(sceneName);
        }
    }
}
