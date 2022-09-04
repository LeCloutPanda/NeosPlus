﻿using System;
using FrooxEngine;
using FrooxEngine.LogiX;
using FrooxEngine.LogiX.Math;
using BaseX;
using FrooxEngine.CommonAvatar;
using System.Collections.Generic;


namespace FrooxEngine.LogiX.Avatar
{
    [Category("LogiX/Avatar")]
    [NodeName("Avatar Root Slot")]
    public class AvatarRootSlot : LogixOperator<Slot>
    {
        public readonly Input<User> User;
        public override Slot Content
        {
            get
            {
                User user = User.Evaluate();
                if (user == null)
                    return null;
                Slot slot = user.Root.Slot;
                List<AvatarRoot> list = new List<AvatarRoot>();
                slot.GetFirstDirectComponentsInChildren(list);
                if (list.Count == 0)
                    return null;
                return list[0].Slot;
            }
        }
        protected override void NotifyOutputsOfChange() => ((IOutputElement)this).NotifyChange();
    }
}