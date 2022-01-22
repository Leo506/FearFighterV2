using System.Collections;
using System.Collections.Generic;
using UnityEngine;


struct PlayTime
{
    public int seconds { get; private set; }
    public int minutes { get; private set; }

    public PlayTime(int min = 0, int sec = 0)
    {
        minutes = min;
        seconds = sec;
    }

    public void AddMin(int min)
    {
        minutes += min;
        if (minutes >= 60)
            minutes = 0;
    }

    public void AddSec(int sec)
    {
        seconds += sec;
        if(seconds >= 60)
        {
            minutes += seconds / 60;
            seconds %= 60;
        }
    }
}

public class TimerController : MonoBehaviour, IObserver, IResetObj
{
    static PlayTime playTime = new PlayTime();

    [SerializeField] UnityEngine.UI.Text timeText;

    private void Start()
    {
        StartCoroutine(UpdateTimer());
        Subject.instance.AddObserver(this);
    }

    public void OnNotify(EventList eventValue)
    {
        if (eventValue == EventList.NEXT_LVL)
            StopAllCoroutines();
    }

    public void ResetObj()
    {
        playTime = new PlayTime();
    }

    void UpdateTimeText()
    {
        timeText.text = playTime.minutes + ":" + playTime.seconds;
        Debug.Log(playTime);
    }

    IEnumerator UpdateTimer()
    {
        while (true)
        {
            playTime.AddSec(1);
            UpdateTimeText();
            yield return new WaitForSeconds(1);
        }
    }
}
