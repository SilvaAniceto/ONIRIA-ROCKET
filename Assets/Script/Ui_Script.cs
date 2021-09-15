using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui_Script : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text heightText;
    [SerializeField] Text secondStageHT;
    [SerializeField] Button start;
    [SerializeField] Button restart;
    [SerializeField] Button quit;

    void Awake()
    {
        Time.timeScale = 0;
        restart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        secondStageHT.text = "Height: " + Second_Stage.instance.height.ToString("#.00");
        timeText.text = "Fuel Left: " + Rocket_Script.instance.fuelTime.ToString("#0");
        heightText.text = "Max Height: " + Rocket_Script.instance.maxHeight.ToString("#.00");
    }

    public void Initiate()
    {         
        Time.timeScale = 1;
        Rocket_Script.instance.start = true;
        start.gameObject.SetActive(false);
        restart.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
