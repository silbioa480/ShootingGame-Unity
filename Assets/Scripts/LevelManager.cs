using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text LevelUI;
    public int Level = 0;
    public float sec = 5;
    public bool levelSwitch = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(addLevel(sec));
    }
    IEnumerator addLevel(float delayTime)
    {
        Level++;
        LevelUI.text = "Level " + Level;
        levelSwitch = true;

        yield return new WaitForSeconds(delayTime);
        StartCoroutine(addLevel(sec));
    }

    public static LevelManager Instance = null;
    public void Awake()
    {
        if(Instance == null) Instance = this;
    }
    // Update is called once per frame

    void Update()
    {
    }

    public int level
    {
        get
        {
            return Level;
        }
        set
        {
            Level = level;
            LevelUI.text = "Level " + Level;
        }
    }
}
