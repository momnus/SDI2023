using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight_Script : MonoBehaviour
{
    public DayNightController dnc;
     public AK.Wwise.RTPC Time;


    [SerializeField][Range(0, 24f)] private float time;
    private string timeString;


    // Start is called before the first frame update
    void Start()
    {
        dnc = gameObject.GetComponent<DayNightController>();


    }


    void Update()
    {
        CalculateTime();

        time = dnc.currentTime;

          Time.SetGlobalValue(time);


        #region GUI

        void OnGUI()
        {

            string TextGui = "Time " + timeString;
            GUILayout.Box(TextGui);
        }

        void CalculateTime()
        {
            //Is it am of pm?
            string AMPM = "";
            float minutes = ((dnc.currentTime) - (Mathf.Floor(dnc.currentTime))) * 60.0f;
            if (dnc.currentTime <= 12.0f)
            {
                AMPM = "AM";

            }
            else
            {
                AMPM = "PM";
            }
            //Make the final string
            timeString = Mathf.Floor(dnc.currentTime).ToString() + " : " + minutes.ToString("F0") + " " + AMPM;

        }

        #endregion
    }
}
