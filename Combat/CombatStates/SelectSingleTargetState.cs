using Unity.VisualScripting;
using UnityEngine;

public class SelectSingleTargetState : SelectTargetState
{
    protected override void OnTargetClick(Character target)
    {
        //Targeted?.Invoke();
        OnTargeted(target);
        actionManager.SetTarget(target);

        //owner.ChangeState<PerformActionState>();
        owner.ChangeState<AnimateActionState>();
    }
}
