using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class MonkeyAgentController : Agent
{
    [SerializeField] public Transform toucan;
    MonkeyMover monkeyMover;
    MonkeyBananaThrow monkeyBananaThrow;

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(transform.rotation.y);
        sensor.AddObservation(toucan.transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        var action = actions.DiscreteActions[0];
        Debug.Log($"Chose action: {actions.DiscreteActions[0]}");

        if (monkeyBananaThrow.isThrowing)
            return;

        switch (action)
            {
                case 0:
                    monkeyMover.MoveBackward();
                    break;
                case 1:
                    monkeyMover.MoveForward();
                    break;
                case 2:
                    monkeyMover.TurnLeft();
                    break;
                case 3:
                    monkeyMover.TurnRight();
                    break;
                case 4:
                    monkeyBananaThrow.ThrowBanana();
                    break;
                default:
                    monkeyMover.Noop();
                    break;

            }
    }
}
