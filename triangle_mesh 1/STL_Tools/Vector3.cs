/**
  ******************************************************************************
  * @file    Vector3.cs
  * @author  Ali Batuhan KINDAN
  * @version V1.0.0
  * @date    03.07.2018
  * @brief   
  ******************************************************************************
  */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace STL_Tools
{

    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        /**
        * @brief  Class instance constructor
        * @param  none
        * @retval none
        */
        public Vector3(float xVal = 0, float yVal = 0, float zVal = 0)
        {
            x = xVal;
            y = yVal;
            z = zVal;
        }

    }
}