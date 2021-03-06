using MonoTouch.UIKit;

namespace Xamarin.Utilities.DialogElements
{
    public class NoItemsElement : StyledStringElement
    {
        public NoItemsElement()
            : this("No Items")
        {
        }

        public NoItemsElement(string text)
            : base(text)
        {
        }

        public override UITableViewCell GetCell(UITableView tv)
        {
            var c = base.GetCell(tv);
            c.TextLabel.TextAlignment = UITextAlignment.Center;
            return c;
        }
    }
}

