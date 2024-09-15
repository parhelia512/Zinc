﻿using Arch.Core;
using Arch.Core.Extensions;

namespace Zinc;

[Component<RenderItem>]
[Component<ShapeRenderer>]
[Component<Collider>("Collider")]
public partial class Shape : Entity
{
    private readonly Action<EntityBase, double>? _updateWrapper;
    public Shape(Scene? scene = null, bool startEnabled = true, Action<Shape,double>? update = null)
        : base(startEnabled,scene)
    {
        Width = 32;
        Height = 32;
        RenderOrder = Scene.GetNextSceneRenderCounter();
        Collider_X = 0;
        Collider_Y = 0;
        Collider_Width = Width;
        Collider_Height = Height;
        Collider_Active = false;

        if (update != null)
        {
            _updateWrapper = (baseEntity, dt) =>
            {
                update((Shape)baseEntity, dt);
            };
            Update = _updateWrapper;
        }
    }
}