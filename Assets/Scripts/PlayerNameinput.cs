using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameinput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var playerName = gameObject.GetComponent<InputField>();
        playerName.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string name)
    {
        DataManager.instance.playerName = name;
    }
}
