using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlDiapos : MonoBehaviour
{

    public Sprite[] diaposImagesArray;
    public Image displayImage;
    public TextMeshProUGUI diapoCounter;

    public GameObject CheckButton;

    private int diapoID = 0;

    // Start is called before the first frame update
    void Start()
    {
        displayImage.sprite = diaposImagesArray[diapoID];
        diapoCounter.text = $"{diapoID +1}/{diaposImagesArray.Length}";

        DisplayCheckButton();
    }

    public void NextDiapo()
    {
        diapoID++;
        diapoID = Mathf.Clamp(diapoID,0,diaposImagesArray.Length -1);
        displayImage.sprite = diaposImagesArray[diapoID];

        diapoCounter.text = $"{diapoID + 1}/{diaposImagesArray.Length}";

        DisplayCheckButton();
    }

    public void PrevDiapo()
    {
        diapoID--;
        diapoID = Mathf.Clamp(diapoID, 0, diaposImagesArray.Length - 1);
        displayImage.sprite = diaposImagesArray[diapoID];

        diapoCounter.text = $"{diapoID + 1}/{diaposImagesArray.Length}";

        DisplayCheckButton();
    }

    private void DisplayCheckButton()
    {
        if (diapoID == diaposImagesArray.Length - 1)
        {
            CheckButton.SetActive(true);
        }
        else
        {
            CheckButton.SetActive(true);
        }
    }
}
