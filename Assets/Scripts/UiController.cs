using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour {
    public GameObject pnEndGame;
    public Button btnRestart;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    public Text txtPoint;
    public int maxPoint = 2;
    private int gamePoint;
    AudioSource audio;
    private Text txtEndPoint;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        pnEndGame.SetActive(false);
        audio = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(gamePoint == maxPoint)
        {
            try
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            catch { return; }
        }
            
    }
    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }
    public void ButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;

    }
    public void ButtonIdile()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;

    }
    public void ButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;

    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void EndGame()
    {
        audio.Play();
        Time.timeScale = 0;
        pnEndGame.SetActive(true);
        //txtEndPoint.text = "Your point: " + gamePoint.ToString();
    }
}
