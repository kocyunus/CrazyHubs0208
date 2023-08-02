using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using YK.Utils;

namespace YK.FeedbackSystem
{
    public class Shaker : Singleton<Shaker>
    {
        public CinemachineVirtualCamera vmCam;

        public CinemachineBasicMultiChannelPerlin vmCamNoise;

        public float shakeDuration = 1f;
        public float shakeAmplitude = 1.2f;
        public float shakeFrequency = 2f;

        public float _shakeElapsedtime;

        // Start is called before the first frame update
        void Start()
        {
            if (vmCam != null)
            {
                vmCamNoise = vmCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            }

        }

        // Update is called once per frame
        void Update()
        {
            if (vmCamNoise == null && vmCam != null)
            {
                vmCamNoise = vmCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            }
            if (vmCam != null && vmCamNoise != null)
            {
                if (_shakeElapsedtime > 0)
                {
                    vmCamNoise.m_AmplitudeGain = shakeAmplitude;
                    vmCamNoise.m_FrequencyGain = shakeFrequency;
                    _shakeElapsedtime -= Time.deltaTime;
                }
                else
                {
                    vmCamNoise.m_AmplitudeGain = 0;
                    vmCamNoise.m_FrequencyGain = 0;
                    _shakeElapsedtime = 0;
                }
            }


        }
        public void Shake(float val = 0.7f) { _shakeElapsedtime = val; }


    }
}