// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Windows.Forms
{
    public partial class ButtonBase
    {
        public class ButtonBaseAccessibleObject : ControlAccessibleObject
        {
            public ButtonBaseAccessibleObject(Control owner)
                : base((owner is ButtonBase owningButtonBase) ? owner : throw new ArgumentException(string.Format(SR.ConstructorArgumentInvalidValueType, nameof(Owner), typeof(ButtonBase))))
            {
            }

            public override AccessibleStates State
                => OwnerInternal.IsHandleCreated && OwnerInternal.OwnerDraw && OwnerInternal.MouseIsDown
                    ? base.State | AccessibleStates.Pressed
                    : base.State;

            public override void DoDefaultAction()
            {
                if (OwnerInternal.IsHandleCreated)
                {
                    OwnerInternal.OnClick(EventArgs.Empty);
                }
            }

            internal override ButtonBase OwnerInternal => (ButtonBase)Owner;
        }
    }
}
