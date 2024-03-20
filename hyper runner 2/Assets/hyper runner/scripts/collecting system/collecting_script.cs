using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collecting_script : MonoBehaviour
{
    [SerializeField] GameObject _Head;
    private void Start()
    {
        Controller.instance.setHead(_Head);
    }
    private void OnTriggerEnter(Collider other)
    {
        collectable c = other.GetComponent<collectable>();
        if(c!=null) c.On_touch(gameObject);

    }    
    public GameObject GetHead()
    {
        return _Head;
    }

}

public class collectable : MonoBehaviour
{
    
     public AudioClip sound_clip; 
     public int effect_value;
    protected AudioSource controller_audio_source;
    private void Start()
    {
        controller_audio_source = Controller.instance.gameObject.GetComponent<AudioSource>();
    }
    public virtual void On_touch(GameObject g  = null)
    {
        Controller.instance.SetScore(this.effect_value);
        controller_audio_source.clip = sound_clip;
        controller_audio_source.Play();
        Controller.instance.incriase_Head_size(this.effect_value);     

    }
}
