using System.Linq.Expressions;

namespace ScreenStreamer.Server
{
    public static class ControlExtensions
    {
        public static void BindToText<T>(this Control control, T dataSource, Expression<Func<T, object>> expression)
        {
            if (expression is UnaryExpression unaryExpression)
            {
                if (unaryExpression.Operand is MemberExpression memberExpression)
                {
                    control.DataBindings.Add("Text", dataSource, memberExpression.Member.Name);
                }
            }
        }

        public static int GetIntValue(this Control control)
        {
            return control.Invoke(() =>
            {
                if (int.TryParse(control.Text, out int value))
                    return value;
                return 0;
            });
        }

        public static bool GetBoolValue(this CheckBox control)
        {
            return control.Invoke(() =>
            {
                return control.Checked;
            });
        }
    }
}
