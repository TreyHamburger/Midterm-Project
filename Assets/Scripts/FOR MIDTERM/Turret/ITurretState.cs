

public interface ITurretState
{
    void Enter(Turret turret);
    void Update();
    void Exit();
}

public class IdleState : ITurretState
{
    private Turret turret;

    public void Enter(Turret turret)
    {
        this.turret = turret;
        turret.StopShooting();
    }

    public void Update()
    {
       if(turret.CanSeePlayer())
        {
            turret.ChangeState(new AttackState());
        }
    }

    public void Exit()
    {

    }
}

public class AttackState : ITurretState
{
    private Turret turret;

    public void Enter(Turret turret)
    {
        this.turret = turret;
        turret.StartShooting();
    }

    public void Update()
    {
        if(turret.CanSeePlayer())
        {
            turret.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {
        turret.StopShooting();
    }
}
