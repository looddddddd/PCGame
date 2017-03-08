/// <summary>
/// 所有事件类型
/// </summary>
public enum KCEvent
{
    /// <summary>
    /// 道具发生改变
    /// </summary>
    KCItemChange,
}
public enum HeroType 
{
    /// <summary>
    /// 头领
    /// </summary>
    Boss,
    /// <summary>
    /// 小兵
    /// </summary>
    Dogface,
}
public enum ItemType 
{
    /// <summary>
    /// 不可损坏且唯一
    /// </summary>
    Unbroken,
    /// <summary>
    /// 可损坏
    /// </summary>
    Broken,
}
public enum FreshType 
{
    /// <summary>
    /// 生命值
    /// </summary>
    Hp,
    /// <summary>
    /// 攻击力
    /// </summary>
    Att,
    /// <summary>
    /// 死亡
    /// </summary>
    Die,
    /// <summary>
    /// 耐久度
    /// </summary>
    Dur,
}
public enum DoorType
{ 
    /// <summary>
    /// 向上
    /// </summary>
    Up,
    /// <summary>
    /// 向下
    /// </summary>
    Down,
    /// <summary>
    /// 向左
    /// </summary>
    Left,
    /// <summary>
    /// 向右
    /// </summary>
    Right,
    /// <summary>
    /// 系统定义终点
    /// </summary>
    SysEnd,
    /// <summary>
    /// 用户定义终点
    /// </summary>
    UserEnd,
}
