using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Data.Common;

public class ScreenShakeManager : Singleton<ScreenShakeManager>
{
    private CinemachineImpulseSource source;

    protected override void Awake()
    {
        base.Awake();

        source = GetComponent<CinemachineImpulseSource>();

    }

    public void ShakeScene()
    {
        source.GenerateImpulse();
    }

}
