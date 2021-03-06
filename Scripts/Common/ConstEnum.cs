﻿/// <summary>
/// 所有事件类型
/// </summary>
public enum KCEvent
{
    /// <summary>
    /// 道具发生改变
    /// </summary>
    KCItemsChange,
    /// <summary>
    /// 地块变化
    /// </summary>
    KCTileChange,
    /// <summary>
    /// 英雄生命变化
    /// </summary>
    KCHeroHPChange,
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
public enum HurtType
{ 
    /// <summary>
    /// 伤害
    /// </summary>
    Hurt,
    /// <summary>
    /// 闪避
    /// </summary>
    Miss,
    /// <summary>
    /// 回复
    /// </summary>
    Reply,
}
public enum PoolType
{ 
    /// <summary>
    /// 英雄池
    /// </summary>
    HeroPool,
    /// <summary>
    /// 传送池
    /// </summary>
    DoorPool,
    /// <summary>
    /// 文本池
    /// </summary>
    TextPool,
}
public enum DataType 
{
    /// <summary>
    /// 用户数据表
    /// </summary>
    UserInfo,
    /// <summary>
    /// 地块数据表
    /// </summary>
    TileList,
    /// <summary>
    /// 英雄数据表
    /// </summary>
    HeroList,
    /// <summary>
    /// 道具数据表
    /// </summary>
    ItemList,
}
