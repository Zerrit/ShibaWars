
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityTemplate", menuName = "Ability/AbilityTemplate")]
public class AbilityTemplate : ScriptableObject
{
    public Ability ability;
    public ButtonParameters buttonParameters;
    public ObjectPooller<Ability> pool;
}
