using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Windows.Input;

namespace HorizontalShiftScroll
{
    internal sealed class HorizontalShiftScroll
    {
        private readonly IWpfTextView view;

        public HorizontalShiftScroll(IWpfTextView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            this.view = view;
            this.view.VisualElement.MouseWheel += this.OnScroll;
        }

        private void OnScroll(object sender, MouseWheelEventArgs e)
        {
            if (!this.view.VisualElement.IsMouseOver || (!Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift))) return;

            e.Handled = true;
            this.view.ViewScroller.ScrollViewportHorizontallyByPixels((double)(-e.Delta));
        }
    }
}
