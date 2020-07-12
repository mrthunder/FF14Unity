using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public SkillEffect EffectPrefab = null;
    public Sprite Icon => EffectPrefab.Icon;
    public string Name => EffectPrefab.Name;
    public string Effect => EffectPrefab.Effect;
    // How long it takes to cast
    public float Cast => EffectPrefab.Cast;
    // How long it takes to recast / cooldown
    public float Recast => EffectPrefab.Recast;
    public SkillEffect.Type SkillType => EffectPrefab.SkillType;
    public int MpCost => EffectPrefab.MpCost;


    // Those variables will store the moment when the skill was activated or the cooldown started
    protected float RecastTime = 0f;
    protected float CastingTime = 0f;

    private StatsComponent _target = null;
    private StatsComponent _user = null;
    private Vector3 _worldSpaceTargetLocation = Vector3.zero;

    private bool _isChoosingLocation = false;

    public void SkillUpdate(in FFInputActions inputActions)
    {
        if (CastingTime > 0 && DidFinishedCasting())
        {
            CastingTime = 0;
            Use();
            StartCoolDown();
        }
        if (RecastTime > 0 && !IsInCoolDown())
        {
            RecastTime = 0;
            _target = null;
        }
        if (_isChoosingLocation)
        {
            ChooseTargetLocation(inputActions);
        }
    }

    private void ChooseTargetLocation(in FFInputActions inputActions)
    {
        // I am going to display an image on the game when that happens.
        // The image will follow the point where the raycast hits.
        Ray mouseRay = Camera.main.ViewportPointToRay(inputActions.Game.MousePosition.ReadValue<Vector2>());
        // I am putting the ground in a layer so it is easy to avoid other objects
        const int GROUND_LAYER = 1 << 11;
        if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, EffectPrefab.Range, GROUND_LAYER))
        {
            // TODO - Add and control game objects position on the map
            // As soon as the player press the mouse, the location is saved.
            if (inputActions.Game.MouseLeftClick.triggered)
            {
                _worldSpaceTargetLocation = hitInfo.point;
                _isChoosingLocation = false;
                CastingTime = Time.time;
            }
        }

    }

    public void StartCasting(StatsComponent user, StatsComponent target = null)
    {

        if (CastingTime <= 0 && EffectPrefab is TargetSkillEffect && IsTargetInRange(user, target))
        {
            CastingTime = Time.time;
            _target = target;
            _user = user;
        }
        else if (_isChoosingLocation == false && CastingTime <= 0 && EffectPrefab is LocationSkillEffect)
        {
            _isChoosingLocation = true;
            _user = user;
        }

    }

    private void StartCoolDown() => RecastTime = Time.time;

    protected void Use()
    {
        // I need to instantiate the skill effect
        SkillEffect skillEffect = MonoBehaviour.Instantiate(EffectPrefab);
        // I need to differentiate between a skill to be use on the target or at a location
        if (skillEffect is TargetSkillEffect targetEffect)
        {
            targetEffect.ActivateOnTarget(_user, _target);
        }
        else if (skillEffect is LocationSkillEffect locationEffect)
        {
            // TODO - GET THE LOCATION
            locationEffect.ActivateOnLocation(_user, _worldSpaceTargetLocation);
        }
        // pass the correct information to the skill effect.
    }

    protected float GetCooldown()
    {
        float cooldown = (RecastTime + Recast) - Time.time;
        return Mathf.Clamp(cooldown, 0, Recast);
    }

    protected bool IsInCoolDown() => RecastTime + Recast > Time.time;

    /// <summary>
    /// Return the progress of the skill cast between 0 and 1.
    /// </summary>
    public float GetCastingProgress()
    {
        float value = Mathf.Clamp((CastingTime + Cast) - Time.time, 0, Cast);
        return Mathf.InverseLerp(0, Cast, value);
    }

    /// <summary>
    /// Did the skill finished casting?
    /// </summary>
    public bool DidFinishedCasting() => CastingTime + Cast < Time.time;

    public bool IsTargetInRange(StatsComponent user, StatsComponent target)
    {
        return Vector3.Distance(user.transform.position, target.transform.position) <= EffectPrefab.Range;
    }
}
