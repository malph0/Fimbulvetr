using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehavior : MonoBehaviour
{

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.System studioSystem;

    void Start()
    {
        InitializeFMOD();
        LoadBanks();
        // Other audio-related setup
    }

    void InitializeFMOD()
    {
        FMOD.Studio.System.create(out studioSystem);
        studioSystem.initialize(512, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
    }

    void LoadBanks()
    {
        FMOD.Studio.Bank bank;
        studioSystem.loadBankFile("../../FMOD/Final/Build/Desktop/Master.strings.bank", FMOD.Studio.LOAD_BANK_FLAGS.NORMAL, out bank);
    }

}

}
