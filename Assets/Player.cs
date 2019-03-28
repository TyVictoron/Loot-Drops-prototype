using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int level = 0;

    public void LevelUp()
    {
        if (level != 20) level++;
    }

    public void LevelDown()
    {
        if (level != 0) level--;
    }
}
