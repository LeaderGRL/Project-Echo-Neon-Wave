using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  System.IO;
using  System.Linq;

public class RotateMenu : MonoBehaviour
{
 private float posX;
    private float posY;
    private int first = 0;
    private List<Button> buttons = new List<Button>();
    private Button[] carousel;
    public Button SelectedMusic;

    // Start is called before the first frame update
    void Start()
    {

        GetObject();
        carousel = new Button[4];
        ChangeCarousel(0);
        carousel[carousel.Length - 1].gameObject.SetActive(false);
        setOpacity();
        SetMusic();

    }


    void GetObject()
    {
        GameObject[] btn = GameObject.FindGameObjectsWithTag("Music");
        for (int i = 0; i < btn.Length; i++)
        {
            buttons.Add(btn[i].GetComponent<Button>());
        }
        foreach (Button i in buttons)
        {
            i.gameObject.SetActive(false);
        }

    }


    void SetMusic()
    {
        float ypos = 0;
        for (int i = 0; i < carousel.Length; i++)
        {
            if (carousel[i] != null)
            {
                if (i == 1)
                {
                    ypos += 32;
                    carousel[i].transform.position = new Vector2(this.transform.position.x + 0, this.transform.position.y + ypos);
                    ypos += 32;
                }
                else
                {
                    carousel[i].transform.position = new Vector2(this.transform.position.x + 0, this.transform.position.y + ypos);
                }
            }
            ypos += 168;
        }
        setOpacity();
    }

    void setOpacity()
    {
        for (int i = 0; i < carousel.Length; i++)
        {
            if (carousel[i] != null)
            {
                carousel[i].gameObject.SetActive(true);
                if (i == 1)
                {
                    carousel[i].GetComponent<Image>().color = Color.white;
                    carousel[i].transform.Find("Artist").GetComponent<Text>().color = Color.white;
                    carousel[i].transform.Find("Title").GetComponent<Text>().color = Color.white;
                    carousel[i].GetComponent<RectTransform>().localScale = new Vector2(1, 1);
                    OnChange(carousel[i]);
                }
                else
                {
                    carousel[i].GetComponent<Image>().color = new Color32(160, 107, 250,200);
                    carousel[i].transform.Find("Artist").GetComponent<Text>().color = new Color32(160, 107, 250,200);
                    carousel[i].transform.Find("Title").GetComponent<Text>().color = new Color32(160, 107, 250,200);
                    carousel[i].GetComponent<RectTransform>().localScale = new Vector2(0.66f, 0.66f);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && first != -1)
        {
            ChangeCarousel(-1);
            SetMusic();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && first != buttons.Count - 2)
        {
            ChangeCarousel(1);
            SetMusic();
        }
    }

    void HideCarrousel()
    {
        foreach (Button music in carousel)
        {
            if (music != null)
            {

                music.gameObject.SetActive(false);
            }
        }
    }

    void ChangeCarousel(int nbr)
    {
        first += nbr;
        HideCarrousel();
        for (int i = 0; i < carousel.Length; i++)
        {
            if ((first + i) <= buttons.Count - 1 && (first + i) >= 0)
            {
                carousel[i] = buttons[first + i];
            }
            else
            {
                carousel[i] = null;
            }
        }
    }


    void OnChange(Button music)
    {
        if (SelectedMusic != null)
        {
            SelectedMusic.GetComponentInChildren<AudioSource>().Stop();
        }
        SelectedMusic = music;

        SelectedMusic.GetComponentInChildren<AudioSource>().Play();
        GameObject.Find("SelectImage").GetComponent<Image>().sprite = music.transform.Find("SongImg").GetComponent<Image>().sprite;
        GameObject.Find("SelectArtist").GetComponent<Text>().text = music.transform.Find("Artist").GetComponent<Text>().text;
        GameObject.Find("SelectTitle").GetComponent<Text>().text = music.transform.Find("Title").GetComponent<Text>().text;
        GameObject.Find("SelectBpm").GetComponent<Text>().text = music.transform.Find("Bpm").GetComponent<Text>().text;
        float duration = music.transform.Find("Audio Source").GetComponent<AudioSource>().clip.length;
        string minutes = Mathf.Floor(duration / 60).ToString();
        string seconds = (duration % 60).ToString("00");
        GameObject.Find("SelectTime").GetComponent<Text>().text = minutes + ":" + seconds;


    }
}
