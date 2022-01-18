using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    Bird bird;

    int round;

    public GameObject[] leftSpikes;
    public GameObject[] rightSpikes;

    void Start()
    {
        bird = FindObjectOfType<Bird>();

        DisableSpikes();
    }

    void Update()
    {
        if (bird.dead)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void NextRound()
    {
        round++;

        DrawSpikes();
    }

    public void DrawSpikes()
    {
        DisableSpikes();

        int[] spikePositions = new int[GetSpikeNumber()];

        for (int i = 0; i < spikePositions.Length; i++)
        {
            spikePositions[i] = Random.Range(0, 1);

            for (int ii = 0; ii < i; ii++)
            {
                while (spikePositions[i] == spikePositions[ii])
                {
                    spikePositions[i] = Random.Range(0, 11);

                    ii = 0;
                }
            }
        }

        if (round % 2 != 0)
        {
            for (int i = 0; i < spikePositions.Length; i++)
            {
                leftSpikes[spikePositions[i]].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < spikePositions.Length; i++)
            {
                rightSpikes[spikePositions[i]].SetActive(true);
            }
        }
    }

    void DisableSpikes()
    {
        for (int i = 0; i < leftSpikes.Length; i++)
        {
            leftSpikes[i].SetActive(false);
            rightSpikes[i].SetActive(false);
        }
    }

    int GetSpikeNumber()
    {
        int spikeNumber = 2;

        if (round >= 2) spikeNumber++;

        if (round >= 5) spikeNumber++;

        if (round >= 10) spikeNumber++;

        if (round >= 20) spikeNumber++;

        if (round >= 30) spikeNumber++;

        if (round >= 50) spikeNumber++;

        if (round >= 75) spikeNumber++;

        if (round >= 100) spikeNumber++;

        return spikeNumber;
    }
}
