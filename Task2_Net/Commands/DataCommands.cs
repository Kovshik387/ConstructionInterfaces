using System;
using System.Windows.Input;

namespace Task2_Net.Commands
{
    public class DataCommands
    {
        public static RoutedCommand Delete { get; set; }
        public static RoutedCommand Cut { get; set; }
        public static RoutedCommand New { get; set; }
        public static RoutedCommand Find { get; set; }
        public static RoutedCommand Save { get; set; }
        public static RoutedCommand Cancel { get; set; }
        static DataCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection
            {
                new KeyGesture(Key.E, ModifierKeys.Control, "Ctrl+E")
            };
            Cut = new RoutedCommand("Cut", typeof(DataCommands), inputs);

            inputs = new InputGestureCollection
            {
                new KeyGesture(Key.D, ModifierKeys.Control, "Ctrl+D")
            };
            Delete = new RoutedCommand("Delete", typeof(DataCommands), inputs);

            inputs = new InputGestureCollection
            {
                new KeyGesture(Key.S, ModifierKeys.Control, "Ctrl+S")
            };
            Save = new RoutedCommand("Save", typeof(DataCommands), inputs);

            inputs = new InputGestureCollection
            {
                new KeyGesture(Key.Z, ModifierKeys.Control, "Ctrl+Z")
            };
            Cancel = new RoutedCommand("Delete", typeof(DataCommands), inputs);

            inputs = new InputGestureCollection
            {
                new KeyGesture(Key.F, ModifierKeys.Control, "Ctrl+F")
            };
            Find = new RoutedCommand("Find", typeof(DataCommands), inputs);

            inputs = new InputGestureCollection
            {
                new KeyGesture(Key.N, ModifierKeys.Control, "Ctrl+N")
            };
            New = new RoutedCommand("New", typeof(DataCommands), inputs);
        }

    }
}
