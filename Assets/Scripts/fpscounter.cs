using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpscounter : MonoBehaviour
{
    public int avgFrameRate;
    public Text display_Text;
    public Text[] line = new Text[11];
    public GameObject[] humans = new GameObject[11];
    public GameObject[] order = new GameObject[11];



    void Update()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";


        for (int i = 0; i < 11; i++)
        {
            int min = i;
            for (int j = i + 1; j < 11; j++)
            {
                if (humans[j].transform.position.z < humans[min].transform.position.z)
                {
                    min = j;
                }
            }
            GameObject temp = humans[i];
            humans[i] = humans[min];
            humans[min] = temp;
        }

        line[0].text = humans[10].name;
        line[1].text = humans[9].name;
        line[2].text = humans[8].name;
        line[3].text = humans[7].name;
        line[4].text = humans[6].name;
        line[5].text = humans[5].name;
        line[6].text = humans[4].name;
        line[7].text = humans[3].name;
        line[8].text = humans[2].name;
        line[9].text = humans[1].name;
        line[10].text = humans[0].name;
    }
}

