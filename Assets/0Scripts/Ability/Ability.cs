using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float cooldown = 1f;
    public int level = 1;
    public int maxLevel = 4;

    protected float timer;

    public virtual void Tick()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            timer = 0;
            Activate();
        }
    }

    public void LevelUp()
    {
        if (level < maxLevel)
        {
            level++;
            Debug.Log(gameObject.name + " Ability Level : " + level);
        }
    }

    protected abstract void Activate();
}