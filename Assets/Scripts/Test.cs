using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public string path = "event:/Music/Music";

    public Vector3 position;
    public float volume = 1.0f;

	// Use this for initialization
	void Start () {
	
	}

    FMOD.Studio.EventInstance instance;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (instance != null)
            {
                //instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                instance.release();
            }

            instance = FMOD_StudioSystem.instance.GetEvent(path);
            if (instance != null)
            {
                var attributes = FMOD.Studio.UnityUtil.to3DAttributes(position);
                ERRCHECK(instance.set3DAttributes(attributes));
                ERRCHECK(instance.setVolume(volume));
                instance.start();
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            instance.release();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
        }
	}

    public int SurfaceValue = 10;
    bool playFlag = false;
    void OnMouseDown()
    {
        if (playFlag)
        {
            playFlag = false;
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
            instance = null;
        }
        else
        {
            if (instance != null)
            {
                //instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                instance.release();
            }

            instance = FMOD_StudioSystem.instance.GetEvent(path);
            if (instance != null)
            {
                var attributes = FMOD.Studio.UnityUtil.to3DAttributes(position);
                ERRCHECK(instance.set3DAttributes(attributes));
                ERRCHECK(instance.setVolume(volume));
                instance.setParameterValue("Surface", SurfaceValue);
                instance.start();
            }

            playFlag = true;
        }
    }
    static bool ERRCHECK(FMOD.RESULT result)
    {
        return FMOD.Studio.UnityUtil.ERRCHECK(result);
    }
}
