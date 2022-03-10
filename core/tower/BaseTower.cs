//
// @brief: 塔基类
// @version: 1.0.0
// @author helin
// @date: 8/20/2018
// 
// 
//
using System.Collections;

public class BaseTower : LiveObject
{
    public BaseTower()
    {
        //设置类型为塔
        m_scType = "tower";

        //状态机对象
        m_statemachine = new StateMachine();

        //设置起作用的单元主体
        m_statemachine.setUnit(this);
    }
    
    //- 每帧循环
    // 
    // @return none
    public virtual void updateLogic() {
        //状态机
        m_statemachine.updateLogic();

        //检测是否已经死亡
        checkIsDead();

        //检测事件
        checkEvent();
    } 

    //- 设置位置
    // 
    // @param position 要设置到的位置
    // @return none
    public override void setPosition(FixVector3 position)
    {
        m_fixv3LogicPosition = position;
    } 

    //- 检测敌兵是否走出攻击范围
    // Some description, can be over several lines.
    // @return value description.
    void checkSoldierOutRange()
    {
        if (null != lockedAttackUnit)
        {
            Fix64 distance = FixVector3.Distance(m_fixv3LogicPosition, lockedAttackUnit.m_fixv3LogicPosition);

            //如果走出攻击范围,则让塔恢复到待机状态
            if (distance > attackRange) {
                setPrevStateName("towerstand");
            } 
        } 
    } 

    //- 检查状态
    // 在冷却状态结束后检测一下当前状态,以便根据当前状态刷新逻辑
    // @return none
    public override void checkStatue()
    {
        checkSoldierOutRange();
    }


    public virtual void Create(string nameValue)
    {
        
    }

    //Init 不一定要在工厂里调用
    //因为有的时候 需要传顺序参数 (批量创建很多个对象，根据顺序设置位置
    //工厂的创作方法可以返回创造的对象  这样就不需要增加传入的方法参数
    //在外部可以调用Init初始化数据
    public virtual void Init(FixVector3 pos)
    {
            
    }
}
