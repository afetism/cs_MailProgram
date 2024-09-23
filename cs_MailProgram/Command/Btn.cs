using System.Windows.Controls;
using System.Windows;

namespace cs_MailProgram.Command;
public class Btn : RadioButton
{
    static Btn()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Btn), new FrameworkPropertyMetadata(typeof(Btn)));
    }
}