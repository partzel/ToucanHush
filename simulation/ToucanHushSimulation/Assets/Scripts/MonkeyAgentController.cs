using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.InputSystem;

public class MonkeyAgentController : Agent
{
    public GameObject toucan;
    private ToucanMover toucanMover;
    public float ToucanHitReward = 1;
    MonkeyMover monkeyMover;
    MonkeyBananaThrow monkeyBananaThrow;


    public void Start()
    {
        monkeyMover = GetComponent<MonkeyMover>();
        monkeyBananaThrow = GetComponent<MonkeyBananaThrow>();
        toucanMover = toucan.GetComponent<ToucanMover>();
        monkeyBananaThrow.ToucanScored += OnToucanScored;
    }

    public void FixedUpdate()
    {
        AddReward(-0.001f);
    }

    public override void OnEpisodeBegin()
    {
        SetReward(0);
        monkeyBananaThrow.isThrowing = false;
        monkeyMover.ResetTransform();
        toucanMover.ResetTransform();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(transform.rotation.y);
        sensor.AddObservation(toucan.transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        var action = actions.DiscreteActions[0];

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

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        discreteActions.Clear();

        int action = -1;

        if (monkeyMover.isMoveBackward)
            action = 0;
        else if (monkeyMover.isMoveForward)
            action = 1;
        else if (monkeyMover.isTurnLeft)
            action = 2;
        else if (monkeyMover.isTurnRight)
            action = 3;
        else if (monkeyMover.isThrowBanana)
            action = 4;

        // noop
        if (action == -1)
            action = 5;

        discreteActions[0] = action;
    }

    private void OnToucanScored()
    {
        AddReward(ToucanHitReward);
        EndEpisode();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            AddReward(-1f);
            EndEpisode();
        }
    }
}
