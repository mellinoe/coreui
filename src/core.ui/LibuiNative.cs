using System;
using System.Runtime.InteropServices;

using size_t = System.UIntPtr;
using uiButtonPtr = System.IntPtr;
using uiBoxPtr = System.IntPtr;
using uiCheckbox = System.IntPtr;
using uiEntry = System.IntPtr;
using uiLabelPtr = System.IntPtr;
using uiTabPtr = System.IntPtr;
using uiGroupPtr = System.IntPtr;
using uiSpinboxPtr = System.IntPtr;
using uiSlider = System.IntPtr;
using uiProgressBarPtr = System.IntPtr;
using uiSeparatorPtr = System.IntPtr;
using uiEditableCombobox = System.IntPtr;
using uiRadioButtons = System.IntPtr;
using uiMultilineEntry = System.IntPtr;
using uiMenuItem = System.IntPtr;
using uiMenuPtr = System.IntPtr;
using uiAreaPtr = System.IntPtr;
using uiAreaHandler = System.IntPtr;
using uiAreaDrawParams = System.IntPtr;
using uiAreaMouseEvent = System.IntPtr;
using uiAreaKeyEvent = System.IntPtr;
using uiDrawContextPtr = System.IntPtr;
using uiDrawPath = System.IntPtr;
using uiDrawBrush = System.IntPtr;
using uiDrawStrokeParams = System.IntPtr;
using uiDrawMatrix = System.IntPtr;
using uiDrawBrushGradientStop = System.IntPtr;
using uiDrawFontFamilies = System.IntPtr;
using uiDrawTextLayout = System.IntPtr;
using uiDrawTextFont = System.IntPtr;
using uiDrawTextFontDescriptor = System.IntPtr;
using uiDrawTextFontMetrics = System.IntPtr;
using uiWindowPtr = System.IntPtr;
using uiCombobox = System.IntPtr;
using uiDateTimePickerPtr = System.IntPtr;
using uiAreaHandlerPtr = System.IntPtr;
using uiAreaDrawParamsPtr = System.IntPtr;
using uiAreaMouseEventPtr = System.IntPtr;
using uiAreaKeyEventPtr = System.IntPtr;
using uiGridPtr = System.IntPtr;
using uiFormPtr = System.IntPtr;
using uiFontButtonPtr = System.IntPtr;
using uiColorButtonPtr = System.IntPtr;

namespace CoreUI
{
    public static unsafe class LibuiNative
    {
        private const string LibName = "libui";

        public unsafe struct uiControlPtr
        {
            public readonly uiControl* Ptr;

            public uiControlPtr(uiControl* ptr)
            {
                Ptr = ptr;
            }

            public uiControlPtr(IntPtr ptr)
            {
                Ptr = (uiControl*)ptr.ToPointer();
            }

            public static implicit operator uiControlPtr(uiControl* ptr)
            {
                return new uiControlPtr(ptr);
            }

            public static implicit operator uiControlPtr(IntPtr ptr)
            {
                return new uiControlPtr(ptr);
            }

            public static implicit operator uiControl* (uiControlPtr wrapped)
            {
                return wrapped.Ptr;
            }
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiInitOptions
        {
            size_t Size;
        };

        [DllImport(LibName)]
        public static extern string uiInit(uiInitOptions* options);
        [DllImport(LibName)]
        public static extern void uiUninit();
        [DllImport(LibName)]
        public static extern void uiFreeInitError(string err);

        [DllImport(LibName)]
        public static extern void uiMain();
        [DllImport(LibName)]
        public static extern void uiMainSteps();
        [DllImport(LibName)]
        public static extern int uiMainStep(int wait);
        [DllImport(LibName)]
        public static extern void uiQuit();

        [DllImport(LibName)]
        public static extern void uiQueueMain(Action<IntPtr> callback, IntPtr data);

        public delegate IntPtr uiOnShouldQuitCallback(IntPtr w);

        [DllImport(LibName)]
        public static extern void uiOnShouldQuit(uiOnShouldQuitCallback callback, IntPtr data);

        [DllImport(LibName)]
        public static extern void uiFreeText(string text);

        [StructLayout(LayoutKind.Sequential)]
        public struct uiControl
        {
            public Int32 Signature;
            public Int32 OSSignature;
            public Int32 TypeSignature;

            private IntPtr _Destroy;
            private IntPtr _Handle;
            private IntPtr _Parent;
            private IntPtr _SetParent;
            private IntPtr _Toplevel;
            private IntPtr _Visible;
            private IntPtr _Show;
            private IntPtr _Hide;
            private IntPtr _Enabled;
            private IntPtr _Enable;
            private IntPtr _Disable;

            public Action<uiControlPtr> Destroy => Marshal.GetDelegateForFunctionPointer<Action<uiControlPtr>>(_Destroy);
            public Func<uiControlPtr, UIntPtr> Handle => Marshal.GetDelegateForFunctionPointer<Func<uiControlPtr, UIntPtr>>(_Handle);
            public Func<uiControlPtr, uiControlPtr> Parent => Marshal.GetDelegateForFunctionPointer<Func<uiControlPtr, uiControlPtr>>(_Parent);
            public Action<uiControlPtr, uiControlPtr> SetParent => Marshal.GetDelegateForFunctionPointer<Action<uiControlPtr, uiControlPtr>>(_SetParent);
            public Func<uiControlPtr, int> Toplevel => Marshal.GetDelegateForFunctionPointer<Func<uiControlPtr, int>>(_Toplevel);
            public Func<uiControlPtr, int> Visible => Marshal.GetDelegateForFunctionPointer<Func<uiControlPtr, int>>(_Visible);
            public Action<uiControlPtr> Show => Marshal.GetDelegateForFunctionPointer<Action<uiControlPtr>>(_Show);
            public Action<uiControlPtr> Hide => Marshal.GetDelegateForFunctionPointer<Action<uiControlPtr>>(_Hide);
            public Func<uiControlPtr, int> Enabled => Marshal.GetDelegateForFunctionPointer<Func<uiControlPtr, int>>(_Enabled);
            public Action<uiControlPtr> Enable => Marshal.GetDelegateForFunctionPointer<Action<uiControlPtr>>(_Enable);
            public Action<uiControlPtr> Disable => Marshal.GetDelegateForFunctionPointer<Action<uiControlPtr>>(_Disable);
        }

        // TOOD add argument names to all arguments
        [DllImport(LibName)]
        public static extern void uiControlDestroy(uiControlPtr ptr);
        [DllImport(LibName)]
        public static extern UIntPtr uiControlHandle(uiControlPtr ptr);
        [DllImport(LibName)]
        public static extern uiControlPtr uiControlParent(uiControlPtr ptr);
        [DllImport(LibName)]
        public static extern void uiControlSetParent(uiControlPtr ptr1, uiControlPtr ptr2);
        [DllImport(LibName)]
        public static extern int uiControlToplevel(uiControlPtr ptr);
        [DllImport(LibName)]
        public static extern int uiControlVisible(uiControlPtr ptr);
        [DllImport(LibName)]
        public static extern void uiControlShow(uiControlPtr ptr);
        [DllImport(LibName)]
        public static extern void uiControlHide(uiControlPtr ptr);
        [DllImport(LibName)]
        public static extern int uiControlEnabled(uiControlPtr ptr);
        [DllImport(LibName)]
        public static extern void uiControlEnable(uiControlPtr ptr);
        [DllImport(LibName)]
        public static extern void uiControlDisable(uiControlPtr ptr);

        [DllImport(LibName)]
        public static extern uiControlPtr uiAllocControl(size_t n, Int32 OSsig, Int32 typesig, string typenamestr);
        [DllImport(LibName)]
        public static extern void uiFreeControl(uiControlPtr ptr);

        // TODO make sure all controls have these
        [DllImport(LibName)]
        public static extern void uiControlVerifySetParent(uiControlPtr ptr1, uiControlPtr ptr2);
        [DllImport(LibName)]
        public static extern int uiControlEnabledToUser(uiControlPtr ptr);

        [DllImport(LibName)]
        public static extern void uiUserBugCannotSetParentOnToplevel(string type);

        [DllImport(LibName)]
        public static extern string uiWindowTitle(uiWindowPtr w);
        [DllImport(LibName)]
        public static extern void uiWindowSetTitle(uiWindowPtr w, string title);
        [DllImport(LibName)]
        public static extern void uiWindowPosition(uiWindowPtr w, int* x, int* y);
        [DllImport(LibName)]
        public static extern void uiWindowSetPosition(uiWindowPtr w, int x, int y);
        [DllImport(LibName)]
        public static extern void uiWindowCenter(uiWindowPtr w);
        [DllImport(LibName)]
        public static extern void uiWindowOnPositionChanged(uiWindowPtr w, Action<IntPtr, IntPtr> f, IntPtr data);
        [DllImport(LibName)]
        public static extern void uiWindowContentSize(uiWindowPtr w, int* width, int* height);
        [DllImport(LibName)]
        public static extern void uiWindowSetContentSize(uiWindowPtr w, int width, int height);
        [DllImport(LibName)]
        public static extern int uiWindowFullscreen(uiWindowPtr w);
        [DllImport(LibName)]
        public static extern void uiWindowSetFullscreen(uiWindowPtr w, int fullscreen);

        public delegate void uiWindowOnContentSizeChangedCallback(uiWindowPtr window, IntPtr data);
        [DllImport(LibName)]
        public static extern void uiWindowOnContentSizeChanged(uiWindowPtr w, uiWindowOnContentSizeChangedCallback f, IntPtr data);

        public delegate int uiWindowOnClosingCallback(uiWindowPtr w, IntPtr data);
        [DllImport(LibName)]
        public static extern void uiWindowOnClosing(uiWindowPtr w, uiWindowOnClosingCallback f, IntPtr data);
        [DllImport(LibName)]
        public static extern int uiWindowBorderless(uiWindowPtr w);
        [DllImport(LibName)]
        public static extern void uiWindowSetBorderless(uiWindowPtr w, int borderless);
        [DllImport(LibName)]
        public static extern void uiWindowSetChild(uiWindowPtr w, uiControlPtr child);
        [DllImport(LibName)]
        public static extern int uiWindowMargined(uiWindowPtr w);
        [DllImport(LibName)]
        public static extern void uiWindowSetMargined(uiWindowPtr w, int margined);
        [DllImport(LibName)]
        public static extern uiWindowPtr uiNewWindow(string title, int width, int height, int hasMenubar);

        [DllImport(LibName)]
        public static extern string uiButtonText(uiButtonPtr b);
        [DllImport(LibName)]
        public static extern void uiButtonSetText(uiButtonPtr b, string text);

        public delegate void uiButtonCallback(uiButtonPtr buttonPtr, IntPtr data);
        [DllImport(LibName)]
        public static extern void uiButtonOnClicked(uiButtonPtr b, uiButtonCallback f, IntPtr data);
        [DllImport(LibName)]
        public static extern uiButtonPtr uiNewButton(string text);

        [DllImport(LibName)]
        public static extern void uiBoxAppend(uiBoxPtr b, uiControlPtr child, int stretchy);
        [DllImport(LibName)]
        public static extern void uiBoxDelete(uiBoxPtr b, int index);
        [DllImport(LibName)]
        public static extern int uiBoxPadded(uiBoxPtr b);
        [DllImport(LibName)]
        public static extern void uiBoxSetPadded(uiBoxPtr b, int padded);
        [DllImport(LibName)]
        public static extern uiBoxPtr uiNewHorizontalBox();
        [DllImport(LibName)]
        public static extern uiBoxPtr uiNewVerticalBox();

        [DllImport(LibName)]
        public static extern string uiCheckboxText(uiCheckbox c);
        [DllImport(LibName)]
        public static extern void uiCheckboxSetText(uiCheckbox c, string text);
        [DllImport(LibName)]
        public static extern void uiCheckboxOnToggled(uiCheckbox c, Action<uiCheckbox, IntPtr> f, IntPtr data);
        [DllImport(LibName)]
        public static extern int uiCheckboxChecked(uiCheckbox c);
        [DllImport(LibName)]
        public static extern void uiCheckboxSetChecked(uiCheckbox c, int @checked);
        [DllImport(LibName)]
        public static extern uiCheckbox uiNewCheckbox(string text);

        [DllImport(LibName)]
        public static extern string uiEntryText(uiEntry e);
        [DllImport(LibName)]
        public static extern void uiEntrySetText(uiEntry e, string text);
        [DllImport(LibName)]
        public static extern void uiEntryOnChanged(uiEntry e, Action<uiEntry, IntPtr> f, IntPtr data);
        [DllImport(LibName)]
        public static extern int uiEntryReadOnly(uiEntry e);
        [DllImport(LibName)]
        public static extern void uiEntrySetReadOnly(uiEntry e, int @readonly);
        [DllImport(LibName)]
        public static extern uiEntry uiNewEntry();
        [DllImport(LibName)]
        public static extern uiEntry uiNewPasswordEntry();
        [DllImport(LibName)]
        public static extern uiEntry uiNewSearchEntry();

        [DllImport(LibName)]
        public static extern string uiLabelText(uiLabelPtr l);
        [DllImport(LibName)]
        public static extern void uiLabelSetText(uiLabelPtr l, string text);
        [DllImport(LibName)]
        public static extern uiLabelPtr uiNewLabel(string text);

        [DllImport(LibName)]
        public static extern void uiTabAppend(uiTabPtr t, string name, uiControlPtr c);
        [DllImport(LibName)]
        public static extern void uiTabInsertAt(uiTabPtr t, string name, int before, uiControlPtr c);
        [DllImport(LibName)]
        public static extern void uiTabDelete(uiTabPtr t, int index);
        [DllImport(LibName)]
        public static extern int uiTabNumPages(uiTabPtr t);
        [DllImport(LibName)]
        public static extern int uiTabMargined(uiTabPtr t, int page);
        [DllImport(LibName)]
        public static extern void uiTabSetMargined(uiTabPtr t, int page, int margined);
        [DllImport(LibName)]
        public static extern uiTabPtr uiNewTab();

        [DllImport(LibName)]
        public static extern string uiGroupTitle(uiGroupPtr g);
        [DllImport(LibName)]
        public static extern void uiGroupSetTitle(uiGroupPtr g, string title);
        [DllImport(LibName)]
        public static extern void uiGroupSetChild(uiGroupPtr g, uiControlPtr c);
        [DllImport(LibName)]
        public static extern int uiGroupMargined(uiGroupPtr g);
        [DllImport(LibName)]
        public static extern void uiGroupSetMargined(uiGroupPtr g, int margined);
        [DllImport(LibName)]
        public static extern uiGroupPtr uiNewGroup(string title);

        // spinbox/slider rules:
        // setting value outside of range will automatically clamp
        // initial value is minimum
        // complaint if min >= max?

        [DllImport(LibName)]
        public static extern int uiSpinboxValue(uiSpinboxPtr s);
        [DllImport(LibName)]
        public static extern void uiSpinboxSetValue(uiSpinboxPtr s, int value);

        public delegate void uiSpinboxOnChangedCallback(uiSpinboxPtr spinbox, IntPtr data);
        [DllImport(LibName)]
        public static extern void uiSpinboxOnChanged(uiSpinboxPtr s, uiSpinboxOnChangedCallback f, IntPtr data);
        [DllImport(LibName)]
        public static extern uiSpinboxPtr uiNewSpinbox(int min, int max);

        [DllImport(LibName)]
        public static extern int uiSliderValue(uiSlider s);
        [DllImport(LibName)]
        public static extern void uiSliderSetValue(uiSlider s, int value);

        public delegate void uiSliderOnChangedCallback(uiSlider slider, IntPtr data);

        [DllImport(LibName)]
        public static extern void uiSliderOnChanged(uiSlider s, uiSliderOnChangedCallback f, IntPtr data);
        [DllImport(LibName)]
        public static extern uiSlider uiNewSlider(int min, int max);

        [DllImport(LibName)]
        public static extern int uiProgressBarValue(uiProgressBarPtr p);
        [DllImport(LibName)]
        public static extern void uiProgressBarSetValue(uiProgressBarPtr p, int n);
        [DllImport(LibName)]
        public static extern uiProgressBarPtr uiNewProgressBar();

        [DllImport(LibName)]
        public static extern uiSeparatorPtr uiNewHorizontalSeparator();
        [DllImport(LibName)]
        public static extern uiSeparatorPtr uiNewVerticalSeparator();

        [DllImport(LibName)]
        public static extern void uiComboboxAppend(uiCombobox c, string text);
        [DllImport(LibName)]
        public static extern int uiComboboxSelected(uiCombobox c);
        [DllImport(LibName)]
        public static extern void uiComboboxSetSelected(uiCombobox c, int n);
        [DllImport(LibName)]
        public static extern void uiComboboxOnSelected(uiCombobox c, Action<uiCombobox, IntPtr> f, IntPtr data);
        [DllImport(LibName)]
        public static extern uiCombobox uiNewCombobox();

        [DllImport(LibName)]
        public static extern void uiEditableComboboxAppend(uiEditableCombobox c, string text);
        [DllImport(LibName)]
        public static extern string uiEditableComboboxText(uiEditableCombobox c);
        [DllImport(LibName)]
        public static extern void uiEditableComboboxSetText(uiEditableCombobox c, string text);
        // TODO what do we call a function that sets the currently selected item and fills the text field with it? editable comboboxes have no consistent concept of selected item
        [DllImport(LibName)]
        public static extern void uiEditableComboboxOnChanged(uiEditableCombobox c, Action<uiEditableCombobox, IntPtr> f, IntPtr data);
        [DllImport(LibName)]
        public static extern uiEditableCombobox uiNewEditableCombobox();


        [DllImport(LibName)]
        public static extern void uiRadioButtonsAppend(uiRadioButtons r, string text);
        [DllImport(LibName)]
        public static extern int uiRadioButtonsSelected(uiRadioButtons r);
        [DllImport(LibName)]
        public static extern void uiRadioButtonsSetSelected(uiRadioButtons r, int n);
        [DllImport(LibName)]
        public static extern void uiRadioButtonsOnSelected(uiRadioButtons r, Action<uiRadioButtons, IntPtr> f, IntPtr data);
        [DllImport(LibName)]
        public static extern uiRadioButtons uiNewRadioButtons();

        [DllImport(LibName)]
        public static extern uiDateTimePickerPtr uiNewDateTimePicker();
        [DllImport(LibName)]
        public static extern uiDateTimePickerPtr uiNewDatePicker();
        [DllImport(LibName)]
        public static extern uiDateTimePickerPtr uiNewTimePicker();

        // TODO provide a facility for entering tab stops?

        [DllImport(LibName)]
        public static extern string uiMultilineEntryText(uiMultilineEntry e);
        [DllImport(LibName)]
        public static extern void uiMultilineEntrySetText(uiMultilineEntry e, string text);
        [DllImport(LibName)]
        public static extern void uiMultilineEntryAppend(uiMultilineEntry e, string text);
        [DllImport(LibName)]
        public static extern void uiMultilineEntryOnChanged(uiMultilineEntry e, Action<uiMultilineEntry, IntPtr> f, IntPtr data);
        [DllImport(LibName)]
        public static extern int uiMultilineEntryReadOnly(uiMultilineEntry e);
        [DllImport(LibName)]
        public static extern void uiMultilineEntrySetReadOnly(uiMultilineEntry e, int @readonly);
        [DllImport(LibName)]
        public static extern uiMultilineEntry uiNewMultilineEntry();
        [DllImport(LibName)]
        public static extern uiMultilineEntry uiNewNonWrappingMultilineEntry();

        [DllImport(LibName)]
        public static extern void uiMenuItemEnable(uiMenuItem m);
        [DllImport(LibName)]
        public static extern void uiMenuItemDisable(uiMenuItem m);
        [DllImport(LibName)]
        public static extern void uiMenuItemOnClicked(uiMenuItem m, Action<uiMenuItem, IntPtr, IntPtr> f, IntPtr data);
        [DllImport(LibName)]
        public static extern int uiMenuItemChecked(uiMenuItem m);
        [DllImport(LibName)]
        public static extern void uiMenuItemSetChecked(uiMenuItem m, int @checked);

        [DllImport(LibName)]
        public static extern uiMenuItem uiMenuAppendItem(uiMenuPtr m, string name);
        [DllImport(LibName)]
        public static extern uiMenuItem uiMenuAppendCheckItem(uiMenuPtr m, string name);
        [DllImport(LibName)]
        public static extern uiMenuItem uiMenuAppendQuitItem(uiMenuPtr m);
        [DllImport(LibName)]
        public static extern uiMenuItem uiMenuAppendPreferencesItem(uiMenuPtr m);
        [DllImport(LibName)]
        public static extern uiMenuItem uiMenuAppendAboutItem(uiMenuPtr m);
        [DllImport(LibName)]
        public static extern void uiMenuAppendSeparator(uiMenuPtr m);
        [DllImport(LibName)]
        public static extern uiMenuPtr uiNewMenu(string name);

        [DllImport(LibName)]
        public static extern string uiOpenFile(uiWindowPtr parent);
        [DllImport(LibName)]
        public static extern string uiSaveFile(uiWindowPtr parent);
        [DllImport(LibName)]
        public static extern void uiMsgBox(uiWindowPtr parent, string title, string description);
        [DllImport(LibName)]
        public static extern void uiMsgBoxError(uiWindowPtr parent, string title, string description);

        [StructLayout(LayoutKind.Sequential)]
        struct uiAreaHandler
        {
            IntPtr _Draw;
            IntPtr _MouseEvent;
            IntPtr _MouseCrossed;
            IntPtr _DragBroken;
            IntPtr _KeyEvent;

            Action<uiAreaHandlerPtr, uiAreaPtr, uiAreaDrawParamsPtr> Draw => Marshal.GetDelegateForFunctionPointer<Action<uiAreaHandlerPtr, uiAreaPtr, uiAreaDrawParamsPtr>>(_Draw);
            Action<uiAreaHandlerPtr, uiAreaPtr, uiAreaMouseEventPtr> MouseEvent => Marshal.GetDelegateForFunctionPointer<Action<uiAreaHandlerPtr, uiAreaPtr, uiAreaMouseEventPtr>>(_MouseEvent);
            Action<uiAreaHandlerPtr, uiAreaPtr, int> MouseCrossed => Marshal.GetDelegateForFunctionPointer<Action<uiAreaHandlerPtr, uiAreaPtr, int>>(_MouseCrossed);
            Action<uiAreaHandlerPtr, uiAreaPtr> DragBroken => Marshal.GetDelegateForFunctionPointer<Action<uiAreaHandlerPtr, uiAreaPtr>>(_DragBroken);
            Func<uiAreaHandlerPtr, uiAreaPtr, uiAreaDrawParamsPtr, int> KeyEvent => Marshal.GetDelegateForFunctionPointer<Func<uiAreaHandlerPtr, uiAreaPtr, uiAreaDrawParamsPtr, int>>(_KeyEvent);
        }

        // TODO give a better name
        // TODO document the types of width and height
        [DllImport(LibName)]
        public static extern void uiAreaSetSize(uiAreaPtr a, int width, int height);
        // TODO uiAreaQueueRedraw()
        [DllImport(LibName)]
        public static extern void uiAreaQueueRedrawAll(uiAreaPtr a);
        [DllImport(LibName)]
        public static extern void uiAreaScrollTo(uiAreaPtr a, double x, double y, double width, double height);
        [DllImport(LibName)]
        public static extern uiAreaPtr uiNewArea(uiAreaHandlerPtr ah);
        [DllImport(LibName)]
        public static extern uiAreaPtr uiNewScrollingArea(uiAreaHandlerPtr ah, int width, int height);

        [StructLayout(LayoutKind.Sequential)]
        public struct uiAreaDrawParams
        {
            public uiDrawContextPtr Context;

            // TODO document that this is only defined for nonscrolling areas
            public double AreaWidth;
            public double AreaHeight;

            public double ClipX;
            public double ClipY;
            public double ClipWidth;
            public double ClipHeight;
        }



        public enum uiDrawBrushType
        {
            uiDrawBrushTypeSolid,
            uiDrawBrushTypeLinearGradient,
            uiDrawBrushTypeRadialGradient,
            uiDrawBrushTypeImage,
        };

        public enum uiDrawLineCap
        {
            uiDrawLineCapFlat,
            uiDrawLineCapRound,
            uiDrawLineCapSquare,
        };

        public enum uiDrawLineJoin
        {
            uiDrawLineJoinMiter,
            uiDrawLineJoinRound,
            uiDrawLineJoinBevel,
        };

        // this is the default for botoh cairo and Direct2D (in the latter case, from the C++ helper functions)
        // Core Graphics doesn't explicitly specify a default, but NSBezierPath allows you to choose one, and this is the initial value
        // so we're good to use it too!

        public enum uiDrawFillMode
        {
            uiDrawFillModeWinding,
            uiDrawFillModeAlternate,
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawMatrix
        {
            public double M11;
            public double M12;
            public double M21;
            public double M22;
            public double M31;
            public double M32;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawBrush
        {
            public uiDrawBrushType Type;

            // solid brushes
            public double R;
            public double G;
            public double B;
            public double A;

            // gradient brushes
            public double X0;      // linear: start X, radial: start X
            public double Y0;      // linear: start Y, radial: start Y
            public double X1;      // linear: end X, radial: outer circle center X
            public double Y1;      // linear: end Y, radial: outer circle center Y
            public double OuterRadius;     // radial gradients only
            public uiDrawBrushGradientStop* Stops;
            public size_t NumStops;
            // TODO extend mode
            // cairo: none, repeat, reflect, pad; no individual control
            // Direct2D: repeat, reflect, pad; no individual control
            // Core Graphics: none, pad; before and after individually
            // TODO cairo documentation is inconsistent about pad

            // TODO images

            // TODO transforms
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawBrushGradientStop
        {
            public double Pos;
            public double R;
            public double G;
            public double B;
            public double A;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawStrokeParams
        {
            public uiDrawLineCap Cap;
            public uiDrawLineJoin Join;
            // TODO what if this is 0? on windows there will be a crash with dashing
            public double Thickness;
            double MiterLimit;
            double* Dashes;
            // TOOD what if this is 1 on Direct2D?
            // TODO what if a dash is 0 on Cairo or Quartz?
            public size_t NumDashes;
            double DashPhase;
        };

        [DllImport(LibName)]
        public static extern uiDrawPath* uiDrawNewPath(uiDrawFillMode fillMode);
        [DllImport(LibName)]
        public static extern void uiDrawFreePath(uiDrawPath* p);

        [DllImport(LibName)]
        public static extern void uiDrawPathNewFigure(uiDrawPath* p, double x, double y);
        [DllImport(LibName)]
        public static extern void uiDrawPathNewFigureWithArc(uiDrawPath* p, double xCenter, double yCenter, double radius, double startAngle, double sweep, int negative);
        [DllImport(LibName)]
        public static extern void uiDrawPathLineTo(uiDrawPath* p, double x, double y);
        // notes: angles are both relative to 0 and go counterclockwise
        // TODO is the initial line segment on cairo and OS X a proper join?
        // TODO what if sweep < 0?
        [DllImport(LibName)]
        public static extern void uiDrawPathArcTo(uiDrawPath* p, double xCenter, double yCenter, double radius, double startAngle, double sweep, int negative);
        [DllImport(LibName)]
        public static extern void uiDrawPathBezierTo(uiDrawPath* p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
        // TODO quadratic bezier
        [DllImport(LibName)]
        public static extern void uiDrawPathCloseFigure(uiDrawPath* p);

        // TODO effect of these when a figure is already started
        [DllImport(LibName)]
        public static extern void uiDrawPathAddRectangle(uiDrawPath* p, double x, double y, double width, double height);

        [DllImport(LibName)]
        public static extern void uiDrawPathEnd(uiDrawPath* p);

        [DllImport(LibName)]
        public static extern void uiDrawStroke(uiDrawContextPtr* c, uiDrawPath* path, uiDrawBrush* b, uiDrawStrokeParams* p);
        [DllImport(LibName)]
        public static extern void uiDrawFill(uiDrawContextPtr* c, uiDrawPath* path, uiDrawBrush* b);

        // TODO primitives:
        // - rounded rectangles
        // - elliptical arcs
        // - quadratic bezier curves

        [DllImport(LibName)]
        public static extern void uiDrawMatrixSetIdentity(uiDrawMatrix* m);
        [DllImport(LibName)]
        public static extern void uiDrawMatrixTranslate(uiDrawMatrix* m, double x, double y);
        [DllImport(LibName)]
        public static extern void uiDrawMatrixScale(uiDrawMatrix* m, double xCenter, double yCenter, double x, double y);
        [DllImport(LibName)]
        public static extern void uiDrawMatrixRotate(uiDrawMatrix* m, double x, double y, double amount);
        [DllImport(LibName)]
        public static extern void uiDrawMatrixSkew(uiDrawMatrix* m, double x, double y, double xamount, double yamount);
        [DllImport(LibName)]
        public static extern void uiDrawMatrixMultiply(uiDrawMatrix* dest, uiDrawMatrix* src);
        [DllImport(LibName)]
        public static extern int uiDrawMatrixInvertible(uiDrawMatrix* m);
        [DllImport(LibName)]
        public static extern int uiDrawMatrixInvert(uiDrawMatrix* m);
        [DllImport(LibName)]
        public static extern void uiDrawMatrixTransformPoint(uiDrawMatrix* m, double* x, double* y);
        [DllImport(LibName)]
        public static extern void uiDrawMatrixTransformSize(uiDrawMatrix* m, double* x, double* y);

        [DllImport(LibName)]
        public static extern void uiDrawTransform(uiDrawContextPtr* c, uiDrawMatrix* m);

        // TODO add a uiDrawPathStrokeToFill() or something like that
        [DllImport(LibName)]
        public static extern void uiDrawClip(uiDrawContextPtr* c, uiDrawPath* path);

        [DllImport(LibName)]
        public static extern void uiDrawSave(uiDrawContextPtr* c);
        [DllImport(LibName)]
        public static extern void uiDrawRestore(uiDrawContextPtr* c);

        // TODO manage the use of Text, Font, and TextFont, and of the uiDrawText prefix in general

        ///// TODO reconsider this

        [DllImport(LibName)]
        public static extern uiDrawFontFamilies* uiDrawListFontFamilies();
        [DllImport(LibName)]
        public static extern int uiDrawFontFamiliesNumFamilies(uiDrawFontFamilies* ff);
        [DllImport(LibName)]
        public static extern string uiDrawFontFamiliesFamily(uiDrawFontFamilies* ff, int n);
        [DllImport(LibName)]
        public static extern void uiDrawFreeFontFamilies(uiDrawFontFamilies* ff);
        ///// END TODO


        public enum uiDrawTextWeight
        {
            uiDrawTextWeightThin,
            uiDrawTextWeightUltraLight,
            uiDrawTextWeightLight,
            uiDrawTextWeightBook,
            uiDrawTextWeightNormal,
            uiDrawTextWeightMedium,
            uiDrawTextWeightSemiBold,
            uiDrawTextWeightBold,
            uiDrawTextWeightUtraBold,
            uiDrawTextWeightHeavy,
            uiDrawTextWeightUltraHeavy,
        };

        public enum uiDrawTextItalic
        {
            uiDrawTextItalicNormal,
            uiDrawTextItalicOblique,
            uiDrawTextItalicItalic,
        };

        public enum uiDrawTextStretch
        {
            uiDrawTextStretchUltraCondensed,
            uiDrawTextStretchExtraCondensed,
            uiDrawTextStretchCondensed,
            uiDrawTextStretchSemiCondensed,
            uiDrawTextStretchNormal,
            uiDrawTextStretchSemiExpanded,
            uiDrawTextStretchExpanded,
            uiDrawTextStretchExtraExpanded,
            uiDrawTextStretchUltraExpanded,
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawTextFontDescriptor
        {
            public char* Family;
            public double Size;
            public uiDrawTextWeight Weight;
            public uiDrawTextItalic Italic;
            public uiDrawTextStretch Stretch;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawTextFontMetrics
        {
            public double Ascent;
            public double Descent;
            public double Leading;
            // TODO do these two mean the same across all platforms?
            public double UnderlinePos;
            public double UnderlineThickness;
        };

        [DllImport(LibName)]
        public static extern uiDrawTextFont* uiDrawLoadClosestFont(uiDrawTextFontDescriptor* desc);
        [DllImport(LibName)]
        public static extern void uiDrawFreeTextFont(uiDrawTextFont* font);
        [DllImport(LibName)]
        public static extern UIntPtr uiDrawTextFontHandle(uiDrawTextFont* font);
        [DllImport(LibName)]
        public static extern void uiDrawTextFontDescribe(uiDrawTextFont* font, uiDrawTextFontDescriptor* desc);
        // TODO make copy with given attributes methods?
        // TODO yuck this name
        [DllImport(LibName)]
        public static extern void uiDrawTextFontGetMetrics(uiDrawTextFont* font, uiDrawTextFontMetrics* metrics);

        // TODO initial line spacing? and what about leading?
        [DllImport(LibName)]
        public static extern uiDrawTextLayout* uiDrawNewTextLayout(string text, uiDrawTextFont* defaultFont, double width);
        [DllImport(LibName)]
        public static extern void uiDrawFreeTextLayout(uiDrawTextLayout* layout);
        // TODO get width
        [DllImport(LibName)]
        public static extern void uiDrawTextLayoutSetWidth(uiDrawTextLayout* layout, double width);
        [DllImport(LibName)]
        public static extern void uiDrawTextLayoutExtents(uiDrawTextLayout* layout, double* width, double* height);

        // and the attributes that you can set on a text layout
        [DllImport(LibName)]
        public static extern void uiDrawTextLayoutSetColor(uiDrawTextLayout* layout, int startChar, int endChar, double r, double g, double b, double a);

        [DllImport(LibName)]
        public static extern void uiDrawText(uiDrawContextPtr* c, double x, double y, uiDrawTextLayout* layout);

        [Flags]
        public enum uiModifiers
        {
            uiModifierCtrl = 1 << 0,
            uiModifierAlt = 1 << 1,
            uiModifierShift = 1 << 2,
            uiModifierSuper = 1 << 3,
        };

        // TODO document drag captures
        [StructLayout(LayoutKind.Sequential)]
        struct uiAreaMouseEvent
        {
            // TODO document what these mean for scrolling areas
            public double X;
            public double Y;

            // TODO see draw above
            public double AreaWidth;
            public double AreaHeight;

            public int Down;
            public int Up;

            public int Count;

            public uiModifiers Modifiers;

            public UInt64 Held1To64;
        };

        public enum uiExtKey
        {
            uiExtKeyEscape = 1,
            uiExtKeyInsert,         // equivalent to "Help" on Apple keyboards
            uiExtKeyDelete,
            uiExtKeyHome,
            uiExtKeyEnd,
            uiExtKeyPageUp,
            uiExtKeyPageDown,
            uiExtKeyUp,
            uiExtKeyDown,
            uiExtKeyLeft,
            uiExtKeyRight,
            uiExtKeyF1,         // F1..F12 are guaranteed to be consecutive
            uiExtKeyF2,
            uiExtKeyF3,
            uiExtKeyF4,
            uiExtKeyF5,
            uiExtKeyF6,
            uiExtKeyF7,
            uiExtKeyF8,
            uiExtKeyF9,
            uiExtKeyF10,
            uiExtKeyF11,
            uiExtKeyF12,
            uiExtKeyN0,         // numpad keys; independent of Num Lock state
            uiExtKeyN1,         // N0..N9 are guaranteed to be consecutive
            uiExtKeyN2,
            uiExtKeyN3,
            uiExtKeyN4,
            uiExtKeyN5,
            uiExtKeyN6,
            uiExtKeyN7,
            uiExtKeyN8,
            uiExtKeyN9,
            uiExtKeyNDot,
            uiExtKeyNEnter,
            uiExtKeyNAdd,
            uiExtKeyNSubtract,
            uiExtKeyNMultiply,
            uiExtKeyNDivide,
        };

        [StructLayout(LayoutKind.Sequential)]
        struct uiAreaKeyEvent
        {
            public char Key;
            public uiExtKey ExtKey;
            public uiModifiers Modifier;

            public uiModifiers Modifiers;

            public int Up;
        };

        // TODO document this returns a new font
        [DllImport(LibName)]
        public static extern uiDrawTextFont* uiFontButtonFont(uiFontButtonPtr b);
        // TOOD SetFont, mechanics
        [DllImport(LibName)]
        public static extern void uiFontButtonOnChanged(uiFontButtonPtr b, Action<uiFontButtonPtr, IntPtr> f, IntPtr data);
        [DllImport(LibName)]
        public static extern uiFontButtonPtr uiNewFontButton();

        [DllImport(LibName)]
        public static extern void uiColorButtonColor(uiColorButtonPtr b, double* r, double* g, double* bl, double* a);
        [DllImport(LibName)]
        public static extern void uiColorButtonSetColor(uiColorButtonPtr b, double r, double g, double bl, double a);
        [DllImport(LibName)]
        public static extern void uiColorButtonOnChanged(uiColorButtonPtr b, Action<uiColorButtonPtr, IntPtr> f, IntPtr data);
        [DllImport(LibName)]
        public static extern uiColorButtonPtr uiNewColorButton();

        [DllImport(LibName)]
        public static extern void uiFormAppend(uiFormPtr f, string label, uiControlPtr c, int stretchy);
        [DllImport(LibName)]
        public static extern void uiFormDelete(uiFormPtr f, int index);
        [DllImport(LibName)]
        public static extern int uiFormPadded(uiFormPtr f);
        [DllImport(LibName)]
        public static extern void uiFormSetPadded(uiFormPtr f, int padded);
        [DllImport(LibName)]
        public static extern uiFormPtr uiNewForm();

        public enum uiAlign
        {
            uiAlignFill,
            uiAlignStart,
            uiAlignCenter,
            uiAlignEnd,
        };

        public enum uiAt
        {
            uiAtLeading,
            uiAtTop,
            uiAtTrailing,
            uiAtBottom,
        };

        [DllImport(LibName)]
        public static extern void uiGridAppend(uiGridPtr g, uiControlPtr c, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        [DllImport(LibName)]
        public static extern void uiGridInsertAt(uiGridPtr g, uiControlPtr c, uiControlPtr existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        [DllImport(LibName)]
        public static extern int uiGridPadded(uiGridPtr g);
        [DllImport(LibName)]
        public static extern void uiGridSetPadded(uiGridPtr g, int padded);
        [DllImport(LibName)]
        public static extern uiGridPtr uiNewGrid();
    }
}