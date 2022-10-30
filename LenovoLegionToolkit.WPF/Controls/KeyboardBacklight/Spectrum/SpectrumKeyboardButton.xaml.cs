﻿using System.Windows.Media;

namespace LenovoLegionToolkit.WPF.Controls.KeyboardBacklight.Spectrum
{
    public partial class SpectrumKeyboardButton
    {
        public ushort KeyCode { get; set; }

        public Color? Color
        {
            get => (_background.Background as SolidColorBrush)?.Color;
            set
            {
                if (!value.HasValue)
                    _background.Background = null;
                else if (_background.Background is SolidColorBrush brush)
                    brush.Color = value.Value;
                else
                    _background.Background = new SolidColorBrush(value.Value);
            }
        }

        public SpectrumKeyboardButton()
        {
            InitializeComponent();
        }
    }
}
