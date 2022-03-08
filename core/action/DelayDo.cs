//
// @brief: 延迟执行的事件
// @version: 1.0.0
// @author helin
// @date: 8/20/2018
// 
// 
//
using System.Collections;

public class DelayDo : BaseAction {

    Fix64 m_fixPlanTime = Fix64.Zero; //延迟时间
    Fix64 m_fixElapseTime = Fix64.Zero;

    public override void updateLogic()
    {
        m_fixElapseTime = m_fixElapseTime + GameData.g_fixFrameLen;

        //到达延迟时间后 开始执行回调
        if (m_fixElapseTime >= m_fixPlanTime) {
            removeSelfFromManager(); 

            if (null != actionCallBackFunction)
            {
                actionCallBackFunction();
            }
        }
    }

    public void init(Fix64 time, ActionCallback cb)
    {
        name = "delaydo";
        m_fixPlanTime = time;
        actionCallBackFunction = cb;
    }
}
