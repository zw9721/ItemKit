# ItemKit

## 项目简介

ItemKit 是一个基于 Unity 的道具（Item）及背包（Inventory）管理工具包，旨在为游戏开发者提供高效、灵活的道具系统解决方案。其核心设计理念是模块化、易扩展，并可无缝集成到各类 Unity 项目中。

## 主要功能

- 道具（Item）数据结构设计
- 背包（Inventory）管理，包括增删查改和容量控制
- 支持多种道具类型（消耗品、装备、材料等）的扩展
- 提供与 TableKit 表结构结合实现高效的数据存储和查询
- 可与 PoolKit、SingletonKit 等工具集成，实现对象池与单例管理
- 易于与 UI 系统结合，实现道具展示、拖拽、使用等交互

## 核心模块简介

### 1. Item 数据结构

- 支持自定义字段（如ID、名称、描述、图标、稀有度、叠加数等）
- 可扩展基类，实现特殊道具行为（如装备、消耗品等）

### 2. Inventory 管理

- 提供背包格子的动态增删与容量设定
- 支持道具的自动合并、堆叠、拆分
- 提供道具查找、筛选、排序接口

### 3. 数据持久化

- 可选与 TableKit 表结构结合，便捷实现背包数据的存储与读取

### 4. UI 交互支持

- 暴露接口方便与 Unity UI 组件集成
- 支持常见的背包操作（拖拽、点击使用、快捷栏等）

## 示例用法

```csharp
// 创建一个自定义道具
class HealthPotion : ItemBase
{
    public override void Use()
    {
        // 恢复玩家生命
    }
}

// 向背包添加道具
Inventory inventory = new Inventory(20); // 容量为20
ItemBase potion = new HealthPotion();
inventory.AddItem(potion);

// 查询背包内的所有药水
var potions = inventory.FindItems<HealthPotion>();
```

## 集成与扩展

- 默认依赖 TableKit 以高效管理道具表结构
- 可与 PoolKit 配合优化频繁生成/销毁的道具对象
- 支持自定义背包规则，如自动整理、排序、筛选等

## 未来规划

- 丰富道具类型和背包交互功能
- 提供更多 UI 示例和序列化存档支持
- 完善文档与 API 注释

## 相关链接

- TableKit: [github](https://github.com/liangxiegame/TableKit)
- QFramework: [github](https://github.com/liangxiegame/qframework)

---

如需补充详细用法、API 说明或贡献指南，请按实际代码补充完善。
