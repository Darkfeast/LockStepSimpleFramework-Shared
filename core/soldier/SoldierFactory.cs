//
// @brief: 士兵工厂类
// @version: 1.0.0
// @author helin
// @date: 8/20/2018
// 
// 
//
using System.Collections;
using UnityEngine.XR.WSA.Input;

public class SoldierFactory
{

	//- 创建士兵
    // 
    // @return 创建出的士兵.
    public BaseSoldier createSoldier() {
        BaseSoldier soldier = new Grizzly();
        soldier.Create("grizzly");
  
        FixVector3 origin = new FixVector3((Fix64)0, (Fix64)1, (Fix64)(-4.0f));
        FixVector3 end = new FixVector3(origin.x, origin.y, (Fix64) 8);
        float moveTime = 3 + GameData.g_srand.Range(0, 3);
        soldier.Init(origin,end,(Fix64)moveTime);
        
        GameData.g_listSoldier.Add(soldier);
        return soldier;
    }
}
