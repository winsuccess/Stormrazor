﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class SceneChanger : MonoBehaviour
    {

        public void ChangeScene(int scene)
        {
            SceneManager.LoadScene(scene);
        }
    }

