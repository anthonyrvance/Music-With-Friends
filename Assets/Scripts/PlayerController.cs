using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using MidiJack;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private VisualEffect fireworks;

    int[] notes;

    private void Awake()
    {
        notes = new int[0];

        fireworks.outputEventReceived += OnOutputEventReceived;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            fireworks.SendEvent("Fire");
    }

    void OnOutputEventReceived(VFXOutputEventArgs args)
    {
        Debug.Log(args.nameId + " firework explode");

    }

    void NoteOn(MidiChannel channel, int note, float velocity)
    {
        Debug.Log("NoteOn: " + channel + "," + note + "," + velocity);
    }

    void NoteOff(MidiChannel channel, int note)
    {
        Debug.Log("NoteOff: " + channel + "," + note);
    }

    void Knob(MidiChannel channel, int knobNumber, float knobValue)
    {
        Debug.Log("Knob: " + knobNumber + "," + knobValue);
    }

    void OnEnable()
    {
        MidiMaster.noteOnDelegate += NoteOn;
        MidiMaster.noteOffDelegate += NoteOff;
        MidiMaster.knobDelegate += Knob;
    }

    void OnDisable()
    {
        MidiMaster.noteOnDelegate -= NoteOn;
        MidiMaster.noteOffDelegate -= NoteOff;
        MidiMaster.knobDelegate -= Knob;
    }
}
