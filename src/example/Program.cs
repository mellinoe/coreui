using System;
using static CoreUI.LibuiNative;

namespace CoreUI
{

    // This code is adapted from the official control gallery of libui
    // https://github.com/andlabs/libui/blob/master/examples/controlgallery/main.c
    public static class Program
    {
        private static IntPtr mainwin;
        private static IntPtr spinbox;
        private static IntPtr slider;
        private static IntPtr pbar;

        public static unsafe int Main(string[] args)
        {
            uiInitOptions options = new uiInitOptions();
            string err;
            IntPtr tab;

            err = uiInit(&options);
            if (err != null)
            {
                Console.WriteLine("error initializing libui: " + err);
                uiFreeInitError(err);
                return 1;
            }

            mainwin = uiNewWindow("libui Control Gallery", 640, 480, 1);
            uiWindowOnClosing(mainwin, onClosing, IntPtr.Zero);
            uiOnShouldQuit(onShouldQuit, mainwin);

            tab = uiNewTab();
            uiWindowSetChild(mainwin, uiControl(tab));
            uiWindowSetMargined(mainwin, 1);

            uiTabAppend(tab, "Basic Controls", makeBasicControlsPage());
            uiTabSetMargined(tab, 0, 1);

            uiTabAppend(tab, "Numbers and Lists", makeNumbersPage());
            uiTabSetMargined(tab, 1, 1);

            uiTabAppend(tab, "Data Choosers", makeDataChoosersPage());
            uiTabSetMargined(tab, 2, 1);

            uiControlShow(uiControl(mainwin));
            uiMain();
            return 0;

        }

        static uiControlPtr makeBasicControlsPage()
        {
            IntPtr vbox;
            IntPtr hbox;
            IntPtr group;
            IntPtr entryForm;

            vbox = uiNewVerticalBox();
            uiBoxSetPadded(vbox, 1);

            hbox = uiNewHorizontalBox();
            uiBoxSetPadded(hbox, 1);
            uiBoxAppend(vbox, uiControl(hbox), 0);

            uiBoxAppend(hbox,
                uiControl(uiNewButton("Button")),
                0);
            uiBoxAppend(hbox,
                uiControl(uiNewCheckbox("Checkbox")),
                0);

            uiBoxAppend(vbox,
                uiControl(uiNewLabel("This is a label. Right now, labels can only span one line.")),
                0);

            uiBoxAppend(vbox,
                uiControl(uiNewHorizontalSeparator()),
                0);

            group = uiNewGroup("Entries");
            uiGroupSetMargined(group, 1);
            uiBoxAppend(vbox, uiControl(group), 1);

            entryForm = uiNewForm();
            uiFormSetPadded(entryForm, 1);
            uiGroupSetChild(group, uiControl(entryForm));

            uiFormAppend(entryForm,
                "Entry",
                uiControl(uiNewEntry()),
                0);
            uiFormAppend(entryForm,
                "Password Entry",
                uiControl(uiNewPasswordEntry()),
                0);
            uiFormAppend(entryForm,
                "Search Entry",
                uiControl(uiNewSearchEntry()),
                0);
            uiFormAppend(entryForm,
                "Multiline Entry",
                uiControl(uiNewMultilineEntry()),
                1);
            uiFormAppend(entryForm,
                "Multiline Entry No Wrap",
                uiControl(uiNewNonWrappingMultilineEntry()),
                1);

            return uiControl(vbox);
        }

        static void onSpinboxChanged(IntPtr s, IntPtr data)
        {
            uiSliderSetValue(s, uiSpinboxValue(s));
            uiProgressBarSetValue(pbar, uiSpinboxValue(s));
        }

        static void onSliderChanged(IntPtr s, IntPtr data)
        {
            uiSpinboxSetValue(spinbox, uiSliderValue(s));
            uiProgressBarSetValue(pbar, uiSliderValue(s));
        }

        static uiControlPtr makeNumbersPage()
        {
            IntPtr hbox;
            IntPtr group;
            IntPtr vbox;
            IntPtr ip;
            IntPtr cbox;
            IntPtr ecbox;
            IntPtr rb;

            hbox = uiNewHorizontalBox();
            uiBoxSetPadded(hbox, 1);

            group = uiNewGroup("Numbers");
            uiGroupSetMargined(group, 1);
            uiBoxAppend(hbox, uiControl(group), 1);

            vbox = uiNewVerticalBox();
            uiBoxSetPadded(vbox, 1);
            uiGroupSetChild(group, uiControl(vbox));

            spinbox = uiNewSpinbox(0, 100);
            slider = uiNewSlider(0, 100);
            pbar = uiNewProgressBar();
            uiSpinboxOnChanged(spinbox, onSpinboxChanged, IntPtr.Zero);
            uiSliderOnChanged(slider, onSliderChanged, IntPtr.Zero);
            uiBoxAppend(vbox, uiControl(spinbox), 0);
            uiBoxAppend(vbox, uiControl(slider), 0);
            uiBoxAppend(vbox, uiControl(pbar), 0);

            ip = uiNewProgressBar();
            uiProgressBarSetValue(ip, -1);
            uiBoxAppend(vbox, uiControl(ip), 0);

            group = uiNewGroup("Lists");
            uiGroupSetMargined(group, 1);
            uiBoxAppend(hbox, uiControl(group), 1);

            vbox = uiNewVerticalBox();
            uiBoxSetPadded(vbox, 1);
            uiGroupSetChild(group, uiControl(vbox));

            cbox = uiNewCombobox();
            uiComboboxAppend(cbox, "Combobox Item 1");
            uiComboboxAppend(cbox, "Combobox Item 2");
            uiComboboxAppend(cbox, "Combobox Item 3");
            uiBoxAppend(vbox, uiControl(cbox), 0);

            ecbox = uiNewEditableCombobox();
            uiEditableComboboxAppend(ecbox, "Editable Item 1");
            uiEditableComboboxAppend(ecbox, "Editable Item 2");
            uiEditableComboboxAppend(ecbox, "Editable Item 3");
            uiBoxAppend(vbox, uiControl(ecbox), 0);

            rb = uiNewRadioButtons();
            uiRadioButtonsAppend(rb, "Radio Button 1");
            uiRadioButtonsAppend(rb, "Radio Button 2");
            uiRadioButtonsAppend(rb, "Radio Button 3");
            uiBoxAppend(vbox, uiControl(rb), 0);

            return uiControl(hbox);
        }

        static uiControlPtr makeDataChoosersPage()
        {
            IntPtr hbox;
            IntPtr vbox;
            IntPtr grid;
            IntPtr button;
            IntPtr entry;
            IntPtr msggrid;

            hbox = uiNewHorizontalBox();
            uiBoxSetPadded(hbox, 1);

            vbox = uiNewVerticalBox();
            uiBoxSetPadded(vbox, 1);
            uiBoxAppend(hbox, uiControl(vbox), 0);

            uiBoxAppend(vbox,
                uiControl(uiNewDatePicker()),
                0);
            uiBoxAppend(vbox,
                uiControl(uiNewTimePicker()),
                0);
            uiBoxAppend(vbox,
                uiControl(uiNewDateTimePicker()),
                0);

            uiBoxAppend(vbox,
                uiControl(uiNewFontButton()),
                0);
            uiBoxAppend(vbox,
                uiControl(uiNewColorButton()),
                0);

            uiBoxAppend(hbox,
                uiControl(uiNewVerticalSeparator()),
                0);

            vbox = uiNewVerticalBox();
            uiBoxSetPadded(vbox, 1);
            uiBoxAppend(hbox, uiControl(vbox), 1);

            grid = uiNewGrid();
            uiGridSetPadded(grid, 1);
            uiBoxAppend(vbox, uiControl(grid), 0);

            button = uiNewButton("Open File");
            entry = uiNewEntry();
            uiEntrySetReadOnly(entry, 1);
            uiButtonOnClicked(button, onOpenFileClicked, entry);
            uiGridAppend(grid, uiControl(button),
                0, 0, 1, 1,
                0, uiAlign.uiAlignFill, 0, uiAlign.uiAlignFill);
            uiGridAppend(grid, uiControl(entry),
                1, 0, 1, 1,
                1, uiAlign.uiAlignFill, 0, uiAlign.uiAlignFill);

            button = uiNewButton("Save File");
            entry = uiNewEntry();
            uiEntrySetReadOnly(entry, 1);
            uiButtonOnClicked(button, onSaveFileClicked, entry);
            uiGridAppend(grid, uiControl(button),
                0, 1, 1, 1,
                0, uiAlign.uiAlignFill, 0, uiAlign.uiAlignFill);
            uiGridAppend(grid, uiControl(entry),
                1, 1, 1, 1,
                1, uiAlign.uiAlignFill, 0, uiAlign.uiAlignFill);

            msggrid = uiNewGrid();
            uiGridSetPadded(msggrid, 1);
            uiGridAppend(grid, uiControl(msggrid),
                0, 2, 2, 1,
                0, uiAlign.uiAlignCenter, 0, uiAlign.uiAlignStart);

            button = uiNewButton("Message Box");
            uiButtonOnClicked(button, onMsgBoxClicked, IntPtr.Zero);
            uiGridAppend(msggrid, uiControl(button),
                0, 0, 1, 1,
                0, uiAlign.uiAlignFill, 0, uiAlign.uiAlignFill);
            button = uiNewButton("Error Box");
            uiButtonOnClicked(button, onMsgBoxErrorClicked, IntPtr.Zero);
            uiGridAppend(msggrid, uiControl(button),
                1, 0, 1, 1,
                0, uiAlign.uiAlignFill, 0, uiAlign.uiAlignFill);

            return uiControl(hbox);
        }

        static uiControlPtr uiControl(IntPtr ptr) => new uiControlPtr(ptr);

        static int onClosing(IntPtr w, IntPtr data)
        {
            uiQuit();
            return 1;
        }

        static IntPtr onShouldQuit(IntPtr data)
        {
            uiControlDestroy(data);
            return (IntPtr)1;
        }

        static void onOpenFileClicked(IntPtr b, IntPtr data)
        {
            IntPtr entry = data;
            string filename;

            filename = uiOpenFile(mainwin);
            if (filename == null)
            {
                uiEntrySetText(entry, "(cancelled)");
                return;
            }
            uiEntrySetText(entry, filename);
            uiFreeText(filename);
        }

        static void onSaveFileClicked(IntPtr b, IntPtr data)
        {
            IntPtr entry = data;
            string filename;

            filename = uiSaveFile(mainwin);
            if (filename == null)
            {
                uiEntrySetText(entry, "(cancelled)");
                return;
            }
            uiEntrySetText(entry, filename);
            uiFreeText(filename);
        }

        static void onMsgBoxClicked(IntPtr b, IntPtr data)
        {
            uiMsgBox(mainwin,
                "This is a normal message box.",
                "More detailed information can be shown here.");
        }

        static void onMsgBoxErrorClicked(IntPtr b, IntPtr data)
        {
            uiMsgBoxError(mainwin,
                "This message box describes an error.",
                "More detailed information can be shown here.");
        }
    }
}