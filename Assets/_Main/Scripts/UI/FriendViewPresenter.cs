﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendViewPresenter : MonoBehaviour
{
    [SerializeField] private Text friendText;
    [SerializeField] private MissionData currentData;

    // Update is called once per frame
    void Update()
    {
        friendText.text = currentData.friendM.ToString();
    }
}
