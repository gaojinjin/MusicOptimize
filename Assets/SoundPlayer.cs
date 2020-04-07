using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] audioList;
    public Button nextBut, lastBut, pauseBut;
    public Transform butGroup;
    private int indexValue = 0,addOrMinusValue = 1;
    private AudioSource source;
    public Text singName,pauseState;
    void Start()
    {
        source = GetComponent<AudioSource>();
        foreach (Button item in butGroup.GetComponentsInChildren<Button>()){
            item.onClick.AddListener(ButEvent);
        }
    }

    private void ButEvent()
    {
        string butName = EventSystem.current.currentSelectedGameObject.name;
        
        if (butName != pauseBut.name){
            if (butName.Equals("nextBut"))
            {
                addOrMinusValue = 1;
            }
            else
            {
                addOrMinusValue = -1;
            }
            indexValue += addOrMinusValue;
            //处理溢出索引的问题
            if (indexValue>= audioList.Length-1)
            {
                indexValue = 0;
            }
            else if(indexValue<0)
            {
                indexValue = audioList.Length-1;
            }
            source.clip = audioList[indexValue];
            source.Play();
            singName.text = audioList[indexValue].name;
        }
        else
        {
            if (source.isPlaying){
                source.Pause();
                pauseState.text = "||";
            }
            else{
                source.Play();
                pauseState.text = "》";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
