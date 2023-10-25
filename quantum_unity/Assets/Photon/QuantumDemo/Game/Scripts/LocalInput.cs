using System;
using Photon.Deterministic;
using Quantum;
using UnityEngine;
using UnityEngine.Windows;

public class LocalInput : MonoBehaviour 
{
    private void OnEnable() 
    {
        QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
    }

    public void PollInput(CallbackPollInput callback) 
    {
        Quantum.Input input = new();

        var xAxis = UnityEngine.Input.GetAxis("Horizontal");
        var yAxis = UnityEngine.Input.GetAxis("Vertical");

        input.Direction = new Vector2(xAxis, yAxis).ToFPVector2();

        callback.SetInput(input, DeterministicInputFlags.Repeatable);
    }
}
