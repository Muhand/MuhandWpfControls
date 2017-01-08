using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MCustomControls
{
    /// <summary>
    /// Interaction logic for ModernTextField.xaml
    /// </summary>
    public partial class ModernTextField : UserControl
    {
        public ModernTextField()
        {
            InitializeComponent();
            this.BorderBrush = BorderBrushWithNoFocus;
            if (field.Text == "")
            {
                //field.Text = PlaceHolder;
                field.Foreground = PlaceHolderColor;
            }
            else
            {
                field.Foreground = FontColor;
            }
        }

        #region Properties
        //Read Only Properties
        /// <summary>
        /// This is the border brush while the control is not on focus
        /// </summary>
        public SolidColorBrush BorderBrush
        {
            get { return (SolidColorBrush)GetValue(BorderBrushProperty); }
            private set { base.SetValue(BorderBrushProperty, value); }
        }
        public static readonly DependencyProperty BorderBrushProperty =
          DependencyProperty.Register("BorderBrush", typeof(SolidColorBrush), typeof(ModernTextField));

        //////////////////////


        /// <summary>
        /// Font Size
        /// </summary>
        public int FontSize
        {
            get { return base.GetValue(FontSizeProperty) is int ? (int) base.GetValue(FontSizeProperty) : 0; }
            set { base.SetValue(FontSizeProperty, value); }
        }
        public static readonly DependencyProperty FontSizeProperty =
          DependencyProperty.Register("FontSize", typeof(int), typeof(ModernTextField), new FrameworkPropertyMetadata(30));

        /// <summary>
        /// Font Weight
        /// </summary>
        public FontWeight FontWeight
        {
            get { return base.GetValue(FontWeightProperty) is FontWeight ? (FontWeight) base.GetValue(FontWeightProperty) : new FontWeight(); }
            set { base.SetValue(FontWeightProperty, value); }
        }
        public static readonly DependencyProperty FontWeightProperty =
          DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(ModernTextField), new FrameworkPropertyMetadata(FontWeights.Bold));

        /// <summary>
        /// Font Family
        /// </summary>
        public FontFamily FontFamily
        {
            get { return base.GetValue(FontFamilyProperty) as FontFamily; }
            set { base.SetValue(FontFamilyProperty, value); }
        }
        public static readonly DependencyProperty FontFamilyProperty =
          DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(ModernTextField), new FrameworkPropertyMetadata(new FontFamily("Arial Bold")));

        /// <summary>
        /// Font Color
        /// </summary>
        public SolidColorBrush FontColor
        {
            get { return base.GetValue(FontColorProperty) as SolidColorBrush; }
            set { base.SetValue(FontColorProperty, value); }
        }
        public static readonly DependencyProperty FontColorProperty =
          DependencyProperty.Register("FontColor", typeof(SolidColorBrush), typeof(ModernTextField), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black)));


        /// <summary>
        /// Vertical Alignment for the text
        /// </summary>
        public VerticalAlignment VerticalContentAlignment
        {
            get { return GetValue(VerticalContentAlignmentProperty) is VerticalAlignment ? (VerticalAlignment) GetValue(VerticalContentAlignmentProperty) : VerticalAlignment.Top; }
            set { base.SetValue(VerticalContentAlignmentProperty, value); }
        }
        public static readonly DependencyProperty VerticalContentAlignmentProperty =
          DependencyProperty.Register("VerticalContentAlignment", typeof(VerticalAlignment), typeof(ModernTextField), new FrameworkPropertyMetadata(System.Windows.VerticalAlignment.Center));

        /// <summary>
        /// Thickness for the border around the control
        /// </summary>
        public Thickness BorderThickness
        {
            get { return (Thickness) GetValue(BorderThicknessProperty); }
            set { base.SetValue(BorderThicknessProperty, value); }
        }
        public static readonly DependencyProperty BorderThicknessProperty =
          DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(ModernTextField), new FrameworkPropertyMetadata(new Thickness(1)));

        /// <summary>
        /// This is the border brush while the control is not on focus
        /// </summary>
        public SolidColorBrush BorderBrushWithNoFocus
        {
            get { return (SolidColorBrush)GetValue(BorderBrushWithNoFocusProperty); }
            set { base.SetValue(BorderBrushWithNoFocusProperty, value); }
        }
        public static readonly DependencyProperty BorderBrushWithNoFocusProperty =
          DependencyProperty.Register("BorderBrushWithNoFocus", typeof(SolidColorBrush), typeof(ModernTextField), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(212,212,212))));

        /// <summary>
        /// This is the border brush while the control is not on focus
        /// </summary>
        public SolidColorBrush BorderBrushOnFocus
        {
            get { return (SolidColorBrush)GetValue(BorderBrushOnFocusProperty); }
            set { base.SetValue(BorderBrushOnFocusProperty, value); }
        }
        public static readonly DependencyProperty BorderBrushOnFocusProperty =
          DependencyProperty.Register("BorderBrushOnFocus", typeof(SolidColorBrush), typeof(ModernTextField), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(4, 250, 203))));

        /// <summary>
        /// Placeholder for the textbox
        /// </summary>
        public string PlaceHolder
        {
            get { return base.GetValue(PlaceHolderProperty) as string; }
            set { base.SetValue(PlaceHolderProperty, value); }
        }
        public static readonly DependencyProperty PlaceHolderProperty =
          DependencyProperty.Register("PlaceHolder", typeof(string), typeof(ModernTextField));

        /// <summary>
        /// Placeholder Color
        /// </summary>
        public SolidColorBrush PlaceHolderColor
        {
            get { return base.GetValue(PlaceHolderColorProperty) as SolidColorBrush; }
            set { base.SetValue(PlaceHolderColorProperty, value); }
        }
        public static readonly DependencyProperty PlaceHolderColorProperty =
          DependencyProperty.Register("PlaceHolderColor", typeof(SolidColorBrush), typeof(ModernTextField), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(215,215,215))));

        /// <summary>
        /// The source for the icon that represents this field
        /// </summary>
        public ImageSource IconSource
        {
            get { return base.GetValue(IconSourceProperty) as ImageSource; }
            set { base.SetValue(IconSourceProperty, value); }
        }
        public static readonly DependencyProperty IconSourceProperty =
          DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(ModernTextField));
        #endregion

        #region Events
        private void UIElement_OnGotFocus(object sender, RoutedEventArgs e)
        {
            BorderBrush = this.BorderBrushOnFocus;
            if (field.Text == PlaceHolder)
            {
                field.Text = "";
                field.Foreground = FontColor;
            }
        }
        private void UIElement_OnLostFocus(object sender, RoutedEventArgs e)
        {
            BorderBrush = this.BorderBrushWithNoFocus;
            if (field.Text == "")
            {
                field.Text = PlaceHolder;
                field.Foreground = PlaceHolderColor;
            }
        }

        #endregion


    }
}
