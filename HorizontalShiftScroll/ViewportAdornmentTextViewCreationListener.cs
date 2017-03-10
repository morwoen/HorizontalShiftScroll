using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace HorizontalShiftScroll
{
    [ContentType("text")]
    [Export(typeof(IWpfTextViewCreationListener))]
    [TextViewRole("DOCUMENT")]
    internal sealed class ViewportAdornment1TextViewCreationListener : IWpfTextViewCreationListener
    {
        [Export(typeof(AdornmentLayerDefinition))]
        [Name("HorizontalShiftScroll")]
        [Order(After = "Caret")]
        private AdornmentLayerDefinition editorAdornmentLayer;

        public void TextViewCreated(IWpfTextView textView)
        {
            var horizontalShiftScroll = new HorizontalShiftScroll(textView);
        }
    }
}
